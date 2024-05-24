using Kassenverwaltung.Database.Models;
using Kassenverwaltung.Util;
using System.ComponentModel.DataAnnotations;

namespace Kassenverwaltung.UI.Dialoge
{
   public partial class BewegungEditor : Form
   {
      private class KategorieComboboxItem
      {
         public Kategorie? Kategorie { get; }

         public KategorieComboboxItem(Kategorie? kategorie)
         {
            Kategorie = kategorie;
         }

         public override string ToString()
         {
            if (Kategorie == null)
            {
               return "<keine Kategorie>";
            }
            else
            {
               return Kategorie.Name!;
            }
         }
      }

      private KVManager DataManager { get; }
      private Konto Konto { get; }
      public Bewegung Bewegung { get; }

      public BewegungEditor(KVManager dataManager, Konto konto, Bewegung bewegung)
      {
         InitializeComponent();

         DataManager = dataManager;
         Konto = konto;
         Bewegung = bewegung;

         SetupValues();
      }

      private void SetupValues()
      {
         FillKategorieCombobox();

         cbxKategorie.SelectItem((KategorieComboboxItem item) => item.Kategorie?.Id == Bewegung.iKategorie);
         try
         {
            dtpDatum.Value = Bewegung.Datum;
         }
         catch
         {
            dtpDatum.Value = DateTime.Today;
         }

         monBetrag.Value = Bewegung.Betrag;
         tbxVerwendung.Text = Bewegung.Verwendung;
      }

      private void InsertKategorie(Kategorie? kategorie)
      {
         cbxKategorie.Items.Add(new KategorieComboboxItem(kategorie));
      }

      private void FillKategorieCombobox()
      {
         cbxKategorie.Items.Clear();

         IList<Kategorie> kategorien = DataManager.ListKategorien();
         InsertKategorie(null);
         foreach (var kategorie in kategorien)
         {
            InsertKategorie(kategorie);
         }
      }

      private void OnOK(object sender, EventArgs e)
      {
         try
         {
            ApplyValues();

            DialogResult = DialogResult.OK;
         }
         catch (ValidationException ex)
         {
            MessageService.ShowError($"Ungültiger Wert: {ex.Message}", "Fehler beim Übernehmen");
         }
      }

      private Kategorie? GetSelectedKategorie()
      {
         KategorieComboboxItem? cbxItem = cbxKategorie.SelectedItem as KategorieComboboxItem;
         if (cbxItem != null)
         {
            return cbxItem.Kategorie;
         }
         else
         {
            return null;
         }
      }

      private void ApplyValues()
      {
         Bewegung.iKonto = Konto.Id;
         Bewegung.iKategorie = GetSelectedKategorie()?.Id;
         Bewegung.Datum = dtpDatum.Value;
         Bewegung.Betrag = monBetrag.Value;
         Bewegung.Verwendung = tbxVerwendung.Text;
      }
   }
}
