using System.IO.Compression;
using System.Text;

namespace Kassenverwaltung.Util.Exporter.ODSFormat.Parts
{
   public interface IPart
   {
      void ExportToZip(ZipArchive zip, Encoding encoding);
   }
}
