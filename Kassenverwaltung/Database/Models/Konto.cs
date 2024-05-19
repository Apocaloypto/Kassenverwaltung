namespace Kassenverwaltung.Database.Models
{
   internal class Konto
   {
      public int Id { get; set; }
      public string? Name { get; set; }
      public string? IBAN { get; set; }
      public string? BIC { get; set; }
      public decimal Anfangsbestand { get; set; }
   }
}
