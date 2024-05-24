namespace Kassenverwaltung.Util
{
   public class StammdatenImportResult
   {
      public int ImportierteKonten { get; }
      public int ImportierteKategorien { get; }

      public StammdatenImportResult(int importierteKonten, int importierteKategorien)
      {
         ImportierteKonten = importierteKonten;
         ImportierteKategorien = importierteKategorien;
      }

      public override string ToString()
      {
         return $"Es wurden {ImportierteKonten} Konten und {ImportierteKategorien} Kategorien importiert";
      }
   }
}
