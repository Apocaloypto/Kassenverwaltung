using Kassenverwaltung.Database.Models;
using Kassenverwaltung.UI.Dialoge;
using Kassenverwaltung.Util;

namespace Kassenverwaltung.UI.Container
{
   public partial class AnhangsListe : UserControl
   {
      public KVManager? DataManager { get; private set; }
      public Bewegung? Bewegung { get; private set; }

      public AnhangsListe()
      {
         InitializeComponent();

         SetButtonStates();
      }

      public void SetCurrentDatabase(KVManager? dataManager)
      {
         TempFileHelper.Inst.TryDeleteTempFiles();
         DataManager = dataManager;
         FillListBox();
         SetButtonStates();
      }

      public void SetCurrentBewegung(Bewegung? bewegung)
      {
         TempFileHelper.Inst.TryDeleteTempFiles();
         Bewegung = bewegung;
         FillListBox();
         SetButtonStates();
      }

      private Beleg? GetSelectedBeleg()
      {
         if (lstAnhaenge.SelectedItems.Count > 0)
         {
            return (Beleg?)lstAnhaenge.SelectedItems[0].Tag;
         }
         else
         {
            return null;
         }
      }

      private void SetButtonStates()
      {
         bool validContext = DataManager != null && Bewegung != null;
         Beleg? selectedBeleg = GetSelectedBeleg();
         bool anhangSelected = validContext && selectedBeleg != null;

         btnAdd.Enabled = validContext;
         btnMod.Enabled = anhangSelected;
         btnDetails.Enabled = anhangSelected;
         btnExport.Enabled = validContext && selectedBeleg != null && selectedBeleg.BlobInDb;
         btnDel.Enabled = anhangSelected;
      }

      private void FillListBox()
      {
         int? currentlySelectedBeleg = GetSelectedBeleg()?.Id;
         lstAnhaenge.Items.Clear();

         if (DataManager != null && Bewegung != null)
         {
            IList<Beleg> belege = DataManager.ListBelege(Bewegung);
            foreach (var beleg in belege)
            {
               InsertBeleg(beleg);
            }

            lstAnhaenge.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstAnhaenge.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            if (currentlySelectedBeleg.HasValue)
            {
               lstAnhaenge.SelectItem((Beleg? beleg) => beleg?.Id == currentlySelectedBeleg.Value);
            }
         }
      }

      private void InsertBeleg(Beleg beleg)
      {
         ListViewItem lvi = new ListViewItem($"{beleg.Name}");
         lvi.SubItems.Add(beleg.Pfad);
         lvi.SubItems.Add(Path.GetExtension(beleg.Pfad));
         lvi.Tag = beleg;

         lstAnhaenge.Items.Add(lvi);
      }

      private void OnClickedDel(object sender, EventArgs e)
      {
         if (DataManager != null && Bewegung != null)
         {
            Beleg? selectedBeleg = GetSelectedBeleg();
            if (selectedBeleg != null)
            {
               if (MessageService.ShowYesNo($"Möchten Sie den ausgewählten Beleg '{selectedBeleg.Name}' wirklich löschen?", "Löschen?"))
               {
                  DataManager.DeleteBeleg(selectedBeleg);
                  FillListBox();
               }
            }
         }
      }

      private void OnClickedEdit(object sender, EventArgs e)
      {
         EditSelectedBeleg();
      }

      private void EditSelectedBeleg()
      {
         if (DataManager != null && Bewegung != null)
         {
            Beleg? selectedBeleg = GetSelectedBeleg();
            if (selectedBeleg != null)
            {
               using (var editor = new AnhangEditor(selectedBeleg))
               {
                  if (editor.ShowDialog() == DialogResult.OK)
                  {
                     DataManager.UpdateBeleg(selectedBeleg);
                     FillListBox();
                  }
               }
            }
         }
      }

      private void OnClickedAdd(object sender, EventArgs e)
      {
         if (DataManager != null && Bewegung != null)
         {
            var beleg = new Beleg();
            using (var editor = new AnhangEditor(beleg))
            {
               if (editor.ShowDialog() == DialogResult.OK)
               {
                  DataManager.AddBeleg(Bewegung, beleg);
                  FillListBox();
               }
            }
         }
      }

      private void OnSelectedIndexChanged(object sender, EventArgs e)
      {
         SetButtonStates();
      }

      private void OnDoubleClick(object sender, EventArgs e)
      {
         EditSelectedBeleg();
      }

      private void OnClickedDetails(object sender, EventArgs e)
      {
         Beleg? selectedBeleg = GetSelectedBeleg();
         if (selectedBeleg != null)
         {
            try
            {
               if (selectedBeleg.BlobInDb)
               {
                  string fileExt = Path.GetExtension(selectedBeleg.Pfad!);
                  if (string.IsNullOrEmpty(fileExt))
                  {
                     throw new InvalidOperationException($"Es konnte keine Dateiendung ermittelt werden, exportieren Sie stattdessen die Datei");
                  }

                  string temppath = FileHelper.GenerateTempFilename(fileExt);
                  File.WriteAllBytes(temppath, selectedBeleg.Blob!);
                  TempFileHelper.Inst.Register(temppath);

                  FileHelper.OpenFileWithDefaultProgram(temppath);
               }
               else
               {
                  FileHelper.OpenFileWithDefaultProgram(selectedBeleg.Pfad!);
               }
            }
            catch (Exception ex)
            {
               MessageService.ShowError($"Fehler beim Öffnen der Datei: {ex.Message}", "Fehler");
            }
         }
      }

      private void OnClickedExport(object sender, EventArgs e)
      {
         Beleg? selectedBeleg = GetSelectedBeleg();
         if (selectedBeleg != null && selectedBeleg.BlobInDb)
         {
            var dateiEndung = Path.GetExtension(selectedBeleg.Pfad);
            if (string.IsNullOrEmpty(dateiEndung))
            {
               dateiEndung = ".*";
            }

            using (var sfd = new SaveFileDialog())
            {
               sfd.FileName = Path.GetFileNameWithoutExtension(selectedBeleg.Name);
               sfd.Filter = $"*{dateiEndung}|*{dateiEndung}";

               if (sfd.ShowDialog() == DialogResult.OK)
               {
                  File.WriteAllBytes(sfd.FileName, selectedBeleg.Blob!);
               }
            }
         }
      }
   }
}
