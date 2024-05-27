using Microsoft.Data.Sqlite;
using System.Reflection;

namespace Kassenverwaltung.Database.Core
{
   public class DBColumn
   {
      public const string DATETIME_FORMAT = "yyyy-MM-ddTHH:mm:ss";

      public string Name { get; }
      public bool IsPrimary { get; }
      private PropertyInfo PropertyInfo { get; }
      private DBColumnType ColumnType { get; }

      private string SqlTypeStr
      {
         get
         {
            switch (SqliteType)
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
                  throw new InvalidOperationException($"the sql-type is unknown ({nameof(SqliteType)})");
            }
         }
      }

      public SqliteType SqliteType
      {
         get
         {
            switch (ColumnType)
            {
               case DBColumnType.Integer:
                  return SqliteType.Integer;
               case DBColumnType.Float:
                  return SqliteType.Real;
               case DBColumnType.Text:
                  return SqliteType.Text;
               case DBColumnType.Blob:
                  return SqliteType.Blob;
               case DBColumnType.DateTime:
                  return SqliteType.Text;
               default:
                  throw new InvalidOperationException($"the column-type {ColumnType} is not supported!");
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

      public DBColumn(string name, PropertyInfo propertyInfo, DBColumnType columnType, bool isPrimary)
      {
         Name = name;
         PropertyInfo = propertyInfo;
         ColumnType = columnType;
         IsPrimary = isPrimary;
      }

      public bool ColumnHasValue(object obj)
      {
         bool isNullabe = Nullable.GetUnderlyingType(PropertyInfo.PropertyType) != null;
         if (!isNullabe)
         {
            return true;
         }

         bool hasValue = PropertyInfo.GetValue(obj) != null;
         return hasValue;
      }

      public void SetValue(object obj, SqliteDataReader reader)
      {
         if (reader[Name] != null && !Convert.IsDBNull(reader[Name]))
         {
            SetValue(obj, reader[Name]);
         }
      }

      public void SetValue(object obj, object? value)
      {
         switch (ColumnType)
         {
            case DBColumnType.Integer:
               {
                  try
                  {
                     long? val = (long?)value;
                     if (val.HasValue)
                     {
                        int realval = (int)val.Value;
                        PropertyInfo.SetValue(obj, realval);
                     }
                     else
                     {
                        PropertyInfo.SetValue(obj, null);
                     }
                  }
                  catch (InvalidCastException)
                  {
                     int? val = (int?)value;
                     PropertyInfo.SetValue(obj, val);
                  }
               }
               break;
            case DBColumnType.Float:
               {
                  try
                  {
                     float? val = (float?)value;
                     PropertyInfo.SetValue(obj, val);
                  }
                  catch (InvalidCastException)
                  {
                     try
                     {
                        double? val = (double?)value;
                        decimal? realValue = (decimal?)val;
                        PropertyInfo.SetValue(obj, realValue);
                     }
                     catch (InvalidCastException)
                     {
                        decimal? val = (decimal?)value;
                        PropertyInfo.SetValue(obj, val);
                     }
                  }
               }
               break;
            case DBColumnType.Text:
               {
                  string? val = (string?)value;
                  PropertyInfo.SetValue(obj, val);
               }
               break;
            case DBColumnType.Blob:
               {
                  byte[]? val = (byte[]?)value;
                  PropertyInfo.SetValue(obj, val);
               }
               break;
            case DBColumnType.DateTime:
               {
                  string? val = (string?)value;
                  if (!string.IsNullOrEmpty(val))
                  {
                     DateTime result = DateTime.ParseExact(val, DATETIME_FORMAT, null);
                     PropertyInfo.SetValue(obj, result);
                  }
                  else
                  {
                     PropertyInfo.SetValue(obj, null);
                  }
               }
               break;
            default:
               throw new InvalidOperationException($"DB-Columntype {ColumnType} not supported ({nameof(SetValue)})!");
         }
      }

      public object? GetValue(object obj)
      {
         switch (ColumnType)
         {
            case DBColumnType.Integer:
            case DBColumnType.Float:
            case DBColumnType.Text:
            case DBColumnType.Blob:
               return PropertyInfo.GetValue(obj);
            case DBColumnType.DateTime:
               DateTime? dt = (DateTime?)PropertyInfo.GetValue(obj);
               if (dt.HasValue)
               {
                  return dt.Value.ToString(DATETIME_FORMAT);
               }
               else
               {
                  return null;
               }
            default:
               throw new InvalidOperationException($"DB_Columntype {ColumnType} not supported ({nameof(GetValue)})");
         }
      }
   }
}
