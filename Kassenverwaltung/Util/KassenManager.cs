using Kassenverwaltung.Database;
using Kassenverwaltung.Database.Core;
using Kassenverwaltung.Database.Models;
using System.Globalization;

namespace Kassenverwaltung.Util
{
   public class KassenManager
   {
      private KVDatabase _database;

      public KassenManager(string filename)
      {
         _database = new KVDatabase($"Data Source={filename}");
         _database.EnsureExists();
      }

      public bool IstDbLeer()
      {
         int? countKategorien = _database.QueryInt($"select count(*) as kategoriecount from {_database.Kategorien.TableName}", "kategoriecount").FirstOrDefault();
         if (countKategorien >= 1)
         {
            return false;
         }

         int? countKonten = _database.QueryInt($"select count(*) as kontencount from {_database.Konten.TableName}", "kontencount").FirstOrDefault();
         if (countKonten >= 1)
         {
            return false;
         }

         return true;
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

      public decimal CalculateCurrentKontostand(Konto konto)
      {
         IList<Bewegung> bewegungen = ListBewegungen(konto);
         decimal total = konto.Anfangsbestand;
         foreach (var bewegung in bewegungen)
         {
            total += bewegung.Betrag;
         }
         return total;
      }

      public Konto? FindKontoZuBewegung(int iBewegung)
      {
         Bewegung? bewegung = _database.Bewegungen.Select($"{nameof(Bewegung.Id)} = {iBewegung}").FirstOrDefault();
         if (bewegung != null)
         {
            return _database.Konten.Select($"{nameof(Konto.Id)} = {bewegung.iKonto}").FirstOrDefault();
         }

         return null;
      }

      public Bewegung? FindBewegungAm(int iKonto, DateTime datum, decimal betrag)
      {
         string filter = $"{nameof(Bewegung.iKonto)} = {iKonto} " +
            $"and {nameof(Bewegung.Datum)} = '{datum.ToString(DBColumn.DATETIME_FORMAT)}' " +
            $"and {nameof(Bewegung.Betrag)} = {betrag.ToString("0.00", CultureInfo.InvariantCulture)}";
         return _database.Bewegungen.Select(filter).FirstOrDefault();
      }

      public IList<Bewegung> ListBewegungen(Konto konto)
      {
         IList<Bewegung> bewegungen = _database.Bewegungen.Select($"{nameof(Bewegung.iKonto)} = {konto.Id}");
         return bewegungen.OrderBy(b => b.Datum).ToList();
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
         _database.WithOpenedConnection((connection) =>
         {
            using (var command = connection.CreateCommand())
            {
               command.CommandText = $"update {_database.Bewegungen.TableName} " +
               $"set {nameof(Bewegung.iKategorie)} = null " +
               $"where {nameof(Bewegung.iKategorie)} = {deletedKategorie.Id}";

               command.ExecuteNonQuery();
            }
         });

         _database.Kategorien.Delete(deletedKategorie);
      }

      public void AddBewegung(Bewegung newBewegung, Konto zielKonto)
      {
         newBewegung.iKonto = zielKonto.Id;
         _database.Bewegungen.Insert(newBewegung);
      }

      public void AddUmbuchung(Bewegung umbuchung, Konto vonKonto, Konto aufKonto)
      {
         AddBewegung(umbuchung, vonKonto);

         var gegenBuchung = umbuchung.MakeGegenbuchung();
         gegenBuchung.iBewegung = umbuchung.Id;
         AddBewegung(gegenBuchung, aufKonto);

         umbuchung.iBewegung = gegenBuchung.Id;
         _database.Bewegungen.Update(umbuchung);
      }

      public void UpdateBewegung(Bewegung updatedBewegung)
      {
         _database.Bewegungen.Update(updatedBewegung);
      }

      public void UpdateUmbuchung(Bewegung updatedUmbuchung)
      {
         _database.Bewegungen.Update(updatedUmbuchung);

         // gegenbuchung:
         Bewegung? gegenBuchung = _database.Bewegungen.Select($"{nameof(Bewegung.Id)} = {updatedUmbuchung.iBewegung}").FirstOrDefault();
         if (gegenBuchung != null)
         {
            gegenBuchung.Betrag = -updatedUmbuchung.Betrag;
            gegenBuchung.Datum = updatedUmbuchung.Datum;
            gegenBuchung.Verwendung = updatedUmbuchung.Verwendung;
            gegenBuchung.iKategorie = updatedUmbuchung.iKategorie;

            _database.Bewegungen.Update(gegenBuchung);
         }
      }

      public void DeleteBewegung(Bewegung deletedBewegung)
      {
         _database.Bewegungen.Delete(deletedBewegung);
      }

      public void DeleteUmbuchung(Bewegung deletedUmbuchung)
      {
         int? gegenBuchung = deletedUmbuchung.iBewegung;

         deletedUmbuchung.iBewegung = null;
         _database.Bewegungen.Update(deletedUmbuchung);

         if (gegenBuchung != null)
         {
            _database.Bewegungen.Delete($"{nameof(Bewegung.Id)} = {gegenBuchung}");
         }

         _database.Bewegungen.Delete(deletedUmbuchung);
      }

      public IList<Beleg> ListBelege(Bewegung bewegung)
      {
         return _database.Belege.Select($"{nameof(Beleg.iBewegung)} = {bewegung.Id}");
      }

      public void AddBeleg(Bewegung bewegung, Beleg beleg)
      {
         beleg.iBewegung = bewegung.Id;
         _database.Belege.Insert(beleg);
      }

      public void UpdateBeleg(Beleg selectedBeleg)
      {
         _database.Belege.Update(selectedBeleg);
      }

      public void DeleteBeleg(Beleg selectedBeleg)
      {
         _database.Belege.Delete(selectedBeleg);
      }
   }
}
