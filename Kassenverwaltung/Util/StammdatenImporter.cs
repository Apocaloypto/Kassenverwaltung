using Kassenverwaltung.Database.Models;

namespace Kassenverwaltung.Util
{
   public class StammdatenImporter
   {
      private readonly KVManager DataManager;
      private readonly string SourceFile;

      public StammdatenImporter(KVManager dataManager, string sourceFile)
      {
         DataManager = dataManager;
         SourceFile = sourceFile;
      }

      public StammdatenImportResult ImportData()
      {
         var otherManager = new KVManager(SourceFile);

         return new StammdatenImportResult(ImportiereKonten(otherManager), ImportiereKategorien(otherManager));
      }

      private int ImportiereKategorien(KVManager otherManager)
      {
         IList<Kategorie> kategorien = otherManager.ListKategorien();

         int importiert = 0;
         foreach (var kategorie in kategorien)
         {
            DataManager.AddKategorie(kategorie);
            importiert++;
         }

         return importiert;
      }

      private int ImportiereKonten(KVManager otherManager)
      {
         IList<Konto> konten = otherManager.ListKonten();

         int importiert = 0;
         foreach (var konto in konten)
         {
            konto.Anfangsbestand = otherManager.CalculateCurrentKontostand(konto);
            DataManager.AddKonto(konto);
            importiert++;
         }

         return importiert;
      }
   }
}
