using Kassenverwaltung.Database.Models;
using Kassenverwaltung.Util.Exporter.ODSFormat;
using Kassenverwaltung.Util.Exporter.ODSFormat.Cells;

namespace Kassenverwaltung.Util.Exporter.Formats
{
   public class JhvExporter : IExporter
   {
      public string NULL_KAT = "<ohne Kategorie>";

      private readonly KassenManager _kassenManager;

      public JhvExporter(KassenManager kassenManager)
      {
         _kassenManager = kassenManager;
      }

      private IDictionary<int, Kategorie> ListKategorien()
      {
         IList<Kategorie> kategorien = _kassenManager.ListKategorien();
         return kategorien.ToDictionary(k => k.Id, k => k);
      }

      private IList<IGrouping<int?, Bewegung>> ListBewegungenNachKategorien()
      {
         IList<Bewegung> alleBewegungen = _kassenManager.ListBewegungen();
         return alleBewegungen.GroupBy(b => b.iKategorie).ToList();
      }

      public void Export(string filename)
      {
         var result = new Spreadsheet();

         IDictionary<int, Kategorie> kategorien = ListKategorien();
         IList<IGrouping<int?, Bewegung>> bewegungenNachKategorie = ListBewegungenNachKategorien();

         bool einnahmenNachKategorien = ExportEinnahmenNachKategorien(result, kategorien, bewegungenNachKategorie);
         bool ausgabenNachKategorien = ExportAusgabenNachKategorien(result, kategorien, bewegungenNachKategorie);
         bool kontenStaende = ExportKontostaende(result);

         if (!einnahmenNachKategorien && !ausgabenNachKategorien && !kontenStaende)
         {
            throw new InvalidOperationException($"Keine Daten zum Exportieren gefunden!");
         }

         result.Save(filename);
      }

      private bool ExportKontostaende(Spreadsheet result)
      {
         IList<Konto> konten = _kassenManager.ListKonten();
         if (konten.Count == 0)
         {
            return false;
         }

         Table exportTable = result.Content.AddTable("Kontostände");
         exportTable.AddCell(new TextCell(0, 0, "Aktuelle Kontostände"));
         exportTable.AddCell(new TextCell(2, 0, "Konto"));
         exportTable.AddCell(new TextCell(2, 1, "Betrag"));

         int iCurrentRow = 3;
         decimal gesamt = 0;

         foreach (var konto in konten)
         {
            exportTable.AddCell(new TextCell(iCurrentRow, 0, konto.Name ?? $"Unbenanntes Konto {konto.Id}"));

            decimal endBestand = _kassenManager.CalculateCurrentKontostand(konto);
            exportTable.AddCell(new CurrencyCell(iCurrentRow, 1, endBestand));
            gesamt += endBestand;

            iCurrentRow++;
         }

         iCurrentRow++;

         exportTable.AddCell(new CurrencyCell(iCurrentRow, 1, gesamt));

         return true;
      }

      private string LookupKategorie(int? kategorie, IDictionary<int, Kategorie> kategorien)
      {
         if (kategorie.HasValue)
         {
            if (kategorien.TryGetValue(kategorie.Value, out Kategorie? kategorieObject))
            {
               return kategorieObject.Name ?? $"Unbenannte Kategorie {kategorieObject.Id}";
            }
            else
            {
               return NULL_KAT;
            }
         }
         else
         {
            return NULL_KAT;
         }
      }

      private bool ExportAusgabenNachKategorien(Spreadsheet result, IDictionary<int, Kategorie> kategorien, IList<IGrouping<int?, Bewegung>> bewegungenNachKategorie)
      {
         if (bewegungenNachKategorie.Count == 0)
         {
            return false;
         }

         Table ausgabenTable = result.Content.AddTable("Ausgaben nach Kategorie");

         ExportiereBetraegeNachKategorie(kategorien, bewegungenNachKategorie, ausgabenTable, b => b < 0);

         return true;
      }

      private void ExportiereBetraegeNachKategorie(IDictionary<int, Kategorie> kategorien, IList<IGrouping<int?, Bewegung>> bewegungenNachKategorie, Table ausgabenTable, Func<decimal, bool> predicate)
      {
         ausgabenTable.AddCell(new TextCell(0, 0, "Kategorie"));
         ausgabenTable.AddCell(new TextCell(0, 1, "Betrag"));

         int iCurrentRow = 1;

         decimal gesamt = 0;
         foreach (var bewegungNachKategorie in bewegungenNachKategorie)
         {
            decimal gesamtProKat = 0;
            foreach (var bewegung in bewegungNachKategorie)
            {
               if (predicate(bewegung.Betrag))
               {
                  gesamtProKat += bewegung.Betrag;
               }
            }

            if (gesamtProKat == 0)
            {
               continue;
            }

            string kategorieName = LookupKategorie(bewegungNachKategorie.Key, kategorien);

            ausgabenTable.AddCell(new TextCell(iCurrentRow, 0, kategorieName));
            ausgabenTable.AddCell(new CurrencyCell(iCurrentRow, 1, gesamtProKat));

            gesamt += gesamtProKat;

            iCurrentRow++;
         }

         iCurrentRow++;

         ausgabenTable.AddCell(new TextCell(iCurrentRow, 0, "Gesamt"));
         ausgabenTable.AddCell(new CurrencyCell(iCurrentRow, 1, gesamt));
      }

      private bool ExportEinnahmenNachKategorien(Spreadsheet result, IDictionary<int, Kategorie> kategorien, IList<IGrouping<int?, Bewegung>> bewegungenNachKategorie)
      {
         if (bewegungenNachKategorie.Count == 0)
         {
            return false;
         }

         Table einnahmenTable = result.Content.AddTable("Einnahmen nach Kategorie");

         ExportiereBetraegeNachKategorie(kategorien, bewegungenNachKategorie, einnahmenTable, b => b > 0);

         return true;
      }
   }
}
