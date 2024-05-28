using Kassenverwaltung.Database.Models;
using Kassenverwaltung.UI;
using Kassenverwaltung.UI.Dialoge;
using Kassenverwaltung.Util;
using Kassenverwaltung.Util.BewegungImporter;
using Kassenverwaltung.Util.Exporter;

namespace Kassenverwaltung
{
   public partial class Form1 : Form
   {
      private const string FILE_FILTER = "Kassenverwaltungsdatei (*.kdb)|*.kdb";

      private KassenManager? _kassenManager;
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
            _kassenManager = new KassenManager(filename);
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
         kontenUebersicht.SetCurrentKassenManager(_kassenManager);
         bewegungsUebersicht.SetCurrentKassenManager(_kassenManager);
      }

      private void SetButtonStates()
      {
         bool databaseOpened = _kassenManager != null;

         stammdatenToolStripMenuItem.Enabled = databaseOpened;
         importToolStripMenuItem.Enabled = databaseOpened;
         exportToolStripMenuItem.Enabled = databaseOpened;
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
         if (_kassenManager != null)
         {
            using (var dlg = new KategorienListe(_kassenManager))
            {
               dlg.ShowDialog();
               if (dlg.HasChanged)
               {
                  ReloadData();
               }
            }
         }
      }

      private void OnMenuItem_Stammdatenimport(object sender, EventArgs e)
      {
         if (_kassenManager != null)
         {
            if (!_kassenManager.IstDbLeer())
            {
               MessageService.ShowError($"Diese Datenbank enthält bereits Daten, ein Import von Stammdaten ist nicht mehr möglich", "Fehler beim Import");
               return;
            }

            using (var ofd = new OpenFileDialog())
            {
               ofd.Filter = FILE_FILTER;

               if (ofd.ShowDialog() == DialogResult.OK)
               {
                  var stammdatenImporter = new StammdatenImporter(_kassenManager, ofd.FileName);
                  try
                  {
                     StammdatenImportResult result = stammdatenImporter.ImportData();
                     MessageService.ShowInfo($"Der Importvorgang wurde erfolgreich durchgeführt: {result}", "Import erfolgreich");
                     ReloadData();
                  }
                  catch (Exception ex)
                  {
                     MessageService.ShowError($"Fehler beim Import von Stammdaten: {ex.Message}", "Fehler beim Import");
                  }
               }
            }
         }
      }

      private IList<BewegungsDatensatz>? ImportBewegungsDatensaetze()
      {
         if (_kassenManager != null)
         {
            using (var dlg = new BewegungsImporter())
            {
               if (dlg.ShowDialog() == DialogResult.OK)
               {
                  if (Path.Exists(dlg.ImportFile))
                  {
                     IBewegungsImport importer = ImporterFactory.CreateImporter(dlg.ImportFormat, _kassenManager);
                     return importer.GetBewegungsDatensaetze(dlg.ImportFile);
                  }
               }
            }
         }

         return null;
      }

      private void OnMenuItem_BewegungsImport(object sender, EventArgs e)
      {
         if (_kassenManager != null)
         {
            try
            {
               IList<BewegungsDatensatz>? bewegungsDaten = ImportBewegungsDatensaetze();
               if (bewegungsDaten != null)
               {
                  using (var importDialog = new BewegungsDatensaetze(bewegungsDaten))
                  {
                     if (importDialog.ShowDialog() == DialogResult.OK)
                     {
                        var importManager = new ImportManager(_kassenManager);
                        importManager.ImportBewegungsDatensaetze(importDialog.AusgewaehlteDatensaetze!);
                        MessageService.ShowInfo($"Der Import wurde erfolgreich durchgeführt", "Hinweis");
                        ReloadData();
                     }
                  }
               }
            }
            catch (Exception ex)
            {
               MessageService.ShowError($"Fehler beim Import von Bewegungsdaten: {ex.Message}", "Fehler beim Import");
            }
         }
      }

      private void Export(ExportFormat format)
      {
         if (_kassenManager != null)
         {
            try
            {
               using (var sfd = new SaveFileDialog())
               {
                  sfd.Filter = "OpenDocumentFormat (*.ods)|*.ods";

                  if (sfd.ShowDialog() == DialogResult.OK)
                  {
                     var exportManager = new ExportManager(_kassenManager);
                     exportManager.Export(format, sfd.FileName);
                     MessageService.ShowInfo($"Export erfolgreich durchgeführt!", "Export erfolgreich");
                  }
               }
            }
            catch (Exception ex)
            {
               MessageService.ShowError($"Fehler beim Export von Daten: {ex.Message}", "Fehler beim Export");
            }
         }
      }

      private void OnMenuStrip_ExportPruefung(object sender, EventArgs e)
      {
         Export(ExportFormat.Kassenpruefung);
      }

      private void OnMenuStrip_ExportJHV(object sender, EventArgs e)
      {
         Export(ExportFormat.JHV);
      }
   }
}
