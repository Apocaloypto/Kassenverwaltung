namespace Kassenverwaltung.Util.Exporter.ODSFormat.XmlHelper
{
   public class XmlAttribute
   {
      public string Name { get; }
      public string Value { get; }

      public XmlAttribute(string name, string value)
      {
         Name = name;
         Value = value;
      }

      public string GetString()
      {
         return $"{Name}=\"{Value}\"";
      }
   }
}
