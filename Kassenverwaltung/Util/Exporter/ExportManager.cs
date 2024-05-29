using Kassenverwaltung.Util.Exporter.Formats;

namespace Kassenverwaltung.Util.Exporter
{
   public class ExportManager
   {
      private readonly KassenManager _kassenManager;

      public ExportManager(KassenManager kassenManager)
      {
         _kassenManager = kassenManager;
      }

      private IExporter CreateExporter(ExportFormat format)
      {
         switch (format)
         {
            case ExportFormat.JHV:
               return new JhvExporter(_kassenManager);
            case ExportFormat.Kassenpruefung:
               return new KassenPruefungExporter(_kassenManager);
            default:
               throw new InvalidOperationException($"Das Format {format} wird nicht unterstützt!");
         }
      }

      public void Export(ExportFormat format, string filename)
      {
         CreateExporter(format).Export(filename);
      }
   }
}
