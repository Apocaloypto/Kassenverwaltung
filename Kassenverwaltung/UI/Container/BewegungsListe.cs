using Kassenverwaltung.Database.Models;
using Kassenverwaltung.UI.Dialoge;
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

         var umbuchungsOption = new UserControls.SplitButton.Option("Umbuchung");
         umbuchungsOption.OnClicked = OnUmbuchungButtonClicked;
         splAdd.Options.Add(umbuchungsOption);

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

         splAdd.Enabled = validContext;
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
         int? currentlySelectedBewegung = GetSelectedBewegung()?.Id;
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

            if (currentlySelectedBewegung.HasValue)
            {
               lstBewegungen.SelectItem((Bewegung? bewegung) => bewegung?.Id == currentlySelectedBewegung.Value);
            }
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

      private void OnUmbuchungButtonClicked(object? sender, EventArgs? e)
      {
         if (_dataManager != null && _konto != null)
         {
            var umbuchung = new Bewegung();
            using (var editor = new UmbuchungEditor(_dataManager, _konto, umbuchung))
            {
               if (editor.ShowDialog() == DialogResult.OK && editor.ZielKonto != null)
               {
                  _dataManager.AddUmbuchung(umbuchung, _konto, editor.ZielKonto);
                  FillListBox();
               }
            }
         }
      }

      private void OnMainButtonClicked(object sender, EventArgs e)
      {
         if (_dataManager != null && _konto != null)
         {
            var bewegung = new Bewegung();
            using (var editor = new BewegungEditor(_dataManager, _konto, bewegung))
            {
               if (editor.ShowDialog() == DialogResult.OK)
               {
                  _dataManager.AddBewegung(bewegung, _konto);
                  FillListBox();
               }
            }
         }
      }

      private void OnBtnClickedEdit(object sender, EventArgs e)
      {
         if (_dataManager != null && _konto != null)
         {
            Bewegung? selectedBewegung = GetSelectedBewegung();
            if (selectedBewegung != null)
            {
               if (selectedBewegung.Art == Bewegung.ArtEnum.EinAuszahlung)
               {
                  using (var editor = new BewegungEditor(_dataManager, _konto, selectedBewegung))
                  {
                     if (editor.ShowDialog() == DialogResult.OK)
                     {
                        _dataManager.UpdateBewegung(selectedBewegung);
                        FillListBox();
                     }
                  }
               }
               else if (selectedBewegung.Art == Bewegung.ArtEnum.Umbuchung)
               {
                  using (var editor = new UmbuchungEditor(_dataManager, _konto, selectedBewegung))
                  {
                     if (editor.ShowDialog() == DialogResult.OK)
                     {
                        _dataManager.UpdateUmbuchung(selectedBewegung);
                        FillListBox();
                     }
                  }
               }
            }
         }
      }

      private void OnBtnClickedDel(object sender, EventArgs e)
      {
         if (_dataManager != null)
         {
            Bewegung? selectedBewegung = GetSelectedBewegung();
            if (selectedBewegung != null)
            {
               if (MessageService.ShowYesNo($"Möchten Sie die ausgewählte Bewegung vom {selectedBewegung.Datum} über den Betrag von {selectedBewegung.Betrag} wirklich löschen?", "Löschen?"))
               {
                  if (selectedBewegung.Art == Bewegung.ArtEnum.EinAuszahlung)
                  {
                     _dataManager.DeleteBewegung(selectedBewegung);
                  }
                  else if (selectedBewegung.Art == Bewegung.ArtEnum.Umbuchung)
                  {
                     _dataManager.DeleteUmbuchung(selectedBewegung);
                  }

                  FillListBox();
               }
            }
         }
      }

      private void OnSelectedIndexChanged(object sender, EventArgs e)
      {
         SetButtonStates();
      }
   }
}
