using Kassenverwaltung.Util.Exporter.ODSFormat.Cells;
using Kassenverwaltung.Util.Exporter.ODSFormat.XmlHelper;

namespace Kassenverwaltung.Util.Exporter.ODSFormat.Util
{
   public class TableRow
   {
      public IList<CellBase> Cells { get; }
      public int? Row => Cells.Count >= 1 ? Cells[0].Row : null;
      public int? Offset => Cells.Count >= 1 ? Cells[0].Column : null;
      public int? LastCell => Cells.Count >= 1 ? Cells[Cells.Count - 1].Column : null;

      public TableRow(IEnumerable<CellBase> cells)
      {
         Cells = cells.OrderBy(c => c.Column).ToList();
      }

      private void InsertOffsetCells(XmlNode tableRowNode)
      {
         if (Offset > 0)
         {
            XmlNode offsetCellNode = tableRowNode.AddNode("table:table-cell");
            offsetCellNode.AddAttribute("table:number-columns-repeated", $"{Offset.Value}");
         }
      }

      private void AddEmptyCell(XmlNode tableRowNode)
      {
         tableRowNode.AddNode("table:table-cell");
      }

      public void ExportToXml(XmlNode tableNode)
      {
         XmlNode tableRowNode = tableNode.AddNode("table:table-row");
         tableRowNode.AddAttribute("table:style-name", ContentHeader.ROW_STYLE_NAME);

         InsertOffsetCells(tableRowNode);

         int currentCell = Offset ?? 0;
         foreach (var cell in Cells)
         {
            for (int iFiller = currentCell; iFiller < cell.Column; iFiller++)
            {
               AddEmptyCell(tableRowNode);
            }

            cell.Export(tableRowNode);
            currentCell = cell.Column + 1;
         }
      }
   }
}
