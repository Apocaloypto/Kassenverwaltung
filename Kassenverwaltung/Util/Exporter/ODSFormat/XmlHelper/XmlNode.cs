using System.Text;

namespace Kassenverwaltung.Util.Exporter.ODSFormat.XmlHelper
{
   public class XmlNode
   {
      public string NodeName { get; }
      public IDictionary<string, XmlAttribute> Attributes { get; }
      public IList<XmlNode> InnerNodes { get; }
      public string? InnerText { get; private set; }

      public XmlNode(string nodeName)
      {
         NodeName = nodeName;
         InnerNodes = new List<XmlNode>();
         Attributes = new Dictionary<string, XmlAttribute>();
      }

      public void AddAttribute(string name, string value)
      {
         Attributes[name] = new XmlAttribute(name, value);
      }

      public XmlNode AddNode(string name)
      {
         var newNode = new XmlNode(name);
         InnerNodes.Add(newNode);
         return newNode;
      }

      public void SetText(string text)
      {
         InnerText = text;
      }

      private string GetOpeningTag()
      {
         var sb = new StringBuilder();
         sb.Append($"<{NodeName}");
         string attributes = string.Join(" ", Attributes.Values.Select(a => a.GetString()));
         if (!string.IsNullOrEmpty(attributes))
         {
            sb.Append($" {attributes}");
         }
         return sb.ToString();
      }

      private string GetClosingTag()
      {
         return $"</{NodeName}>";
      }

      public void Write(Stream target, Encoding encoding)
      {
         target.Write(encoding.GetBytes(GetOpeningTag()));
         if (InnerNodes.Any())
         {
            target.Write(encoding.GetBytes(">"));
            foreach (var innerNode in InnerNodes)
            {
               innerNode.Write(target, encoding);
            }
            target.Write(encoding.GetBytes(GetClosingTag()));
         }
         else if (!string.IsNullOrEmpty(InnerText))
         {
            target.Write(encoding.GetBytes(">"));
            target.Write(encoding.GetBytes(InnerText));
            target.Write(encoding.GetBytes(GetClosingTag()));
         }
         else
         {
            target.Write(encoding.GetBytes(" />"));
         }
      }
   }
}
