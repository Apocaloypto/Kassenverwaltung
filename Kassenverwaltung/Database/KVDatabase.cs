using Kassenverwaltung.Database.Core;
using Kassenverwaltung.Database.Models;
using System.Reflection;

namespace Kassenverwaltung.Database
{
   internal class KVDatabase : DB
   {
      public DBTable<Konto> Konten { get; }
      public DBTable<Kategorie> Kategorien { get; }
      public DBTable<Bewegung> Bewegungen { get; }
      public DBTable<Beleg> Belege { get; }

      private static PropertyInfo PropInfo<T>(string name)
      {
         PropertyInfo? propInfo = typeof(T).GetProperty(name);
         if (propInfo == null)
         {
            throw new InvalidOperationException($"property '{name}' not found in type '{typeof(T).Name}'.");
         }

         return propInfo;
      }

      private static DBColumn MakeColumn<T>(string propertyname, DBColumnType columnType, bool isPrimary = false)
      {
         return new DBColumn(propertyname, PropInfo<T>(propertyname), columnType, isPrimary);
      }

      public KVDatabase(string connectionString)
         : base(connectionString)
      {
         #region Tables
         Konten = new DBTable<Konto>(nameof(Konten), this, new List<DBColumn>()
         {
            MakeColumn<Konto>(nameof(Konto.Id), DBColumnType.Integer, true),
            MakeColumn<Konto>(nameof(Konto.Name), DBColumnType.Text),
            MakeColumn<Konto>(nameof(Konto.IBAN), DBColumnType.Text),
            MakeColumn<Konto>(nameof(Konto.BIC), DBColumnType.Text),
            MakeColumn<Konto>(nameof(Konto.Anfangsbestand), DBColumnType.Float),
         });

         Kategorien = new DBTable<Kategorie>(nameof(Kategorien), this, new List<DBColumn>()
         {
            MakeColumn<Kategorie>(nameof(Kategorie.Id), DBColumnType.Integer, true),
            MakeColumn<Kategorie>(nameof(Kategorie.Name), DBColumnType.Text),
         });

         Bewegungen = new DBTable<Bewegung>(nameof(Bewegungen), this, new List<DBColumn>()
         {
            MakeColumn<Bewegung>(nameof(Bewegung.Id), DBColumnType.Integer, true),
            MakeColumn<Bewegung>(nameof(Bewegung.iKonto), DBColumnType.Integer),
            MakeColumn<Bewegung>(nameof(Bewegung.iKategorie), DBColumnType.Integer),
            MakeColumn<Bewegung>(nameof(Bewegung.iBewegung), DBColumnType.Integer),
            MakeColumn<Bewegung>(nameof(Bewegung.Datum), DBColumnType.DateTime),
            MakeColumn<Bewegung>(nameof(Bewegung.Betrag), DBColumnType.Float),
            MakeColumn<Bewegung>(nameof(Bewegung.Verwendung), DBColumnType.Text),
         });

         Belege = new DBTable<Beleg>(nameof(Belege), this, new List<DBColumn>()
         {
            MakeColumn<Beleg>(nameof(Beleg.Id), DBColumnType.Integer, true),
            MakeColumn<Beleg>(nameof(Beleg.iBewegung), DBColumnType.Integer),
            MakeColumn<Beleg>(nameof(Beleg.Name), DBColumnType.Text),
            MakeColumn<Beleg>(nameof(Beleg.Blob), DBColumnType.Blob),
            MakeColumn<Beleg>(nameof(Beleg.Pfad), DBColumnType.Text),
         });
         #endregion

         #region Constraints
         Bewegungen.AddForeignKey(nameof(Bewegung.iKonto), Konten);
         Bewegungen.AddForeignKey(nameof(Bewegung.iKategorie), Kategorien);
         Bewegungen.AddForeignKey(nameof(Bewegung.iBewegung), Bewegungen);

         Belege.AddForeignKey(nameof(Beleg.iBewegung), Bewegungen);
         #endregion
      }

      public void EnsureExists()
      {
         WithOpenedConnection((connection) =>
         {
            Konten.CreateTable(connection);
            Kategorien.CreateTable(connection);
            Bewegungen.CreateTable(connection);
            Belege.CreateTable(connection);
         });
      }
   }
}
