namespace Kassenverwaltung.Util.BewegungImporter
{
   public interface IBewegungsImport
   {
      IList<BewegungsDatensatz> GetBewegungsDatensaetze(string filename);
   }
}
