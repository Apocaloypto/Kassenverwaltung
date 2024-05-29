using Kassenverwaltung.Util.Exporter.ODSFormat.Cells;
using Kassenverwaltung.Util.Exporter.ODSFormat.XmlHelper;

namespace Kassenverwaltung.Util.Exporter.ODSFormat.Util
{
   public class ContentHeader
   {
      public const string COLUMN_STYLE_NAME = "co1";
      public const string ROW_STYLE_NAME = "ro1";
      public const string TABLE_STYLE_NAME = "ta1";

      public bool HasCurrencyCell { get; set; }
      public bool HasDateTimeCell { get; set; }

      public void Export(XmlNode parentNode)
      {
         WriteRootAttributes(parentNode);
         WriteScriptsHeader(parentNode);
         WriteFontFaceDecls(parentNode);
         WriteAutomaticStyles(parentNode);
      }

      private void WriteAutomaticStyles(XmlNode parentNode)
      {
         XmlNode autoStyles = parentNode.AddNode("office:automatic-styles");

         WriteAutoStyleColumn(autoStyles);
         WriteAutoStyleRow(autoStyles);
         WriteAutoStyleTable(autoStyles);

         if (HasCurrencyCell)
         {
            WriteCurrencyCellStyle(autoStyles);
         }

         if (HasDateTimeCell)
         {
            WriteDateTimeCellStyle(autoStyles);
         }
      }

      private void WriteAutoStyleTable(XmlNode parentNode)
      {
         XmlNode tableStyle = parentNode.AddNode("style:style");
         tableStyle.AddAttribute("style:name", TABLE_STYLE_NAME);
         tableStyle.AddAttribute("style:family", "table");
         tableStyle.AddAttribute("style:master-page-name", "Default");

         XmlNode styleDef = tableStyle.AddNode("style:table-properties");
         styleDef.AddAttribute("table:display", "true");
         styleDef.AddAttribute("style:writing-mode", "lr-tb");
      }

      private void WriteAutoStyleRow(XmlNode parentNode)
      {
         XmlNode rowStyle = parentNode.AddNode("style:style");
         rowStyle.AddAttribute("style:name", ROW_STYLE_NAME);
         rowStyle.AddAttribute("style:family", "table-row");

         XmlNode styleDef = rowStyle.AddNode("style:table-row-properties");
         styleDef.AddAttribute("style:row-height", "0.452cm");
         styleDef.AddAttribute("fo:break-before", "auto");
         styleDef.AddAttribute("style:use-optimal-row-height", "true");
      }

      private void WriteAutoStyleColumn(XmlNode parentNode)
      {
         XmlNode colStyle = parentNode.AddNode("style:style");
         colStyle.AddAttribute("style:name", COLUMN_STYLE_NAME);
         colStyle.AddAttribute("style:family", "table-column");

         XmlNode styleDef = colStyle.AddNode("style:table-column-properties");
         styleDef.AddAttribute("fo:break-before", "auto");
         styleDef.AddAttribute("style:column-width", "2.258cm");
      }

      private void WriteDateTimeCellStyle(XmlNode autoStyles)
      {
         XmlNode dateStyle = autoStyles.AddNode("number:date-style");
         dateStyle.AddAttribute("style:name", "N37");
         dateStyle.AddAttribute("number:automatic-order", "true");

         XmlNode dayStyle = dateStyle.AddNode("number:day");
         dayStyle.AddAttribute("number:style", "long");

         dateStyle.AddNode("number:text").SetText(".");

         XmlNode monthStyle = dateStyle.AddNode("number:month");
         monthStyle.AddAttribute("number:style", "long");

         dateStyle.AddNode("number:text").SetText(".");

         dateStyle.AddNode("number:year");

         AddStyleDef(autoStyles, DateTimeCell.STYLE_NAME, "N37");
      }

      private static void AddStyleDef(XmlNode autoStyles, string styleName, string formatName)
      {
         XmlNode styleDef = autoStyles.AddNode("style:style");
         styleDef.AddAttribute("style:name", styleName);
         styleDef.AddAttribute("style:family", "table-cell");
         styleDef.AddAttribute("style:parent-style-name", "Default");
         styleDef.AddAttribute("style:data-style-name", formatName);
      }

      private void WriteCurrencyCellStyle(XmlNode autoStyles)
      {
         AddStyleDef(autoStyles, CurrencyCell.STYLE_NAME, "N107");
      }

      private void AddFontFace(XmlNode parentNode, string name, string fontFamily = "system")
      {
         XmlNode fontFace = parentNode.AddNode("style:font-face");
         fontFace.AddAttribute("style:name", name);
         fontFace.AddAttribute("svg:font-family", $"&apos;{name}&apos;");
         fontFace.AddAttribute("style:font-family-generic", fontFamily);
         fontFace.AddAttribute("style:font-pitch", "variable");
      }

