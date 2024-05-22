using Kassenverwaltung.Database.Models;
using Kassenverwaltung.UI.Dialoge;
using Kassenverwaltung.Util;

namespace Kassenverwaltung.UI.Container
{
   public partial class KontenUebersicht : UserControl
   {
      private KVManager? _dataManager;

      public event EventHandler<Konto?>? SelectedKontoChanged;

      public KontenUebersicht()
      {
         InitializeComponent();

         SetButtonStates();
      }

      public void SetCurrentDatabase(KVManager? dataManager)
      {
         _dataManager = dataManager;
         FillListBox();
         SetButtonStates();
      }

      private void InsertKontoRow(Konto konto)
      {
         ListViewItem lvi = new ListViewItem(konto.Name);
         lvi.SubItems.Add(konto.IBAN);
         lvi.Tag = konto;
         lstKonten.Items.Add(lvi);
      }

      private void FillListBox()
      {
         int? currentlySelectedKonto = GetSelectedKonto()?.Id;
         lstKonten.Items.Clear();

         if (_dataManager != null)
         {
            IList<Konto> konten = _dataManager.ListKonten();
            foreach (var konto in konten)
            {
               InsertKontoRow(konto);
            }

            lstKonten.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstKonten.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            if (currentlySelectedKonto.HasValue)
            {
               lstKonten.SelectItem((Konto? k) => k?.Id == currentlySelectedKonto.Value);
            }
         }
      }

      private Konto? GetSelectedKonto()
      {
         if (lstKonten.SelectedItems.Count >= 1)
         {
            return (Konto?)lstKonten.SelectedItems[0].Tag;
         }
         else
         {
            return null;
         }
      }

      private void SetButtonStates()
      {
         bool contextValid = _dataManager != null;
         bool kontoSelected = contextValid && (GetSelectedKonto() != null);

         btnAdd.Enabled = contextValid;
         btnEdit.Enabled = kontoSelected;
         btnDel.Enabled = kontoSelected;
      }

      private void OnClickedAdd(object sender, EventArgs e)
      {
         if (_dataManager != null)
         {
            var neuesKonto = new Konto();
            using (var kontoEditor = new KontoEditor(neuesKonto))
            {
               if (kontoEditor.ShowDialog() == DialogResult.OK)
               {
                  _dataManager.AddKonto(neuesKonto);
                  FillListBox();
               }
            }
         }
      }

      private void OnClickedDel(object sender, EventArgs e)
      {
         if (_dataManager != null)
         {
            var selectedKonto = GetSelectedKonto();
            if (selectedKonto != null)
            {
               if (MessageService.ShowYesNo($"Möchten Sie das ausgewählte Konto '{selectedKonto.Name}' wirklich löschen?", "Löschen?"))
               {
                  _dataManager.DeleteKonto(selectedKonto);
                  FillListBox();
               }
            }
         }
      }

      private void OnClickedEdit(object sender, EventArgs e)
      {
         EditSelectedKonto();
      }

      private void EditSelectedKonto()
      {
         if (_dataManager != null)
         {
            var selectedKonto = GetSelectedKonto();
            if (selectedKonto != null)
            {
               using (var kontoEditor = new KontoEditor(selectedKonto))
               {
                  if (kontoEditor.ShowDialog() == DialogResult.OK)
                  {
                     _dataManager.UpdateKonto(selectedKonto);
                     FillListBox();
                  }
               }
            }
         }
      }

      private void OnSelectedIndexChanged(object sender, EventArgs e)
      {
         SetButtonStates();
         SelectedKontoChanged?.Invoke(this, GetSelectedKonto());
      }

      private void OnDoubleClick(object sender, EventArgs e)
      {
         EditSelectedKonto();
      }
   }
}
