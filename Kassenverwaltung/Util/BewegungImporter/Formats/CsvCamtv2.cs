
using Kassenverwaltung.Database.Models;

namespace Kassenverwaltung.Util.BewegungImporter.Formats
{
   public class CsvCamtv2 : IBewegungsImport
   {
      private const string VON_KONTO = "Auftragskonto";
      private const string DATUM = "Buchungstag";
      private const string VERWENDUNG = "Verwendungszweck";
      private const string BEGUENSTIGTER = "Beguenstigter/Zahlungspflichtiger";
      private const string AUF_KONTO = "Kontonummer/IBAN";
      private const string AUF_KONTO_BIC = "BIC (SWIFT-Code)";
      private const string BETRAG = "Betrag";

      private readonly KVManager DataManager;

      public CsvCamtv2(KVManager dataManager)
      {
         DataManager = dataManager;
      }

      private IDictionary<string, Konto> LoadKontenByIBAN()
      {
         IList<Konto> konten = DataManager.ListKonten();
         return konten.ToDictionary(k => k.IBAN!, k => k);
      }

      public IList<BewegungsDatensatz> GetBewegungsDatensaetze(string filename)
      {
         IDictionary<string, Konto> kontenByIban = LoadKontenByIBAN();

         IList<CsvDataset> datasets = CsvHelper.ReadDataFromFile(filename);
         var retval = new List<BewegungsDatensatz>();

         int zeile = 0;
         foreach (var dataset in datasets)
         {
            try
            {
               string IBAN = dataset.Values[VON_KONTO];

               string verwendungsZweck = dataset.Values[VERWENDUNG];
               string beguenstigter = dataset.Values[BEGUENSTIGTER];
               string aufkontoiban = dataset.Values[AUF_KONTO];
               string aufkontobic = dataset.Values[AUF_KONTO_BIC];

               string kompletteVerwendung = $"{verwendungsZweck}{Environment.NewLine}{beguenstigter}{Environment.NewLine}{aufkontoiban}{Environment.NewLine}{aufkontobic}";

               var bewegungsDatensatz = new BewegungsDatensatz()
               {
                  Referenz = zeile,
                  ZielKonto = kontenByIban[IBAN],
                  Datum = DateTime.ParseExact(dataset.Values[DATUM], "dd.MM.yy", null),
                  Betrag = decimal.Parse(dataset.Values[BETRAG]),
                  Verwendung = kompletteVerwendung,
               };

               Bewegung? bewegungAmGleichenTag = DataManager.FindBewegungAm(bewegungsDatensatz.ZielKonto!.Id, bewegungsDatensatz.Datum, bewegungsDatensatz.Betrag);
               if (bewegungAmGleichenTag == null)
               {
                  bewegungsDatensatz.Import = true;
               }
               else
               {
                  bewegungsDatensatz.WarnMeldung = $"Es besteht bereits eine Bewegung für den Tag in der angegebenen Höhe";
               }

               retval.Add(bewegungsDatensatz);
            }
            catch (Exception ex)
            {
               retval.Add(new BewegungsDatensatz()
               {
                  Referenz = zeile,
                  Import = false,
                  FehlerMeldung = ex.Message,
               });
            }

            zeile++;
         }

         return retval;
      }
   }
}
