using Kassenverwaltung.Util.BewegungImporter.Formats;

namespace Kassenverwaltung.Util.BewegungImporter
{
   public static class ImporterFactory
   {
      public static IBewegungsImport CreateImporter(ImportFormat format, KVManager dataManager)
      {
         switch (format)
         {
            case ImportFormat.CsvCamtv2:
               return new CsvCamtv2(dataManager);
            default:
               throw new InvalidOperationException($"Format nicht unterstützt: {format.GetValueName()}");
         }
      }
   }
}
