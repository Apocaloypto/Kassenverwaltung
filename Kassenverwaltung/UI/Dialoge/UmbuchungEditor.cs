using Kassenverwaltung.Database.Models;
using Kassenverwaltung.Util;
using System.ComponentModel.DataAnnotations;

namespace Kassenverwaltung.UI.Dialoge
{
   public partial class UmbuchungEditor : Form
   {
      private class KontoComboboxItem
      {
         public Konto Konto { get; }

         public KontoComboboxItem(Konto konto)
         {
            Konto = konto;
         }

         public override string ToString()
         {
            return Konto.Name!;
         }
      }

      private KVManager DataManger { get; }
      private Konto Konto { get; }
      public Konto? ZielKonto { get; private set; }
      public Bewegung Umbuchung { get; }

      public UmbuchungEditor(KVManager dataManager, Konto konto, Bewegung umbuchung)
      {
         InitializeComponent();

         DataManger = dataManager;
         Konto = konto;
         Umbuchung = umbuchung;

         SetupValues();
      }

      private void SetupValues()
      {
         cbxKonto.Enabled = true;
         FillKontoCombobox();
         SelectKonto();
         dtpDatum.SetValueSafe(Umbuchung.Datum, DateTime.Today);
         monBetrag.Value = Umbuchung.Betrag;
         tbxVerwendung.Text = Umbuchung.Verwendung;
      }

      private void SelectKonto()
      {
         if (Umbuchung.iBewegung.HasValue)
         {
            ZielKonto = DataManger.FindKontoZuBewegung(Umbuchung.iBewegung.Value);
            if (ZielKonto != null)
            {
               cbxKonto.SelectItem((KontoComboboxItem item) => item.Konto.Id == ZielKonto.Id);
            }
            cbxKonto.Enabled = false; // Nachträgliche Änderung des Zielkontos nicht möglich.
         }
      }

      private void FillKontoCombobox()
      {
         cbxKonto.Items.Clear();
         IList<Konto> konten = DataManger.ListKonten();
         foreach (var konto in konten)
         {
            if (konto.Id == Konto.Id)
            {
               continue; // Keine Umbuchung aufs gleiche Konto.
            }

            InsertKonto(konto);
         }
      }

      private void InsertKonto(Konto konto)
      {
         cbxKonto.Items.Add(new KontoComboboxItem(konto));
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
            MessageService.ShowError($"Ungültiger Wert: {ex.Message}", "Fehler beim Übernehmen");
         }
      }

      private void ApplyValues()
      {
         ZielKonto = GetSelectedKonto();

         Umbuchung.Datum = dtpDatum.Value;
         Umbuchung.Betrag = monBetrag.Value;
         Umbuchung.Verwendung = tbxVerwendung.Text;
      }

      private Konto? GetSelectedKonto()
      {
         KontoComboboxItem? selectedItem = cbxKonto.SelectedItem as KontoComboboxItem;
         if (selectedItem != null)
         {
            return selectedItem.Konto;
         }
         else
         {
            return null;
         }
      }

      private void ValidateInput()
      {
         Konto? selectedKonto = GetSelectedKonto();
         if (selectedKonto == null)
         {
            throw new ValidationException($"Wählen Sie ein Gegenkonto aus");
         }

         if (monBetrag.Value == 0)
         {
            throw new ValidationException($"Geben Sie einen Betrag an");
         }
      }
   }
}
