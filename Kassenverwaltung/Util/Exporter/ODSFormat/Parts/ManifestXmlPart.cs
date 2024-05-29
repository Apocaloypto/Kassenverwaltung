using System.IO.Compression;
using System.Text;
using Kassenverwaltung.Util.Exporter.ODSFormat.XmlHelper;

namespace Kassenverwaltung.Util.Exporter.ODSFormat.Parts
{
   public class ManifestXmlPart : IPart
   {
      private void WriteManifestEntry(XmlNode parentNode, string filename, string mediatype, string? version = null)
      {
         XmlNode thisNode = parentNode.AddNode("manifest:file-entry");
         thisNode.AddAttribute("manifest:full-path", filename);
         if (!string.IsNullOrEmpty(version))
         {
            thisNode.AddAttribute("manifest:version", version);
         }
         thisNode.AddAttribute("manifest:media-type", mediatype);
      }

      private Xml CreateXml()
      {
         var xml = new Xml("manifest:manifest");
         xml.RootNode.AddAttribute("xmlns:manifest", "urn:oasis:names:tc:opendocument:xmlns:manifest:1.0");
         xml.RootNode.AddAttribute("manifest:version", "1.3");
         xml.RootNode.AddAttribute("xmlns:loext", "urn:org:documentfoundation:names:experimental:office:xmlns:loext:1.0");

         WriteManifestEntry(xml.RootNode, "/", "application/vnd.oasis.opendocument.spreadsheet", "1.3");
         WriteManifestEntry(xml.RootNode, "manifest.rdf", "application/rdf+xml");
         WriteManifestEntry(xml.RootNode, "meta.xml", "text/xml");
         WriteManifestEntry(xml.RootNode, "content.xml", "text/xml");

         return xml;
      }

      public void ExportToZip(ZipArchive zip, Encoding encoding)
      {
         ZipArchiveEntry entry = zip.CreateEntry("META-INF/manifest.xml");
         using (var stream = entry.Open())
         {
            Xml xml = CreateXml();
            xml.Save(stream, encoding);
         }
      }
   }
}
