namespace Kassenverwaltung.Util.BewegungImporter
{
   public class ImportManager
   {
      private readonly KassenManager _kassenManager;

      public ImportManager(KassenManager kassenManager)
      {
         _kassenManager = kassenManager;
      }

      public void ImportBewegungsDatensaetze(IList<BewegungsDatensatz> datensaetze)
      {
      }
   }
}
