namespace Kassenverwaltung.Database.Models
{
   public class Bewegung
   {
      public int Id { get; set; }
      public int iKonto { get; set; }
      public int? iKategorie { get; set; }
      public int? iBewegung { get; set; } // Bei Umbuchungen: Schwesterbewegung
      public DateTime Datum { get; set; }
      public decimal Betrag { get; set; }
      public string? Verwendung { get; set; }
   }
}
