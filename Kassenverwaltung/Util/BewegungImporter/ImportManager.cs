namespace Kassenverwaltung.Util.BewegungImporter
{
   public class ImportManager
   {
      private readonly KVManager _dataManager;

      public ImportManager(KVManager dataManager)
      {
         _dataManager = dataManager;
      }

      public void ImportBewegungsDatensaetze(IList<BewegungsDatensatz> datensaetze)
      {
      }
   }
}
