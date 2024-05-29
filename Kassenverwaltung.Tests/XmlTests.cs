using Kassenverwaltung.Util.Exporter.ODSFormat.XmlHelper;
using System.Text;

namespace Kassenverwaltung.Tests
{
   public class XmlTests
   {
      [Fact]
      public void SimpleXml_Success()
      {
         // ARRANGE
         var xml = new Xml("test");
         xml.RootNode.SetText("Hallo");

         // ACT
         byte[] written = xml.Save(Encoding.UTF8);
         string result = Encoding.UTF8.GetString(written);

         // ASSERT
         Assert.Equal("<?xml version=\"1.0\" encoding=\"utf-8\"?><test>Hallo</test>", result);
      }

      [Fact]
      public void XmlWithChildNodes_Success()
      {
         // ARRANGE
         var xml = new Xml("asdf");
         var inner = xml.RootNode.AddNode("jkloe");
         inner.SetText("Node 1");
         inner = xml.RootNode.AddNode("_123");
         inner.SetText("Node 2");
         inner = xml.RootNode.AddNode("_456");
         var innerinner = inner.AddNode("_789");
         innerinner.SetText("Node 3.1");

         // ACT
         byte[] written = xml.Save(Encoding.UTF8);
         string result = Encoding.UTF8.GetString(written);

         // ASSERT
         Assert.Equal($"<?xml version=\"1.0\" encoding=\"utf-8\"?><asdf><jkloe>Node 1</jkloe><_123>Node 2</_123><_456><_789>Node 3.1</_789></_456></asdf>", result);
      }

      [Fact]
      public void EmptyXml_Success()
      {
         // ARRANGE
         var xml = new Xml("empty");

         // ACT
         byte[] written = xml.Save(Encoding.UTF8);
         string result = Encoding.UTF8.GetString(written);

         // ASSERT
         Assert.Equal($"<?xml version=\"1.0\" encoding=\"utf-8\"?><empty />", result);
      }

      [Fact]
      public void Attributes_Success()
      {
         // ARRANGE
         var xml = new Xml("attr");

         xml.RootNode.AddAttribute("asdf", "Marius");
         xml.RootNode.AddAttribute("jkloe", "Test");

         // ACT
         byte[] written = xml.Save(Encoding.UTF8);
         string result = Encoding.UTF8.GetString(written);

         // ASSERT
         Assert.Equal($"<?xml version=\"1.0\" encoding=\"utf-8\"?><attr asdf=\"Marius\" jkloe=\"Test\" />", result);
      }
   }
}
