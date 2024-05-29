using Kassenverwaltung.Util.Exporter.ODSFormat.XmlHelper;

namespace Kassenverwaltung.Util.Exporter.ODSFormat.Cells
{
   public class DateTimeCell : CellBase
   {
      public const string STYLE_NAME = "datetimefmt";

      public DateTime DateTime { get; }

      public DateTimeCell(int row, int col, DateTime date)
         : base(row, col)
      {
         DateTime = date;
      }

      public override void Export(XmlNode parentNode)
      {
         XmlNode cellNode = parentNode.AddNode("table:table-cell");
         cellNode.AddAttribute("table:style-name", STYLE_NAME);
         cellNode.AddAttribute("office:value-type", "date");
         cellNode.AddAttribute("office:date-value", DateTime.ToString("yyyy-MM-dd"));
         cellNode.AddAttribute("calcext:value-type", "date");

         XmlNode valueNode = cellNode.AddNode("text:p");
         valueNode.SetText(DateTime.ToString("dd.MM.yyyy"));
      }
   }
}
