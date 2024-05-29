using System.IO.Compression;
using System.Text;
using Kassenverwaltung.Util.Exporter.ODSFormat.Parts;

namespace Kassenverwaltung.Util.Exporter.ODSFormat
{
    public class Spreadsheet
   {
      private readonly Encoding ENCODING = Encoding.UTF8;

      private readonly ManifestXmlPart _manifestXmlPart;
      private readonly ManifestRdfPart _manifestRdfPart;
      private readonly MimeTypePart _mimeTypePart;
      public ContentPart Content { get; }

      public Spreadsheet()
      {
         _manifestXmlPart = new ManifestXmlPart();
         _manifestRdfPart = new ManifestRdfPart();
         _mimeTypePart = new MimeTypePart();
         Content = new ContentPart();
      }

      public void Save(string filename)
      {
         using (var fileStream = File.Create(filename))
         {
            using (var zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create))
            {
               _manifestXmlPart.ExportToZip(zipArchive, ENCODING);
               _manifestRdfPart.ExportToZip(zipArchive, ENCODING);
               _mimeTypePart.ExportToZip(zipArchive, ENCODING);
               Content.ExportToZip(zipArchive, ENCODING);
            }
         }
      }
   }
}
