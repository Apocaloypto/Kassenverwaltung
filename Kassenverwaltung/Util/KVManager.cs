using Kassenverwaltung.Database;
using Kassenverwaltung.Database.Models;

namespace Kassenverwaltung.Util
{
   public class KVManager
   {
      private KVDatabase _database;

      public KVManager(string filename)
      {
         _database = new KVDatabase($"Data Source={filename}");
         _database.EnsureExists();
      }

      public IList<Konto> ListKonten()
      {
         return _database.Konten.Select();
      }

      public void AddKonto(Konto newKonto)
      {
         _database.Konten.Insert(newKonto);
      }

      public void UpdateKonto(Konto updatedKonto)
      {
         _database.Konten.Update(updatedKonto);
      }

      public void DeleteKonto(Konto deletedKonto)
      {
         // TODO!
         // Alle Bewegungen des Kontos löschen, dann Konto
      }

      public IList<Bewegung> ListBewegungen(Konto konto)
      {
         return _database.Bewegungen.Select($"{nameof(Bewegung.iKonto)} = {konto.Id}");
      }

      public IList<Kategorie> ListKategorien()
      {
         return _database.Kategorien.Select();
      }

      public void AddKategorie(Kategorie newKategorie)
      {
         _database.Kategorien.Insert(newKategorie);
      }

      public void UpdateKategorie(Kategorie updatedKategorie)
      {
         _database.Kategorien.Update(updatedKategorie);
      }

      public void DeleteKategorie(Kategorie deletedKategorie)
      {
         // TODO!
         // Alle Bewegungen, in denen die Kategorie gesetzt ist auf null setzen, dann Kategorie löschen
      }
   }
}
