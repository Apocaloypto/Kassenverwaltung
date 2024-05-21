using Kassenverwaltung.Database.Models;
using Kassenverwaltung.Util;

namespace Kassenverwaltung.UI.Container
{
   public partial class BewegungsListe : UserControl
   {
      private KVManager? _dataManager;
      private Konto? _konto;

      public BewegungsListe()
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

      public void SetCurrentKonto(Konto? konto)
      {
         _konto = konto;
         FillListBox();
         SetButtonStates();
      }

      private Bewegung? GetSelectedBewegung()
      {
         if (lstBewegungen.SelectedItems.Count >= 1)
         {
            return (Bewegung?)lstBewegungen.SelectedItems[0].Tag;
         }
         else
         {
            return null;
         }
      }

      private void SetButtonStates()
      {
         bool validContext = _dataManager != null && _konto != null;
         bool bewegungSelected = validContext && GetSelectedBewegung() != null;

         btnAdd.Enabled = validContext;
         btnEdit.Enabled = bewegungSelected;
         btnDel.Enabled = bewegungSelected;
      }

      private void InsertBewegungRow(Bewegung bewegung)
      {
         int lfdNr = lstBewegungen.Items.Count + 1;

         ListViewItem lvi = new ListViewItem($"{lfdNr}");
         lvi.SubItems.Add(bewegung.Datum.ToString($"dd.MM.yyyy"));
         lvi.SubItems.Add(bewegung.Verwendung);
         lvi.SubItems.Add($"{bewegung.Betrag:C}");
         lvi.Tag = bewegung;

         lstBewegungen.Items.Add(lvi);
      }

      private void FillListBox()
      {
         lstBewegungen.Items.Clear();

         if (_dataManager != null && _konto != null)
         {
            IList<Bewegung> bewegungen = _dataManager.ListBewegungen(_konto);
            foreach (var bewegung in bewegungen)
            {
               InsertBewegungRow(bewegung);
            }

            tbxKontostand.Text = $"{CalculateCurrentKontostand(bewegungen):C}";

            lstBewegungen.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstBewegungen.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
         }
      }

      private decimal CalculateCurrentKontostand(IList<Bewegung> bewegungen)
      {
         if (_konto != null)
         {
            var kontostand = _konto.Anfangsbestand;
            foreach (var bewegung in bewegungen)
            {
               kontostand += bewegung.Betrag;
            }

            return kontostand;
         }
         else
         {
            return 0m;
         }
      }

      private void OnBtnClickedAdd(object sender, EventArgs e)
      {

      }

      private void OnBtnClickedEdit(object sender, EventArgs e)
      {

      }

      private void OnBtnClickedDel(object sender, EventArgs e)
      {

      }
   }
}
