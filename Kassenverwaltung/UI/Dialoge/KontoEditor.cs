using Kassenverwaltung.Database.Models;
using System.ComponentModel.DataAnnotations;

namespace Kassenverwaltung.UI.Dialoge
{
   public partial class KontoEditor : Form
   {
      public Konto Konto { get; private set; }

      public KontoEditor(Konto konto)
      {
         InitializeComponent();

         Konto = konto;
         SetupValues();
      }

      private void SetupValues()
      {
         tbxBezeichnung.Text = Konto.Name;
         tbxIBAN.Text = Konto.IBAN;
         tbxBIC.Text = Konto.BIC;
         moneyAnfang.Value = Konto.Anfangsbestand;
      }

      private void ValidateInput()
      {
         if (string.IsNullOrEmpty(tbxBezeichnung.Text))
         {
            throw new ValidationException($"Geben Sie eine Bezeichnung für das Konto an.");
         }
      }


      private void ApplyValues()
      {
         Konto.Name = tbxBezeichnung.Text;
         Konto.IBAN = tbxIBAN.Text;
         Konto.BIC = tbxBIC.Text;
         Konto.Anfangsbestand = moneyAnfang.Value;
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
   }
}
