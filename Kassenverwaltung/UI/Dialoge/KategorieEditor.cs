using Kassenverwaltung.Database.Models;
using System.ComponentModel.DataAnnotations;

namespace Kassenverwaltung.UI.Dialoge
{
   public partial class KategorieEditor : Form
   {
      public Kategorie Kategorie { get; }

      public KategorieEditor(Kategorie kategorie)
      {
         InitializeComponent();

         Kategorie = kategorie;
         SetupValues();
      }

      private void SetupValues()
      {
         tbxBezeichnung.Text = Kategorie.Name;
      }

      private void ValidateInput()
      {
         if (string.IsNullOrEmpty(tbxBezeichnung.Text))
         {
            throw new ValidationException($"Geben Sie eine Bezeichnung für die Kategorie an.");
         }
      }

      private void ApplyValues()
      {
         Kategorie.Name = tbxBezeichnung.Text;
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
