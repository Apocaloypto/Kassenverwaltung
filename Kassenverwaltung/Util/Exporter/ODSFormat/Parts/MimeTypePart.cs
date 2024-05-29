using System.IO.Compression;
using System.Text;

namespace Kassenverwaltung.Util.Exporter.ODSFormat.Parts
{
   public class MimeTypePart : IPart
   {
      public void ExportToZip(ZipArchive zip, Encoding encoding)
      {
         ZipArchiveEntry entry = zip.CreateEntry("mimetype");
         using (var stream = entry.Open())
         {
            stream.Write(encoding.GetBytes("application/vnd.oasis.opendocument.spreadsheet"));
         }
      }
   }
}
