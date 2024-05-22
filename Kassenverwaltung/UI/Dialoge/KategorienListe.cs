using Kassenverwaltung.Database.Models;
using Kassenverwaltung.Util;

namespace Kassenverwaltung.UI.Dialoge
{
   public partial class KategorienListe : Form
   {
      private readonly KVManager _kvManager;

      public bool HasChanged { get; private set; }

      public KategorienListe(KVManager kVManager)
      {
         InitializeComponent();

         _kvManager = kVManager;
         FillListControl();
         SetButtonStates();
      }

      private Kategorie? GetSelectedKategorie()
      {
         if (lstKategorien.SelectedItems.Count >= 1)
         {
            return (Kategorie?)lstKategorien.SelectedItems[0].Tag;
         }
         else
         {
            return null;
         }
      }

      private void SetButtonStates()
      {
         bool kategorieSelected = GetSelectedKategorie() != null;

         btnAdd.Enabled = true;
         btnMod.Enabled = kategorieSelected;
         btnDel.Enabled = kategorieSelected;
      }

      private void InsertKategorie(Kategorie kategorie)
      {
         var lvi = new ListViewItem(kategorie.Name);
         lvi.Tag = kategorie;
         lstKategorien.Items.Add(lvi);
      }

      private void FillListControl()
      {
         lstKategorien.Items.Clear();

         IList<Kategorie> kategorien = _kvManager.ListKategorien();
         foreach (var kategorie in kategorien)
         {
            InsertKategorie(kategorie);
         }
      }

      private void OnAddClicked(object sender, EventArgs e)
      {
         var kategorie = new Kategorie();
         using (var editor = new KategorieEditor(kategorie))
         {
            if (editor.ShowDialog() == DialogResult.OK)
            {
               _kvManager.AddKategorie(kategorie);
               HasChanged = true;
               FillListControl();
            }
         }
      }

      private void OnEditClicked(object sender, EventArgs e)
      {
         Kategorie? selectedKat = GetSelectedKategorie();
         if (selectedKat != null)
         {
            using (var editor = new KategorieEditor(selectedKat))
            {
               if (editor.ShowDialog() == DialogResult.OK)
               {
                  _kvManager.UpdateKategorie(selectedKat);
                  HasChanged = true;
                  FillListControl();
               }
            }
         }
      }

      private void OnDelClicked(object sender, EventArgs e)
      {
         Kategorie? selectedKat = GetSelectedKategorie();
         if (selectedKat != null)
         {
            if (MessageService.ShowYesNo($"Möchten Sie die ausgewählte Kategorie '{selectedKat.Name}' wirklich löschen?", "Löschen?"))
            {
               _kvManager.DeleteKategorie(selectedKat);
               HasChanged = true;
               FillListControl();
            }
         }
      }

      private void OnSelectedKategorieChanged(object sender, EventArgs e)
      {
         SetButtonStates();
      }

      private void OnOK(object sender, EventArgs e)
      {
         DialogResult = DialogResult.OK;
      }
   }
}
