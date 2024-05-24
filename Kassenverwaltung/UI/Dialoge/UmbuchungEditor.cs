using Kassenverwaltung.Database.Models;
using Kassenverwaltung.Util;

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
            Konto? zielKonto = DataManger.FindKontoZuBewegung(Umbuchung.iBewegung.Value);
            if (zielKonto != null)
            {
               cbxKonto.SelectItem((KontoComboboxItem item) => item.Konto.Id == zielKonto.Id);
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

      }
   }
}
