using Kassenverwaltung.Database.Models;
using Kassenverwaltung.UI.Dialoge;
using Kassenverwaltung.Util;

namespace Kassenverwaltung.UI.Container
{
   public partial class BewegungsListe : UserControl
   {
      private KassenManager? _kassenManager;
      private Konto? _konto;

      public event EventHandler<Bewegung?>? SelectedBewegungChanged;

      public BewegungsListe()
      {
         InitializeComponent();

         var umbuchungsOption = new UserControls.SplitButton.Option("Umbuchung");
         umbuchungsOption.OnClicked = OnUmbuchungButtonClicked;
         splAdd.Options.Add(umbuchungsOption);

         SetButtonStates();
      }

      public void SetCurrentKassenManager(KassenManager? kassenManager)
      {
         _kassenManager = kassenManager;
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
         bool validContext = _kassenManager != null && _konto != null;
         bool bewegungSelected = validContext && GetSelectedBewegung() != null;

         splAdd.Enabled = validContext;
         btnEdit.Enabled = bewegungSelected;
         btnDel.Enabled = bewegungSelected;
      }

      private void InsertBewegungRow(IDictionary<int, Kategorie> kategorien, Bewegung bewegung)
      {
         int lfdNr = lstBewegungen.Items.Count + 1;

         ListViewItem lvi = new ListViewItem($"{lfdNr}");
         lvi.SubItems.Add(bewegung.Datum.ToString($"dd.MM.yyyy"));
         lvi.SubItems.Add(bewegung.Verwendung);
         lvi.SubItems.Add(GetKategorie(kategorien, bewegung));
         lvi.SubItems.Add($"{bewegung.Betrag:C}");
         lvi.Tag = bewegung;

         lstBewegungen.Items.Add(lvi);
      }

      private IDictionary<int, Kategorie> LoadKategorien()
      {
         if (_kassenManager != null)
         {
            IList<Kategorie> kategorien = _kassenManager.ListKategorien();
            return kategorien.ToDictionary(k => k.Id, k => k);
         }
         else
         {
            throw new InvalidOperationException($"Keine Datei geöffnet!");
         }
      }

      private string GetKategorie(IDictionary<int, Kategorie> kategorien, Bewegung bewegung)
      {
         if (bewegung.iKategorie.HasValue)
         {
            if (kategorien.TryGetValue(bewegung.iKategorie.Value, out Kategorie? kategorie) && !string.IsNullOrEmpty(kategorie.Name))
            {
               return kategorie.Name;
            }
         }

         return "<ohne Kategorie>";
      }

      private void FillListBox()
      {
         int? currentlySelectedBewegung = GetSelectedBewegung()?.Id;
         lstBewegungen.Items.Clear();

         if (_kassenManager != null && _konto != null)
         {
            IDictionary<int, Kategorie> kategorien = LoadKategorien();

            IList<Bewegung> bewegungen = _kassenManager.ListBewegungen(_konto);
            foreach (var bewegung in bewegungen)
            {
               InsertBewegungRow(kategorien, bewegung);
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
         if (_kassenManager != null && _konto != null)
         {
            return _kassenManager.CalculateCurrentKontostand(_konto);
         }
         else
         {
            return 0m;
         }
      }

      private void OnUmbuchungButtonClicked(object? sender, EventArgs? e)
      {
         if (_kassenManager != null && _konto != null)
         {
            var umbuchung = new Bewegung();
            using (var editor = new UmbuchungEditor(_kassenManager, _konto, umbuchung))
            {
               if (editor.ShowDialog() == DialogResult.OK && editor.ZielKonto != null)
               {
                  _kassenManager.AddUmbuchung(umbuchung, _konto, editor.ZielKonto);
                  FillListBox();
               }
            }
         }
      }

      private void OnMainButtonClicked(object sender, EventArgs e)
      {
         if (_kassenManager != null && _konto != null)
         {
            var bewegung = new Bewegung();
            using (var editor = new BewegungEditor(_kassenManager, _konto, bewegung))
            {
               if (editor.ShowDialog() == DialogResult.OK)
               {
                  _kassenManager.AddBewegung(bewegung, _konto);
                  FillListBox();
               }
            }
         }
      }

      private void OnBtnClickedEdit(object sender, EventArgs e)
      {
         EditSelectedBuchung();
      }

      private void EditSelectedBuchung()
      {
         if (_kassenManager != null && _konto != null)
         {
            Bewegung? selectedBewegung = GetSelectedBewegung();
            if (selectedBewegung != null)
            {
               if (selectedBewegung.Art == Bewegung.ArtEnum.EinAuszahlung)
               {
                  using (var editor = new BewegungEditor(_kassenManager, _konto, selectedBewegung))
                  {
                     if (editor.ShowDialog() == DialogResult.OK)
                     {
                        _kassenManager.UpdateBewegung(selectedBewegung);
                        FillListBox();
                     }
                  }
               }
               else if (selectedBewegung.Art == Bewegung.ArtEnum.Umbuchung)
               {
                  using (var editor = new UmbuchungEditor(_kassenManager, _konto, selectedBewegung))
                  {
                     if (editor.ShowDialog() == DialogResult.OK)
                     {
                        _kassenManager.UpdateUmbuchung(selectedBewegung);
                        FillListBox();
                     }
                  }
               }
            }
         }
      }

      private void OnBtnClickedDel(object sender, EventArgs e)
      {
         if (_kassenManager != null)
         {
            Bewegung? selectedBewegung = GetSelectedBewegung();
            if (selectedBewegung != null)
            {
               if (MessageService.ShowYesNo($"Möchten Sie die ausgewählte Bewegung vom {selectedBewegung.Datum} über den Betrag von {selectedBewegung.Betrag} wirklich löschen?", "Löschen?"))
               {
                  if (selectedBewegung.Art == Bewegung.ArtEnum.EinAuszahlung)
                  {
                     _kassenManager.DeleteBewegung(selectedBewegung);
                  }
                  else if (selectedBewegung.Art == Bewegung.ArtEnum.Umbuchung)
                  {
                     _kassenManager.DeleteUmbuchung(selectedBewegung);
                  }

                  FillListBox();
               }
            }
         }
      }

      private void OnSelectedIndexChanged(object sender, EventArgs e)
      {
         SetButtonStates();
         SelectedBewegungChanged?.Invoke(this, GetSelectedBewegung());
      }

      private void OnDoubleClick(object sender, EventArgs e)
      {
         EditSelectedBuchung();
      }
   }
}