      private void WriteFontFaceDecls(XmlNode rootNode)
      {
         XmlNode fontFaceDecls = rootNode.AddNode("office:font-face-decls");
         AddFontFace(fontFaceDecls, "Liberation Sans", "swiss");
         AddFontFace(fontFaceDecls, "Lucida Sans");
         AddFontFace(fontFaceDecls, "Microsoft YaHei");
      }

      private void WriteScriptsHeader(XmlNode rootNode)
      {
         rootNode.AddNode("office:scripts");
      }

      private void WriteRootAttributes(XmlNode rootNode)
      {
         rootNode.AddAttribute("xmlns:office", "urn:oasis:names:tc:opendocument:xmlns:office:1.0");
         rootNode.AddAttribute("xmlns:ooo", "http://openoffice.org/2004/office");
         rootNode.AddAttribute("xmlns:fo", "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0");
         rootNode.AddAttribute("xmlns:xlink", "http://www.w3.org/1999/xlink");
         rootNode.AddAttribute("xmlns:dc", "http://purl.org/dc/elements/1.1/");
         rootNode.AddAttribute("xmlns:meta", "urn:oasis:names:tc:opendocument:xmlns:meta:1.0");
         rootNode.AddAttribute("xmlns:style", "urn:oasis:names:tc:opendocument:xmlns:style:1.0");
         rootNode.AddAttribute("xmlns:text", "urn:oasis:names:tc:opendocument:xmlns:text:1.0");
         rootNode.AddAttribute("xmlns:rpt", "http://openoffice.org/2005/report");
         rootNode.AddAttribute("xmlns:draw", "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0");
         rootNode.AddAttribute("xmlns:dr3d", "urn:oasis:names:tc:opendocument:xmlns:dr3d:1.0");
         rootNode.AddAttribute("xmlns:svg", "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0");
         rootNode.AddAttribute("xmlns:chart", "urn:oasis:names:tc:opendocument:xmlns:chart:1.0");
         rootNode.AddAttribute("xmlns:table", "urn:oasis:names:tc:opendocument:xmlns:table:1.0");
         rootNode.AddAttribute("xmlns:number", "urn:oasis:names:tc:opendocument:xmlns:datastyle:1.0");
         rootNode.AddAttribute("xmlns:ooow", "http://openoffice.org/2004/writer");
         rootNode.AddAttribute("xmlns:oooc", "http://openoffice.org/2004/calc");
         rootNode.AddAttribute("xmlns:of", "urn:oasis:names:tc:opendocument:xmlns:of:1.2");
         rootNode.AddAttribute("xmlns:xforms", "http://www.w3.org/2002/xforms");
         rootNode.AddAttribute("xmlns:tableooo", "http://openoffice.org/2009/table");
         rootNode.AddAttribute("xmlns:calcext", "urn:org:documentfoundation:names:experimental:calc:xmlns:calcext:1.0");
         rootNode.AddAttribute("xmlns:drawooo", "http://openoffice.org/2010/draw");
         rootNode.AddAttribute("xmlns:xhtml", "http://www.w3.org/1999/xhtml");
         rootNode.AddAttribute("xmlns:loext", "urn:org:documentfoundation:names:experimental:office:xmlns:loext:1.0");
         rootNode.AddAttribute("xmlns:field", "urn:openoffice:names:experimental:ooo-ms-interop:xmlns:field:1.0");
         rootNode.AddAttribute("xmlns:math", "http://www.w3.org/1998/Math/MathML");
         rootNode.AddAttribute("xmlns:form", "urn:oasis:names:tc:opendocument:xmlns:form:1.0");
         rootNode.AddAttribute("xmlns:script", "urn:oasis:names:tc:opendocument:xmlns:script:1.0");
         rootNode.AddAttribute("xmlns:formx", "urn:openoffice:names:experimental:ooxml-odf-interop:xmlns:form:1.0");
         rootNode.AddAttribute("xmlns:dom", "http://www.w3.org/2001/xml-events");
         rootNode.AddAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
         rootNode.AddAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
         rootNode.AddAttribute("xmlns:grddl", "http://www.w3.org/2003/g/data-view#");
         rootNode.AddAttribute("xmlns:css3t", "http://www.w3.org/TR/css3-text/");
         rootNode.AddAttribute("xmlns:presentation", "urn:oasis:names:tc:opendocument:xmlns:presentation:1.0");
         rootNode.AddAttribute("office:version", "1.3");
      }
   }
}
