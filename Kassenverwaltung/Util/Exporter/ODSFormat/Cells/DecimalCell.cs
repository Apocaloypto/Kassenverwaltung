using Kassenverwaltung.Util.Exporter.ODSFormat.XmlHelper;

namespace Kassenverwaltung.Util.Exporter.ODSFormat.Cells
{
   public class DecimalCell : CellBase
   {
      public decimal Value { get; }
      public string ValueFormat { get; }

      public DecimalCell(int row, int col, decimal value, string valueFormat = "N0")
         : base(row, col)
      {
         Value = value;
         ValueFormat = valueFormat;
      }

      public override void Export(XmlNode parentNode)
      {
         XmlNode cellNode = parentNode.AddNode("table:table-cell");
         cellNode.AddAttribute("office:value-type", "float");
         cellNode.AddAttribute("office:value", Value.ToString(ValueFormat));
         cellNode.AddAttribute("calcext:value-type", "float");

         XmlNode valueNode = cellNode.AddNode("text:p");
         valueNode.SetText(Value.ToString(ValueFormat));
      }
   }
}
