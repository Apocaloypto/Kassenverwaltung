using Kassenverwaltung.Util.BewegungImporter.Formats;

namespace Kassenverwaltung.Util.BewegungImporter
{
   public static class ImporterFactory
   {
      public static IBewegungsImport CreateImporter(ImportFormat format, KassenManager kassenManager)
      {
         switch (format)
         {
            case ImportFormat.CsvCamtv2:
               return new CsvCamtv2(kassenManager);
            default:
               throw new InvalidOperationException($"Format nicht unterstützt: {format.GetValueName()}");
         }
      }
   }
}
