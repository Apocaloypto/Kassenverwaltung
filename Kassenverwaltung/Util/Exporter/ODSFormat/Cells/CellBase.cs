using Kassenverwaltung.Util.Exporter.ODSFormat.XmlHelper;

namespace Kassenverwaltung.Util.Exporter.ODSFormat.Cells
{
   public abstract class CellBase
   {
      public int Row { get; }
      public int Column { get; }

      public string Position => $"{Row}:{Column}";

      protected CellBase(int row, int column)
      {
         Row = row;
         Column = column;
      }

      public abstract void Export(XmlNode parentNode);
   }
}
