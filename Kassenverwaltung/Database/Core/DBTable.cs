using Microsoft.Data.Sqlite;

namespace Kassenverwaltung.Database.Core
{
   public class DBTable<T> where T : class, new()
   {
      private DB Database { get; }
      public string TableName { get; }
      public IList<DBColumn> Columns { get; }
      public DBColumn PrimaryKey => Columns.Single(c => c.IsPrimary);
      public IList<IDBConstraint> Constraints { get; } = new List<IDBConstraint>();
      private string CreationStr
      {
         get
         {
            string columdefs = string.Join(',', Columns.Select(c => c.CreationStr));
            string constraints = string.Join(',', Constraints.Select(c => c.CreationStr));

            string stmt = $"CREATE TABLE {TableName} ({columdefs}";
            if (!string.IsNullOrEmpty(constraints))
            {
               stmt += $", {constraints}";
            }

            stmt += ")";

            return stmt;
         }
      }

      public DBTable(string tableName, DB database, IList<DBColumn> columns)
      {
         TableName = tableName;
         Database = database;
         Columns = columns;
      }

      public void AddForeignKey<T2>(string columnName, DBTable<T2> target) where T2 : class, new()
      {
         DBColumn? col = Columns.FirstOrDefault(c => c.Name == columnName);
         if (col == null)
         {
            throw new InvalidOperationException($"there is no column with the name '{columnName}' in the table '{TableName}'");
         }

         Constraints.Add(new DBConstraint<T, T2>(this, col, target));
      }

      private bool TableExists()
      {
         return Database.WithOpenedConnection((connection) =>
         {
            using (var command = connection.CreateCommand())
            {
               command.CommandText = $"select name from sqlite_master where type='table' and name='{TableName}'";
               using (var reader = command.ExecuteReader())
               {
                  return reader.HasRows;
               }
            }
         });
      }

      public void CreateTable(SqliteConnection connection)
      {
         if (!TableExists())
         {
            using (var command = connection.CreateCommand())
            {
               command.CommandText = CreationStr;
               command.ExecuteNonQuery();
            }
         }
      }

      private static string ColumnAsParam(DBColumn col)
      {
         return $"@{col.Name}";
      }

      public void Insert(T obj)
      {
         var colsToWrite = Columns.Where(c => !c.IsPrimary && c.ColumnHasValue(obj));

         string insertstmt = $"INSERT INTO {TableName} " +
            $"({string.Join(',', colsToWrite.Select(c => c.Name))}) " +
            $"values " +
            $"({string.Join(',', colsToWrite.Select(c => ColumnAsParam(c)))})";

         Database.WithOpenedConnection((connection) =>
         {
            using (var command = connection.CreateCommand())
            {
               command.CommandText = insertstmt;
               foreach (var col in colsToWrite)
               {
                  var sqlparam = new SqliteParameter(ColumnAsParam(col), col.SqliteType);
                  sqlparam.Value = col.GetValue(obj);

                  command.Parameters.Add(sqlparam);
               }

               command.ExecuteNonQuery();
            }

            using (var command = connection.CreateCommand())
            {
               command.CommandText = @"select last_insert_rowid()";
               long? lastId = (long?)command.ExecuteScalar();
               if (lastId.HasValue)
               {
                  int lastIdReal = (int)lastId.Value;

                  PrimaryKey.SetValue(obj, lastIdReal);
               }
            }
         });
      }

      public void Update(T obj, HashSet<string>? columnNamesToUpdate = null)
      {
         var colsToUpdate = Columns.Where(c => !c.IsPrimary && ColInList(c));
         if (!colsToUpdate.Any())
         {
            return;
         }

         string updatestmt = $"UPDATE {TableName} " +
            $"SET {string.Join(',', colsToUpdate.Select(c => $"{c.Name} = {ColumnAsParam(c)}"))} " +
            $"WHERE {PrimaryKey.Name} = {ColumnAsParam(PrimaryKey)}";

         Database.WithOpenedConnection((connection) =>
         {
            using (var command = connection.CreateCommand())
            {
               command.CommandText = updatestmt;
               foreach (var col in colsToUpdate)
               {
                  var sqlparam = new SqliteParameter(ColumnAsParam(col), col.SqliteType);
                  object? value = col.GetValue(obj);
                  if (value != null)
                  {
                     sqlparam.Value = value;
                  }
                  else
                  {
                     sqlparam.Value = DBNull.Value;
                  }

                  command.Parameters.Add(sqlparam);
               }

               var keyparam = new SqliteParameter(ColumnAsParam(PrimaryKey), PrimaryKey.SqliteType);
               keyparam.Value = PrimaryKey.GetValue(obj);

               command.Parameters.Add(keyparam);

               command.ExecuteNonQuery();
            }
         });

         bool ColInList(DBColumn col)
         {
            return columnNamesToUpdate == null || !columnNamesToUpdate.Any() || columnNamesToUpdate.Contains(col.Name);
         }
      }

      public IList<T> Select(string? filter = null, uint? maxresults = null, uint? skipresults = null)
      {
         string selectstmt = $"SELECT {string.Join(',', Columns.Select(c => c.Name))} " +
            $"FROM {TableName} ";

         if (!string.IsNullOrEmpty(filter))
         {
            selectstmt += $" WHERE {filter}";
         }

         if (maxresults.HasValue)
         {
            selectstmt += $" LIMIT {maxresults.Value}";
         }

         if (skipresults.HasValue)
         {
            selectstmt += $" OFFSET {skipresults.Value}";
         }

         return Database.WithOpenedConnection((connection) =>
         {
            using (var command = connection.CreateCommand())
            {
               command.CommandText = selectstmt;

               using (var reader = command.ExecuteReader())
               {
                  var result = new List<T>();

                  while (reader.Read())
                  {
                     var row = new T();

                     foreach (var col in Columns)
                     {
                        col.SetValue(row, reader);
                     }

                     result.Add(row);
                  }

                  return result;
               }
            }
         });
      }

      public void Delete(T obj)
      {
         string deletestmt = $"DELETE FROM {TableName} " +
            $"WHERE {PrimaryKey.Name} = {ColumnAsParam(PrimaryKey)}";

         Database.WithOpenedConnection((connection) =>
         {
            using (var command = connection.CreateCommand())
            {
               command.CommandText = deletestmt;

               var keyparam = new SqliteParameter(ColumnAsParam(PrimaryKey), PrimaryKey.SqliteType);
               keyparam.Value = PrimaryKey.GetValue(obj);

               command.Parameters.Add(keyparam);

               command.ExecuteNonQuery();
            }
         });
      }

      public void Delete(string filter)
      {
         string deletestmt = $"DELETE FROM {TableName} " +
            $"WHERE {filter}";

         Database.WithOpenedConnection((connection) =>
         {
            using (var command = connection.CreateCommand())
            {
               command.CommandText = deletestmt;
               command.ExecuteNonQuery();
            }
         });
      }
   }
}
