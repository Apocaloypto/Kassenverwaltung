using Kassenverwaltung.Util.BewegungImporter;

namespace Kassenverwaltung.UI.Dialoge
{
   public partial class BewegungsDatensaetze : Form
   {
      private readonly IList<BewegungsDatensatz> _bewegungsDatensaetze;

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
            lvi.SubItems.Add($"Warnung: {bewegungsDatensatz.FehlerMeldung}");
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
   }
}
