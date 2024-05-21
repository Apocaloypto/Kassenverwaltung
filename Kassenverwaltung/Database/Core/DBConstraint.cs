using Microsoft.Data.Sqlite;

namespace Kassenverwaltung.Database.Core
{
   public class DBConstraint<T1, T2> : IDBConstraint where T1 : class, new() where T2 : class, new()
   {
      public DBTable<T1> SourceTable { get; }
      public DBColumn SourceColumn { get; }
      public DBTable<T2> TargetTable { get; }

      public string CreationStr
      {
         get
         {
            if (TargetTable.PrimaryKey == null)
            {
               throw new InvalidOperationException($"the targettable '{TargetTable.TableName}' does not have a primary key!");
            }

            if (SourceColumn.SqliteType != SqliteType.Integer)
            {
               throw new InvalidOperationException($"the sourcecolumn '{SourceColumn.Name}' has an invalid datatype (only INTEGER allowed)");
            }

            return $"FOREIGN KEY ({SourceColumn.Name}) REFERENCES {TargetTable.TableName}({TargetTable.PrimaryKey.Name})";
         }
      }

      public DBConstraint(DBTable<T1> sourceTable, DBColumn sourceColumn, DBTable<T2> targetTable)
      {
         SourceTable = sourceTable;
         SourceColumn = sourceColumn;
         TargetTable = targetTable;
      }
   }
}
