using Kassenverwaltung.Util;
using Kassenverwaltung.Util.BewegungImporter;
using System.ComponentModel.DataAnnotations;

namespace Kassenverwaltung.UI.Dialoge
{
   public partial class BewegungsDatensaetze : Form
   {
      private readonly IList<BewegungsDatensatz> _bewegungsDatensaetze;

      public IList<BewegungsDatensatz>? AusgewaehlteDatensaetze { get; private set; }

      public BewegungsDatensaetze(IList<BewegungsDatensatz> bewegungsDatensaetze)
      {
         InitializeComponent();

         _bewegungsDatensaetze = bewegungsDatensaetze;

         FillListBox();
         SetButtonStates();
      }

      private void SetButtonStates()
      {
         btnOK.Enabled = lstDatensaetze.CheckedItems.Count > 0;
      }

      private void FillListBox()
      {
         lstDatensaetze.Items.Clear();
         foreach (var bewegungsDatensatz in _bewegungsDatensaetze)
         {
            InsertDatensatz(bewegungsDatensatz);
         }

         lstDatensaetze.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
         lstDatensaetze.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
      }

      private void InsertDatensatz(BewegungsDatensatz bewegungsDatensatz)
      {
         var lvi = new ListViewItem($"{bewegungsDatensatz.ZielKonto?.IBAN}");
         lvi.SubItems.Add($"{bewegungsDatensatz.Datum.ToString("dd.MM.yyyy")}");
         lvi.SubItems.Add($"{bewegungsDatensatz.Betrag.ToString("C")}");
         lvi.SubItems.Add($"{bewegungsDatensatz.Verwendung}");

         if (bewegungsDatensatz.Fehler)
         {
            lvi.SubItems.Add($"FEHLER: {bewegungsDatensatz.FehlerMeldung}");
            lvi.Checked = false;
         }
         else if (bewegungsDatensatz.Warnung)
         {
            lvi.SubItems.Add($"Warnung: {bewegungsDatensatz.WarnMeldung}");
            lvi.Checked = false;
         }
         else
         {
            lvi.SubItems.Add("");
            lvi.Checked = true;
         }

         lvi.Tag = bewegungsDatensatz;

         lstDatensaetze.Items.Add(lvi);
      }



      private void OnOK(object sender, EventArgs e)
      {
         try
         {
            ValidateInput();
            ApplyValues();

            DialogResult = DialogResult.OK;
         }
         catch (ValidationException ex)
         {
            MessageService.ShowError($"Fehler: {ex.Message}", "Fehler");
         }
      }

      private void ApplyValues()
      {
         AusgewaehlteDatensaetze = new List<BewegungsDatensatz>();
         foreach (ListViewItem checkedItem in lstDatensaetze.CheckedItems)
         {
            BewegungsDatensatz? zeile = checkedItem.Tag as BewegungsDatensatz;
            if (zeile != null)
            {
               AusgewaehlteDatensaetze.Add(zeile);
            }
         }
      }

      private void ValidateInput()
      {
         if (lstDatensaetze.CheckedItems.Count <= 0)
         {
            throw new ValidationException($"Wählen Sie mindestens einen zu importierenden Datensatz aus.");
         }
      }

      private void SelectedIndexChanged(object sender, EventArgs e)
      {
         SetButtonStates();
      }

      private void OnItemCheck(object sender, ItemCheckEventArgs e)
      {
         BewegungsDatensatz? datensatz = lstDatensaetze.Items[e.Index]?.Tag as BewegungsDatensatz;
         if (datensatz == null || datensatz.Fehler)
         {
            e.NewValue = e.CurrentValue;
         }
      }

      private void OnItemChecked(object sender, ItemCheckedEventArgs e)
      {
         SetButtonStates();
      }

      private void OnClickedAlleKeinen(object sender, EventArgs e)
      {
         if (lstDatensaetze.AllChecked())
         {
            lstDatensaetze.SetAllChecked(false);
         }
         else
         {
            lstDatensaetze.SetAllChecked(true);
         }
      }
   }
}
