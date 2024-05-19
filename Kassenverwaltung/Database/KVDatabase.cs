using Kassenverwaltung.Database.Core;
using Kassenverwaltung.Database.Models;
using Microsoft.Data.Sqlite;
using System.Reflection;

namespace Kassenverwaltung.Database
{
   internal class KVDatabase : DB
   {
      public DBTable<Konto> Konten { get; }

      private static PropertyInfo PropInfo<T>(string name)
      {
         PropertyInfo? propInfo = typeof(T).GetProperty(name);
         if (propInfo == null)
         {
            throw new InvalidOperationException($"property '{name}' not found in type '{typeof(T).Name}'.");
         }

         return propInfo;
      }

      private static DBColumn MakeColumn<T>(string propertyname, SqliteType sqltype, bool isPrimary = false)
      {
         return new DBColumn(propertyname, PropInfo<T>(propertyname), sqltype, isPrimary);
      }

      public KVDatabase(string connectionString)
         : base(connectionString)
      {
         Konten = new DBTable<Konto>(nameof(Konten), this, new List<DBColumn>()
         {
            MakeColumn<Konto>(nameof(Konto.Id), SqliteType.Integer, true),
            MakeColumn<Konto>(nameof(Konto.Name), SqliteType.Text),
            MakeColumn<Konto>(nameof(Konto.IBAN), SqliteType.Text),
            MakeColumn<Konto>(nameof(Konto.BIC), SqliteType.Text),
            MakeColumn<Konto>(nameof(Konto.Anfangsbestand), SqliteType.Real),
         });
      }

      public void EnsureExists()
      {
         WithOpenedConnection((connection) =>
         {
            Konten.CreateTable(connection);
         });
      }
   }
}
