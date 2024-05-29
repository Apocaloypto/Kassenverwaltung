using Kassenverwaltung.Util.Exporter.ODSFormat.XmlHelper;

namespace Kassenverwaltung.Util.Exporter.ODSFormat.Cells
{
   public class CurrencyCell : CellBase
   {
      public const string STYLE_NAME = "currencyfmt";

      public decimal Value { get; }

      public CurrencyCell(int row, int col, decimal value)
         : base(row, col)
      {
         Value = value;
      }

      public override void Export(XmlNode parentNode)
      {
         XmlNode cellNode = parentNode.AddNode("table:table-cell");
         cellNode.AddAttribute("table:style-name", STYLE_NAME);
         cellNode.AddAttribute("office:value-type", "currency");
         cellNode.AddAttribute("office:currency", "EUR");
         cellNode.AddAttribute("office:value", Value.ToString("F2"));
         cellNode.AddAttribute("calcext:value-type", "currency");

         XmlNode valueNode = cellNode.AddNode("text:p");
         valueNode.SetText(Value.ToString("C"));
      }
   }
}
