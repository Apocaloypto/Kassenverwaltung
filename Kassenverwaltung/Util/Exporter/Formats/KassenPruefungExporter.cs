using Kassenverwaltung.Database.Models;
using Kassenverwaltung.Util.Exporter.ODSFormat;
using Kassenverwaltung.Util.Exporter.ODSFormat.Cells;

namespace Kassenverwaltung.Util.Exporter.Formats
{
   public class KassenPruefungExporter : IExporter
   {
      private const string CURRENCY_FORMAT = "C";

      private readonly KassenManager _kassenManager;

      public KassenPruefungExporter(KassenManager kassenManager)
      {
         _kassenManager = kassenManager;
      }

      public void Export(string filename)
      {
         var result = new Spreadsheet();

         IList<Konto> konten = _kassenManager.ListKonten();
         if (konten.Count == 0)
         {
            throw new InvalidOperationException($"Es wurden keine Konten zum Exportieren gefunden!");
         }

         foreach (var konto in konten)
         {
            ExportKonto(result, konto);
         }

         result.Save(filename);
      }

      private void ExportKonto(Spreadsheet spreadsheet, Konto konto)
      {
         IEnumerable<Bewegung> bewegungen = _kassenManager.ListBewegungen(konto).OrderBy(b => b.Datum);

         Table kontenTable = spreadsheet.Content.AddTable(konto.Name ?? $"Unbenanntes Konto {konto.Id}");

         ExportAnfangsbestand(konto, kontenTable);
         ExportHeader(kontenTable);

         int iCurrentRow = 3;
         foreach (var bewegung in bewegungen)
         {
            ExportBewegung(kontenTable, bewegung, iCurrentRow);
            iCurrentRow++;
         }

         iCurrentRow++;

         ExportEndbestand(konto, kontenTable, iCurrentRow);
      }

      private void ExportEndbestand(Konto konto, Table kontenTable, int iCurrentRow)
      {
         kontenTable.AddCell(new TextCell(iCurrentRow, 0, "Endbestand:"));
         kontenTable.AddCell(new CurrencyCell(iCurrentRow, 1, _kassenManager.CalculateCurrentKontostand(konto)));
      }

      private static void ExportHeader(Table kontenTable)
      {
         kontenTable.AddCell(new TextCell(2, 0, "Datum"));
         kontenTable.AddCell(new TextCell(2, 1, "Betrag"));
         kontenTable.AddCell(new TextCell(2, 2, "Verwendung"));
      }

      private static void ExportAnfangsbestand(Konto konto, Table kontenTable)
      {
         kontenTable.AddCell(new TextCell(0, 0, "Anfangsbestand:"));
         kontenTable.AddCell(new CurrencyCell(0, 1, konto.Anfangsbestand));
      }

      private void ExportBewegung(Table table, Bewegung bewegung, int iCurrentRow)
      {
         table.AddCell(new DateTimeCell(iCurrentRow, 0, bewegung.Datum));
         table.AddCell(new CurrencyCell(iCurrentRow, 1, bewegung.Betrag));
         table.AddCell(new TextCell(iCurrentRow, 2, bewegung.Verwendung ?? ""));
      }
   }
}
