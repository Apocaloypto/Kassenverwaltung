namespace Kassenverwaltung.Util.BewegungImporter.Formats
{
   public static class CsvHelper
   {
      private const string VALUE_SEPARATOR = ";";

      private static string Normalize(string value)
      {
         if (value.StartsWith("\"") && value.EndsWith("\""))
         {
            return value.Substring(1, value.Length - 2);
         }
         else
         {
            return value;
         }
      }

      private static CsvDataset ParseLine(string line, string[] headers)
      {
         var values = new Dictionary<string, string>();
         string[] strValues = line.Split(VALUE_SEPARATOR);

         for (int i = 0; i < headers.Length; i++)
         {
            string value = i < strValues.Length ? strValues[i] : "";
            values.Add(Normalize(headers[i]), Normalize(value));
         }

         return new CsvDataset(values);
      }

      public static IList<CsvDataset> ReadDataFromFile(string filename)
      {
         string[] lines = File.ReadAllLines(filename);

         return ParseLines(lines);
      }

      private static IList<CsvDataset> ParseLines(string[] lines)
      {
         string[] headers = lines[0].Split(VALUE_SEPARATOR);
         var retval = new List<CsvDataset>();
         for (int i = 1; i < lines.Length; i++)
         {
            retval.Add(ParseLine(lines[i], headers));
         }
         return retval;
      }

      public static IList<CsvDataset> ReadDataFromString(string csv)
      {
         string[] lines = csv.Split(Environment.NewLine);

         return ParseLines(lines);
      }
   }
}
