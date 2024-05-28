using Kassenverwaltung.Util;
using Kassenverwaltung.Util.BewegungImporter;
using System.ComponentModel.DataAnnotations;

namespace Kassenverwaltung.UI.Dialoge
{
   public partial class BewegungsImporter : Form
   {
      private class ImportFormatComboboxItem
      {
         public ImportFormat Format { get; }

         public ImportFormatComboboxItem(ImportFormat format)
         {
            Format = format;
         }

         public override string ToString()
         {
            return Format.GetValueName();
         }
      }

      public ImportFormat ImportFormat { get; private set; }
      public string? ImportFile { get; private set; }

      public BewegungsImporter()
      {
         InitializeComponent();

         FillFormateCbx();
         cbxFormat.SelectItem((ImportFormatComboboxItem item) => item?.Format == ImportFormat.CsvCamtv2);
      }

      private void FillFormateCbx()
      {
         cbxFormat.Items.Clear();
         foreach (var importFormat in EnumExtensions.GetIterator<ImportFormat>())
         {
            cbxFormat.Items.Add(new ImportFormatComboboxItem(importFormat));
         }
      }

      private void OnSelectPath(object sender, EventArgs e)
      {
         using (var ofd = new OpenFileDialog())
         {
            ofd.Filter = "Alle Dateien (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
               tbxPath.Text = ofd.FileName;
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
            MessageService.ShowError($"Fehler: {ex.Message}", "Fehler");
         }
      }

      private void ApplyValues()
      {
         ImportFormat = GetSelectedImportFormat()!.Value;
         ImportFile = tbxPath.Text;
      }

      private ImportFormat? GetSelectedImportFormat()
      {
         ImportFormatComboboxItem? selectedImpFormat = cbxFormat.SelectedItem as ImportFormatComboboxItem;
         return selectedImpFormat?.Format;
      }

      private void ValidateInput()
      {
         if (!File.Exists(tbxPath.Text))
         {
            throw new ValidationException($"Geben Sie einen Pfad zu einer Datei an.");
         }

         if (GetSelectedImportFormat() == null)
         {
            throw new ValidationException($"Wählen Sie ein Importformat aus.");
         }
      }
   }
}
