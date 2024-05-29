namespace Kassenverwaltung.Util.Exporter.Formats
{
   public class JhvExporter : IExporter
   {
      private readonly KassenManager _kassenManager;

      public JhvExporter(KassenManager kassenManager)
      {
         _kassenManager = kassenManager;
      }

      public void Export(string filename)
      {
      }
   }
}
