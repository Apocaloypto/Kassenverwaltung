using Kassenverwaltung.Database.Core;
using System.Reflection;

namespace Kassenverwaltung.Tests
{
   public class DBColumnTests
   {
      private class DataClass
      {
         public int IntValue { get; set; }
         public int? NullableIntValue { get; set; }
         public decimal FloatValue { get; set; }
         public decimal? NullableFloatValue { get; set; }
         public string? TextValue { get; set; }
         public byte[]? BlobValue { get; set; }
         public DateTime DateTimeValue { get; set; }
         public DateTime? NullableDateTimeValue { get; set; }
      }

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

      [Fact]
      public void DBColumn_GetValue_Int()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.IntValue), DBColumnType.Integer);
         var data = new DataClass
         {
            IntValue = 123,
         };

         // ACT
         object? value = dbColumn.GetValue(data);

         // ASSERT
         Assert.Equal(value, 123);
      }

      [Fact]
      public void DBColumn_GetValue_NullableInt_IntSet()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.NullableIntValue), DBColumnType.Integer);
         var data = new DataClass
         {
            NullableIntValue = 456,
         };

         // ACT
         object? value = dbColumn.GetValue(data);

         // ASSERT
         Assert.Equal(value, 456);
      }

      [Fact]
      public void DBColumn_GetValue_NullableInt_Null()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.NullableIntValue), DBColumnType.Integer);
         var data = new DataClass
         {
            NullableIntValue = null,
         };

         // ACT
         object? value = dbColumn.GetValue(data);

         // ASSERT
         Assert.Null(value);
      }

      [Fact]
      public void DBColumn_GetValue_Float()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.FloatValue), DBColumnType.Float);
         var data = new DataClass
         {
            FloatValue = 123.56m,
         };

         // ACT
         object? value = dbColumn.GetValue(data);

         // ASSERT
         Assert.Equal(value, 123.56m);
      }

      [Fact]
      public void DBColumn_GetValue_NullableFloat_FloatSet()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.NullableFloatValue), DBColumnType.Float);
         var data = new DataClass
         {
            NullableFloatValue = 123.56m,
         };

         // ACT
         object? value = dbColumn.GetValue(data);

         // ASSERT
         Assert.Equal(value, 123.56m);
      }

      [Fact]
      public void DBColumn_GetValue_NullableFloat_Null()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.NullableFloatValue), DBColumnType.Float);
         var data = new DataClass
         {
            NullableFloatValue = null,
         };

         // ACT
         object? value = dbColumn.GetValue(data);

         // ASSERT
         Assert.Null(value);
      }

      [Fact]
      public void DBColumn_GetValue_String_StringSet()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.TextValue), DBColumnType.Text);
         var data = new DataClass
         {
            TextValue = "Hallo, Welt",
         };

         // ACT
         object? value = dbColumn.GetValue(data);

         // ASSERT
         Assert.Equal(value, "Hallo, Welt");
      }

      [Fact]
      public void DBColumn_GetValue_String_Null()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.TextValue), DBColumnType.Text);
         var data = new DataClass
         {
            TextValue = null,
         };

         // ACT
         object? value = dbColumn.GetValue(data);

         // ASSERT
         Assert.Null(value);
      }

      [Fact]
      public void DBColumn_GetValue_BlobValue_BlobSet()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.BlobValue), DBColumnType.Blob);
         var data = new DataClass
         {
            BlobValue = [1, 2, 3, 4],
         };

         // ACT
         object? value = dbColumn.GetValue(data);

         // ASSERT
         Assert.Equal(value, new byte[] { 1, 2, 3, 4 });
      }

      [Fact]
      public void DBColumn_GetValue_BlobValue_Null()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.BlobValue), DBColumnType.Blob);
         var data = new DataClass
         {
            BlobValue = null,
         };

         // ACT
         object? value = dbColumn.GetValue(data);

         // ASSERT
         Assert.Null(value);
      }

      [Fact]
      public void DBColumn_GetValue_DateTime()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.DateTimeValue), DBColumnType.DateTime);
         var data = new DataClass
         {
            DateTimeValue = new DateTime(2024, 5, 6, 7, 8, 9, 123),
         };

         // ACT
         object? value = dbColumn.GetValue(data);

         // ASSERT
         Assert.Equal(value, "2024-05-06T07:08:09");
      }

      [Fact]
      public void DBColumn_GetValue_NullableDateTime_DateTimeSet()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.NullableDateTimeValue), DBColumnType.DateTime);
         var data = new DataClass
         {
            NullableDateTimeValue = new DateTime(2024, 4, 5, 7, 8, 11, 123),
         };

         // ACT
         object? value = dbColumn.GetValue(data);

         // ASSERT
         Assert.Equal(value, "2024-04-05T07:08:11");
      }

      [Fact]
      public void DBColumn_GetValue_NullableDateTime_Null()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.NullableDateTimeValue), DBColumnType.DateTime);
         var data = new DataClass
         {
            NullableDateTimeValue = null,
         };

         // ACT
         object? value = dbColumn.GetValue(data);

         // ASSERT
         Assert.Null(value);
      }

      [Fact]
      public void DBColumn_SetValue_Int()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.IntValue), DBColumnType.Integer);
         var data = new DataClass();
         object? value = 123;

         // ACT
         dbColumn.SetValue(data, value);

         // ASSERT
         Assert.Equal(123, data.IntValue);
      }

      [Fact]
      public void DBColumn_SetValue_NullableInt_IntSet()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.NullableIntValue), DBColumnType.Integer);
         var data = new DataClass();
         object? value = 456;

         // ACT
         dbColumn.SetValue(data, value);

         // ASSERT
         Assert.Equal(456, data.NullableIntValue);
      }

      [Fact]
      public void DBColumn_SetValue_NullableInt_Null()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.NullableIntValue), DBColumnType.Integer);
         var data = new DataClass();
         object? value = null;

         // ACT
         dbColumn.SetValue(data, value);

         // ASSERT
         Assert.Null(data.NullableIntValue);
      }

      [Fact]
      public void DBColumn_SetValue_Float()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.FloatValue), DBColumnType.Float);
         var data = new DataClass();
         object? value = 123.56m;

         // ACT
         dbColumn.SetValue(data, value);

         // ASSERT
         Assert.Equal(123.56m, data.FloatValue);
      }

      [Fact]
      public void DBColumn_SetValue_NullableFloat_FloatSet()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.NullableFloatValue), DBColumnType.Float);
         var data = new DataClass();
         object? value = 123.56m;

         // ACT
         dbColumn.SetValue(data, value);

         // ASSERT
         Assert.Equal(123.56m, data.NullableFloatValue);
      }

      [Fact]
      public void DBColumn_SetValue_NullableFloat_Null()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.NullableFloatValue), DBColumnType.Float);
         var data = new DataClass();
         object? value = null;

         // ACT
         dbColumn.SetValue(data, value);

         // ASSERT
         Assert.Null(data.NullableFloatValue);
      }

      [Fact]
      public void DBColumn_SetValue_String_StringSet()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.TextValue), DBColumnType.Text);
         var data = new DataClass();
         object? value = "Hallo, Welt";

         // ACT
         dbColumn.SetValue(data, value);

         // ASSERT
         Assert.Equal("Hallo, Welt", data.TextValue);
      }

      [Fact]
      public void DBColumn_SetValue_String_Null()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.TextValue), DBColumnType.Text);
         var data = new DataClass();
         object? value = null;

         // ACT
         dbColumn.SetValue(data, value);

         // ASSERT
         Assert.Null(data.TextValue);
      }

      [Fact]
      public void DBColumn_SetValue_BlobValue_BlobSet()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.BlobValue), DBColumnType.Blob);
         var data = new DataClass();
         object? value = new byte[] { 1, 2, 3, 4 };

         // ACT
         dbColumn.SetValue(data, value);

         // ASSERT
         Assert.Equal(data.BlobValue, [1, 2, 3, 4]);
      }

      [Fact]
      public void DBColumn_SetValue_BlobValue_Null()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.BlobValue), DBColumnType.Blob);
         var data = new DataClass();
         object? value = null;

         // ACT
         dbColumn.SetValue(data, value);

         // ASSERT
         Assert.Null(data.BlobValue);
      }

      [Fact]
      public void DBColumn_SetValue_DateTime()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.DateTimeValue), DBColumnType.DateTime);
         var data = new DataClass();
         object? value = "2024-05-06T07:08:09";

         // ACT
         dbColumn.SetValue(data, value);

         // ASSERT
         Assert.Equal(data.DateTimeValue, new DateTime(2024, 5, 6, 7, 8, 9));
      }

      [Fact]
      public void DBColumn_SetValue_NullableDateTime_DateTimeSet()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.NullableDateTimeValue), DBColumnType.DateTime);
         var data = new DataClass();
         object? value = "2024-04-05T07:08:11";

         // ACT
         dbColumn.SetValue(data, value);

         // ASSERT
         Assert.Equal(data.NullableDateTimeValue, new DateTime(2024, 4, 5, 7, 8, 11));
      }

      [Fact]
      public void DBColumn_SetValue_NullableDateTime_Null()
      {
         // ARRANGE
         DBColumn dbColumn = MakeColumn<DataClass>(nameof(DataClass.NullableDateTimeValue), DBColumnType.DateTime);
         var data = new DataClass();
         object? value = null;

         // ACT
         dbColumn.SetValue(data, value);

         // ASSERT
         Assert.Null(data.NullableDateTimeValue);
      }
   }
}
