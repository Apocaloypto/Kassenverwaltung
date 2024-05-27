using Kassenverwaltung.Util.BewegungImporter.Formats;

namespace Kassenverwaltung.Tests
{
   public class CsvHelperTests
   {
      [Fact]
      public void ReadDataFromString_Success()
      {
         // ARRANGE
         string csv = @"""Auftragskonto"";""Verwendungszweck"";""Mandat""
""DE37476521312321321"";""24.05.24"";
""DE13123232312312312"";""25.04.24"";""KARTENZAHLUNG""
""DE78978978987879879"";""01.03.24"";""DAUERAUFTRAG""
"""";"""";""""";

         // ACT
         IList<CsvDataset> csvDatasets = CsvHelper.ReadDataFromString(csv);

         // ASSERT
         Assert.Equal(4, csvDatasets.Count);
         
         Assert.Equal("DE37476521312321321", csvDatasets[0].Values["Auftragskonto"]);
         Assert.Equal("24.05.24", csvDatasets[0].Values["Verwendungszweck"]);
         Assert.Equal("", csvDatasets[0].Values["Mandat"]);

         Assert.Equal("DE13123232312312312", csvDatasets[1].Values["Auftragskonto"]);
         Assert.Equal("25.04.24", csvDatasets[1].Values["Verwendungszweck"]);
         Assert.Equal("KARTENZAHLUNG", csvDatasets[1].Values["Mandat"]);

         Assert.Equal("DE78978978987879879", csvDatasets[2].Values["Auftragskonto"]);
         Assert.Equal("01.03.24", csvDatasets[2].Values["Verwendungszweck"]);
         Assert.Equal("DAUERAUFTRAG", csvDatasets[2].Values["Mandat"]);

         Assert.Equal("", csvDatasets[3].Values["Auftragskonto"]);
         Assert.Equal("", csvDatasets[3].Values["Verwendungszweck"]);
         Assert.Equal("", csvDatasets[3].Values["Mandat"]);
      }
   }
}
