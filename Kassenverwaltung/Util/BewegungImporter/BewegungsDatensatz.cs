using Kassenverwaltung.Database.Models;

namespace Kassenverwaltung.Util.BewegungImporter
{
   public class BewegungsDatensatz : Bewegung
   {
      public int Referenz { get; set; }
      public bool Import { get; set; }
      public Konto? ZielKonto { get; set; }
      public string? FehlerMeldung { get; set; }
      public bool Fehler => !string.IsNullOrEmpty(FehlerMeldung);
      public string? WarnMeldung { get; set; }
      public bool Warnung => !string.IsNullOrEmpty(WarnMeldung);
   }
}
