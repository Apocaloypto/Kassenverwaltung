using Kassenverwaltung.Database.Models;
using System.ComponentModel.DataAnnotations;

namespace Kassenverwaltung.UI.Dialoge
{
   public partial class AnhangEditor : Form
   {
      public Beleg Beleg { get; }

      public AnhangEditor(Beleg beleg)
      {
         InitializeComponent();

         Beleg = beleg;

         SetupValues();
      }

      private void SetupValues()
      {
         tbxName.Text = Beleg.Name;
         tbxPfad.Text = Beleg.Pfad;
         cbxLinkOnly.Enabled = Beleg.Blob == null || Beleg.Blob.Length == 0;
      }

      private void OnClickedSelectPfad(object sender, EventArgs e)
      {
         using (var ofd = new OpenFileDialog())
         {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
               tbxPfad.Text = ofd.FileName;
               if (string.IsNullOrEmpty(tbxName.Text))
               {
                  tbxName.Text = Path.GetFileNameWithoutExtension(tbxPfad.Text);
               }
            }
         }
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
         Beleg.Name = tbxName.Text;
         Beleg.Pfad = tbxPfad.Text;
         if (!cbxLinkOnly.Checked)
         {
            Beleg.Blob = File.ReadAllBytes(Beleg.Pfad);
         }
      }

      private void ValidateInput()
      {
         if (string.IsNullOrEmpty(tbxName.Text))
         {
            throw new ValidationException($"Geben Sie einen Dateinamen an");
         }

         if (!Path.Exists(tbxPfad.Text))
         {
            throw new ValidationException($"Die angegebene Datei konnte nicht gefunden werden");
         }
      }
   }
}
