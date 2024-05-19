using Microsoft.Data.Sqlite;

namespace Kassenverwaltung.Database.Core
{
   internal class DB
   {
      private string _connectionString;

      public DB(string connectionString)
      {
         _connectionString = connectionString;
      }

      public void WithOpenedConnection(Action<SqliteConnection> @do)
      {
         using (var connection = new SqliteConnection(_connectionString))
         {
            connection.Open();

            @do.Invoke(connection);
         }
      }

      public T WithOpenedConnection<T>(Func<SqliteConnection, T> @do)
      {
         using (var connection = new SqliteConnection(_connectionString))
         {
            connection.Open();

            return @do.Invoke(connection);
         }
      }

      private IList<T> QueryInternal<T>(string stmt, string colName, Func<object, T> converter)
      {
         return WithOpenedConnection((connection) =>
         {
            using (var command = connection.CreateCommand())
            {
               command.CommandText = stmt;

               using (var reader = command.ExecuteReader())
               {
                  var result = new List<T>();

                  while (reader.Read())
                  {
                     result.Add(converter.Invoke(reader[colName]));
                  }

                  return result;
               }
            }
         });
      }

      public IList<int> QueryInt(string stmt, string colName)
      {
         return QueryInternal(stmt, colName, (read) =>
         {
            long val = (long)read;
            return (int)val;
         });
      }

      public IList<string> QueryString(string stmt, string colName)
      {
         return QueryInternal(stmt, colName, (read) =>
         {
            return (string)read;
         });
      }
   }
}
