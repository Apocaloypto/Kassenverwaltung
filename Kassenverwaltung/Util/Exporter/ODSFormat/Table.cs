using Kassenverwaltung.Util.Exporter.ODSFormat.Cells;
using Kassenverwaltung.Util.Exporter.ODSFormat.Util;
using Kassenverwaltung.Util.Exporter.ODSFormat.XmlHelper;

namespace Kassenverwaltung.Util.Exporter.ODSFormat
{
    public class Table
   {
      private readonly string _name;
      private readonly IDictionary<string, CellBase> _cells;

      private readonly ContentHeader _contentHeader;

      public Table(string name, ContentHeader contentHeader)
      {
         _name = name;
         _cells = new Dictionary<string, CellBase>();
         _contentHeader = contentHeader;
      }

      public void AddCell(CellBase cell)
      {
         _cells.Add(cell.Position, cell);

         if (cell is CurrencyCell)
         {
            _contentHeader.HasCurrencyCell = true;
         }
         else if (cell is DateTimeCell)
         {
            _contentHeader.HasDateTimeCell = true;
         }
      }

		private IDictionary<int, TableRow> SplitToRows()
		{
         IEnumerable<IGrouping<int, CellBase>> cellsByRow = _cells.Values.GroupBy(c => c.Row);

			var rows = new List<TableRow>();
			foreach (var cellRow in cellsByRow)
			{
				rows.Add(new TableRow(cellRow));
			}
			return rows.OrderBy(r => r.Row).ToDictionary(r => r.Row!.Value, r => r);
		}

      private void ExportData(XmlNode tableNode)
      {
         IDictionary<int, TableRow> rows = SplitToRows();
         int? maxRow = rows.Keys.Any() ? rows.Keys.Max() : null;

         if (maxRow.HasValue)
         {
				for (int iRow = 0; iRow <= maxRow.Value; iRow++)
				{
					if (rows.TryGetValue(iRow, out TableRow? row))
					{
						row.ExportToXml(tableNode);
					}
					else
					{
                  AddFillerRow(tableNode);
					}
				}
         }
      }

      private void AddFillerRow(XmlNode tableNode)
      {
			XmlNode fillerRow = tableNode.AddNode("table:table-row");
      }

      public void Export(XmlNode parentNode)
      {
			XmlNode tableNode = parentNode.AddNode("table:table");
			tableNode.AddAttribute("table:name", _name);
         tableNode.AddAttribute("table:style-name", ContentHeader.TABLE_STYLE_NAME);

         ExportData(tableNode);
      }
   }
}
