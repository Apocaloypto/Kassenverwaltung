using Kassenverwaltung.Database;

namespace Kassenverwaltung
{
   public partial class Form1 : Form
   {
      private const string FILE_FILTER = "Kassenverwaltungsdatei (*.kdb)|*.kdb";

      private KVDatabase? _database;
      private string DefaultWindowTitle { get; }

      public Form1()
      {
         InitializeComponent(); 
         DefaultWindowTitle = Text;
      }

      private void OpenDatabase(string filename)
      {
         _database = new KVDatabase($"Data Source={filename}");
         Text = $"{DefaultWindowTitle} - {filename}";
      }

      private void OnMenuStrip_Neu(object sender, EventArgs e)
      {
         using (var sfd = new SaveFileDialog())
         {
            sfd.Filter = FILE_FILTER;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
               OpenDatabase(sfd.FileName);
               _database!.EnsureExists();
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
               OpenDatabase(ofd.FileName);
            }
         }
      }
   }
}
