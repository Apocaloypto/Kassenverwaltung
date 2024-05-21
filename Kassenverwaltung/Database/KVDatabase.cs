using Kassenverwaltung.Database.Core;
using Kassenverwaltung.Database.Models;
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

      private static DBColumn MakeColumn<T>(string propertyname, DBColumnType columnType, bool isPrimary = false)
      {
         return new DBColumn(propertyname, PropInfo<T>(propertyname), columnType, isPrimary);
      }

      public KVDatabase(string connectionString)
         : base(connectionString)
      {
         Konten = new DBTable<Konto>(nameof(Konten), this, new List<DBColumn>()
         {
            MakeColumn<Konto>(nameof(Konto.Id), DBColumnType.Integer, true),
            MakeColumn<Konto>(nameof(Konto.Name), DBColumnType.Text),
            MakeColumn<Konto>(nameof(Konto.IBAN), DBColumnType.Text),
            MakeColumn<Konto>(nameof(Konto.BIC), DBColumnType.Text),
            MakeColumn<Konto>(nameof(Konto.Anfangsbestand), DBColumnType.Float),
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
