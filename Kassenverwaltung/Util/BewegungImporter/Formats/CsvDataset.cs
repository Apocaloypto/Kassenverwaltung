namespace Kassenverwaltung.Util.BewegungImporter.Formats
{
   public class CsvDataset
   {
      public IDictionary<string, string> Values { get; }

      public CsvDataset(IDictionary<string, string> values)
      {
         Values = values;
      }
   }
}
