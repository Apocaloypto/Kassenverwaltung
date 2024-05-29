using Kassenverwaltung.Util.Exporter.ODSFormat;
using Kassenverwaltung.Util.Exporter.ODSFormat.Cells;

namespace Kassenverwaltung.Tests
{
   public class SpreadSheetTests
   {
      [Fact]
      public void ExportSpreadsheet()
      {
         var spreadsheet = new Spreadsheet();

         Table table = spreadsheet.Content.AddTable("SoHeisstTabelle1");
         table.AddCell(new TextCell(0, 0, "Tabelle 1, Zelle A1"));
         table.AddCell(new TextCell(0, 1, "Tabelle 1, Zelle B1"));

         table = spreadsheet.Content.AddTable("SoHeisst Tabelle2");
         table.AddCell(new TextCell(0, 0, "Hier ist A1 und in B1 kommt eine Zahl:"));
         table.AddCell(new DecimalCell(0, 1, 1m));
         table.AddCell(new TextCell(1, 0, "Hier ist A2 und in B2 kommt noch eine Zahl:"));
         table.AddCell(new DecimalCell(1, 1, 2m));
         table.AddCell(new TextCell(2, 0, "Hier ist A3 und in B3 kommt die Summe:"));
         table.AddCell(new DecimalCell(2, 1, 3m));

         spreadsheet.Save(@"C:\Temp\Testdatei.ods");
      }
   }
}
