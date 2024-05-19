using Microsoft.Data.Sqlite;
using System.Reflection;

namespace Kassenverwaltung.Database.Core
{
   internal class DBColumn
   {
      public string Name { get; }
      public SqliteType SqlType { get; }
      public bool IsPrimary { get; }
      public PropertyInfo PropertyInfo { get; }

      private string SqlTypeStr
      {
         get
         {
            switch (SqlType)
            {
               case SqliteType.Integer:
                  return "INTEGER";
               case SqliteType.Real:
                  return "REAL";
               case SqliteType.Text:
                  return "TEXT";
               case SqliteType.Blob:
                  return "BLOB";
               default:
                  throw new InvalidOperationException($"the sql-type is unknown ({nameof(SqlType)})");
            }
         }
      }

      public string CreationStr
      {
         get
         {
            string min = $"{Name} {SqlTypeStr}";
            if (IsPrimary)
            {
               min += " PRIMARY KEY";
            }

            return min;
         }
      }

      public DBColumn(string name, PropertyInfo propertyInfo, SqliteType sqlType, bool isPrimary)
      {
         Name = name;
         PropertyInfo = propertyInfo;
         SqlType = sqlType;
         IsPrimary = isPrimary;
      }

      public void SetValue(object obj, SqliteDataReader reader)
      {
         if (reader[Name] != null && !Convert.IsDBNull(reader[Name]))
         {
            switch (SqlType)
            {
               case SqliteType.Integer:
                  {
                     long val = (long)reader[Name];
                     int realval = (int)val;
                     PropertyInfo.SetValue(obj, realval);
                  }
                  break;
               case SqliteType.Real:
                  {
                     float val = (float)reader[Name];
                     PropertyInfo.SetValue(obj, val);
                  }
                  break;
               case SqliteType.Text:
                  {
                     string val = (string)reader[Name];
                     PropertyInfo.SetValue(obj, val);
                  }
                  break;
               case SqliteType.Blob:
                  {
                     byte[] val = (byte[])reader[Name];
                     PropertyInfo.SetValue(obj, val);
                  }
                  break;
            }
         }
      }
   }
}
