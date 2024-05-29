using Kassenverwaltung.Util.Exporter.ODSFormat.XmlHelper;

namespace Kassenverwaltung.Util.Exporter.ODSFormat.Cells
{
   public class TextCell : CellBase
   {
      public string Text { get; }

      public TextCell(int row, int col, string text)
         : base(row, col)
      {
         Text = text;
      }

      public static string XmlEscape(string unescaped)
      {
         var doc = new System.Xml.XmlDocument();
         var node = doc.CreateElement("root");
         node.InnerText = unescaped;
         return node.InnerXml;
      }

      public override void Export(XmlNode parentNode)
      {
         XmlNode cellNode = parentNode.AddNode("table:table-cell");
         cellNode.AddAttribute("office:value-type", "string");
         cellNode.AddAttribute("calcext:value-type", "string");

         XmlNode valueNode = cellNode.AddNode("text:p");
         valueNode.SetText(XmlEscape(Text));
      }
   }
}
