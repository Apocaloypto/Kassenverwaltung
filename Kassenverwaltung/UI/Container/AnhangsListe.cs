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
         DataManager = dataManager;
         FillListBox();
         SetButtonStates();
      }

      public void SetCurrentBewegung(Bewegung? bewegung)
      {
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
         bool anhangSelected = validContext && GetSelectedBeleg() != null;

         btnAdd.Enabled = validContext;
         btnMod.Enabled = anhangSelected;
         btnDetails.Enabled = anhangSelected;
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

      private void OnClickedDetails(object sender, EventArgs e)
      {
         EditSelectedBeleg();
      }

      private void OnSelectedIndexChanged(object sender, EventArgs e)
      {
         SetButtonStates();
      }

      private void OnDoubleClick(object sender, EventArgs e)
      {

      }
   }
}
