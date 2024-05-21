namespace Kassenverwaltung.Database.Models
{
   public class Beleg
   {
      public int Id { get; set; }
      public int iBewegung { get; set; }
      public string? Name { get; set; }
      public byte[]? Blob { get; set; }
      public string? Pfad { get; set; }
   }
}
