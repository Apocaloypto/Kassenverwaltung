namespace Kassenverwaltung.UI.UserControls
{
   public partial class MoneyInput : UserControl
   {
      public decimal Value
      {
         get => numInput.Value;
         set => numInput.Value = value;
      }

      public MoneyInput()
      {
         InitializeComponent();

         numInput.Minimum = decimal.MinValue;
         numInput.Maximum = decimal.MaxValue;
      }
   }
}
