using System.IO.Compression;
using System.Text;
using Kassenverwaltung.Util.Exporter.ODSFormat.XmlHelper;

namespace Kassenverwaltung.Util.Exporter.ODSFormat.Parts
{
   public class ManifestRdfPart : IPart
   {
      private void AddTypeNode(XmlNode parent, string resource)
      {
         var inner = parent.AddNode("rdf:type");
         inner.AddAttribute("rdf:resource", resource);
      }

      private XmlNode AddDescription(XmlNode parent, string about)
      {
         var inner = parent.AddNode("rdf:Description");
         inner.AddAttribute("rdf:about", about);
         return inner;
      }

      private void AddHasPartNode(XmlNode parent, string resource)
      {
         var inner = parent.AddNode("ns0:hasPart");
         inner.AddAttribute("xmlns:ns0", "http://docs.oasis-open.org/ns/office/1.2/meta/pkg#");
         inner.AddAttribute("rdf:resource", resource);
      }

      private Xml CreateXml()
      {
         var xml = new Xml("rdf:RDF");
         xml.RootNode.AddAttribute("xmlns:rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");

         var firstNode = AddDescription(xml.RootNode, "content.xml");
         AddTypeNode(firstNode, "http://docs.oasis-open.org/ns/office/1.2/meta/odf#ContentFile");

         var secondNode = AddDescription(xml.RootNode, "");
         AddHasPartNode(secondNode, "content.xml");

         var thirdNode = AddDescription(xml.RootNode, "");
         AddTypeNode(thirdNode, "http://docs.oasis-open.org/ns/office/1.2/meta/pkg#Document");

         return xml;
      }

      public void ExportToZip(ZipArchive zip, Encoding encoding)
      {
         ZipArchiveEntry entry = zip.CreateEntry("manifest.rdf");
         using (var stream = entry.Open())
         {
            Xml xml = CreateXml();
            xml.Save(stream, encoding);
         }
      }
   }
}
