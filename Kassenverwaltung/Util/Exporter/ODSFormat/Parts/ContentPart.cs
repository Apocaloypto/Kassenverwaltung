using System.IO.Compression;
using System.Text;
using Kassenverwaltung.Util.Exporter.ODSFormat.Util;
using Kassenverwaltung.Util.Exporter.ODSFormat.XmlHelper;

namespace Kassenverwaltung.Util.Exporter.ODSFormat.Parts
{
    public class ContentPart : IPart
   {
      private readonly ContentHeader _contentHeader = new();

      private readonly IDictionary<string, Table> _tables;

      public ContentPart()
      {
         _tables = new Dictionary<string, Table>();
      }

      public Table AddTable(string name)
      {
         if (_tables.ContainsKey(name))
         {
            throw new InvalidOperationException($"Es ist bereits eine Tabelle mit dem Namen '{name}' im Spreadsheet enthalten");
         }

         var table = new Table(name, _contentHeader);
         _tables.Add(name, table);
         return table;
      }

      public void ExportToZip(ZipArchive zip, Encoding encoding)
      {
         if (_tables.Count == 0)
         {
            throw new InvalidOperationException($"Das Spreadsheet enthält keine Tabellen");
         }

         ZipArchiveEntry entry = zip.CreateEntry("content.xml");
         using (var stream = entry.Open())
         {
            Xml xml = CreateXml();
            xml.Save(stream, encoding);
         }
      }

      private Xml CreateXml()
      {
         var xml = new Xml("office:document-content");
         _contentHeader.Export(xml.RootNode);

         XmlNode spreadsheet = xml.RootNode.AddNode("office:body").AddNode("office:spreadsheet");

         ExportCalculationSettings(spreadsheet);

         foreach (var table in _tables.Values)
         {
            table.Export(spreadsheet);
         }

         ExportNamedExpressions(spreadsheet);

         return xml;
      }

      private void ExportNamedExpressions(XmlNode spreadsheet)
      {
         XmlNode namedExpression = spreadsheet.AddNode("table:named-expressions");
      }

      private void ExportCalculationSettings(XmlNode spreadsheet)
      {
         XmlNode calcSettings = spreadsheet.AddNode("table:calculation-settings");

         calcSettings.AddAttribute("table:automatic-find-labels", "false");
         calcSettings.AddAttribute("table:use-regular-expressions", "false");
         calcSettings.AddAttribute("table:use-wildcards", "true");
      }
   }
}
