namespace Kassenverwaltung.Util.Exporter
{
   public class ExportManager
   {
      private readonly KassenManager _kassenManager;

      public ExportManager(KassenManager kassenManager)
      {
         _kassenManager = kassenManager;
      }

      public void Export(ExportFormat format, string filename)
      {
      }
   }
}
