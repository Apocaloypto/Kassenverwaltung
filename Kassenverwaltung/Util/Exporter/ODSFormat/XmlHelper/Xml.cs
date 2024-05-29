using System.Text;

namespace Kassenverwaltung.Util.Exporter.ODSFormat.XmlHelper
{
   public class Xml
   {
      public XmlNode RootNode { get; }

      public Xml(string rootNode)
      {
         RootNode = new XmlNode(rootNode);
      }

      private void WriteHeader(Stream stream, Encoding encoding)
      {
         string fileHeader = $"<?xml version=\"1.0\" encoding=\"{encoding.HeaderName}\"?>";
         stream.Write(encoding.GetBytes(fileHeader));
      }

      public void Save(Stream stream, Encoding encoding)
      {
         WriteHeader(stream, encoding);
         RootNode.Write(stream, encoding);
      }

      public byte[] Save(Encoding encoding)
      {
         using (var memoryStream = new MemoryStream())
         {
            Save(memoryStream, encoding);
            return memoryStream.ToArray();
         }
      }

      public void Save(string filename, Encoding encoding)
      {
         File.WriteAllBytes(filename, Save(encoding));
      }
   }
}
