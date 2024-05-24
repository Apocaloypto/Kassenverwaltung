using System.ComponentModel.DataAnnotations;

namespace Kassenverwaltung.Database.Models
{
   public class Bewegung
   {
      public enum ArtEnum
      {
         [Display(Name = "Ein- / Auszahlung")]
         EinAuszahlung,

         [Display(Name = "Umbuchung")]
         Umbuchung
      }

      public int Id { get; set; }
      public int iKonto { get; set; }
      public int? iKategorie { get; set; }
      public int? iBewegung { get; set; } // Bei Umbuchungen: Schwesterbewegung
      public DateTime Datum { get; set; }
      public decimal Betrag { get; set; }
      public string? Verwendung { get; set; }
      public ArtEnum Art
      {
         get
         {
            if (iBewegung.HasValue)
            {
               return ArtEnum.Umbuchung;
            }
            else
            {
               return ArtEnum.EinAuszahlung;
            }
         }
      }

      public Bewegung MakeGegenbuchung()
      {
         return new Bewegung
         {
            iKategorie = iKategorie,
            Datum = Datum,
            Betrag = -Betrag,
            Verwendung = Verwendung
         };
      }
   }
}
