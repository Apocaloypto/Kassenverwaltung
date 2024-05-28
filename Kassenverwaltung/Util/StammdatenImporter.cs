using Kassenverwaltung.Database.Models;

namespace Kassenverwaltung.Util
{
   public class StammdatenImporter
   {
      private readonly KassenManager _kassenManager;
      private readonly string _sourceFile;

      public StammdatenImporter(KassenManager kassenManager, string sourceFile)
      {
         _kassenManager = kassenManager;
         _sourceFile = sourceFile;
      }

      public StammdatenImportResult ImportData()
      {
         var otherManager = new KassenManager(_sourceFile);

         return new StammdatenImportResult(ImportiereKonten(otherManager), ImportiereKategorien(otherManager));
      }

      private int ImportiereKategorien(KassenManager otherManager)
      {
         IList<Kategorie> kategorien = otherManager.ListKategorien();

         int importiert = 0;
         foreach (var kategorie in kategorien)
         {
            _kassenManager.AddKategorie(kategorie);
            importiert++;
         }

         return importiert;
      }

      private int ImportiereKonten(KassenManager otherManager)
      {
         IList<Konto> konten = otherManager.ListKonten();

         int importiert = 0;
         foreach (var konto in konten)
         {
            konto.Anfangsbestand = otherManager.CalculateCurrentKontostand(konto);
            _kassenManager.AddKonto(konto);
            importiert++;
         }

         return importiert;
      }
   }
}
