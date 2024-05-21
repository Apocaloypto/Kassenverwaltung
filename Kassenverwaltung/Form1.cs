using Kassenverwaltung.Database;
using Kassenverwaltung.Util;

namespace Kassenverwaltung
{
   public partial class Form1 : Form
   {
      private const string FILE_FILTER = "Kassenverwaltungsdatei (*.kdb)|*.kdb";

      private KVManager? _dataManager;
      private string DefaultWindowTitle { get; }

      public Form1()
      {
         InitializeComponent(); 
         DefaultWindowTitle = Text;
      }

      private void OpenDatabase(string filename, bool isNew)
      {
         _dataManager = new KVManager(filename, isNew);
         Text = $"{DefaultWindowTitle} - {filename}";

         kontenUebersicht.SetCurrentDatabase(_dataManager);
      }

      private void OnMenuStrip_Neu(object sender, EventArgs e)
      {
         using (var sfd = new SaveFileDialog())
         {
            sfd.Filter = FILE_FILTER;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
               OpenDatabase(sfd.FileName, true);
            }
         }
      }

      private void OnMenuStrip_Oeffnen(object sender, EventArgs e)
      {
         using (var ofd = new OpenFileDialog())
         {
            ofd.Filter = FILE_FILTER;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
               OpenDatabase(ofd.FileName, false);
            }
         }
      }
   }
}
