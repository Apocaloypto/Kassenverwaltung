using Kassenverwaltung.Database.Models;
using Kassenverwaltung.UI;
using Kassenverwaltung.UI.Dialoge;
using Kassenverwaltung.Util;

namespace Kassenverwaltung
{
   public partial class Form1 : Form
   {
      private const string FILE_FILTER = "Kassenverwaltungsdatei (*.kdb)|*.kdb";

      private KVManager? _dataManager;
      private string DefaultWindowTitle { get; }

      public Form1(string? filename)
      {
         InitializeComponent();
         DefaultWindowTitle = Text;

         SetButtonStates();

         if (!string.IsNullOrEmpty(filename))
         {
            OpenDatabase(filename);
         }
      }

      private void OpenDatabase(string filename)
      {
         try
         {
            _dataManager = new KVManager(filename);
            Text = $"{DefaultWindowTitle} - {filename}";

            ReloadData();

            SetButtonStates();
         }
         catch (Exception ex)
         {
            MessageService.ShowError($"Fehler beim Öffnen der Datenbank: {ex.Message}", "Fehler");
         }
      }

      private void ReloadData()
      {
         kontenUebersicht.SetCurrentDatabase(_dataManager);
         bewegungsUebersicht.SetCurrentDatabase(_dataManager);
      }

      private void SetButtonStates()
      {
         bool databaseOpened = _dataManager != null;

         kategorienToolStripMenuItem.Enabled = databaseOpened;
      }

      private void OnMenuStrip_Neu(object sender, EventArgs e)
      {
         using (var sfd = new SaveFileDialog())
         {
            sfd.Filter = FILE_FILTER;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
               OpenDatabase(sfd.FileName);
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

      private void OnSelectedKontoChanged(object sender, Konto? selectedKonto)
      {
         bewegungsUebersicht.SetCurrentKonto(selectedKonto);
      }

      private void OnKategorienClicked(object sender, EventArgs e)
      {
         if (_dataManager != null)
         {
            using (var dlg = new KategorienListe(_dataManager))
            {
               dlg.ShowDialog();
               if (dlg.HasChanged)
               {
                  ReloadData();
               }
            }
         }
      }
   }
}
