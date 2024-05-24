namespace Kassenverwaltung.UI.UserControls
{
   public partial class SplitButton : UserControl
   {
      public class Option
      {
         public string Text { get; }
         public EventHandler? OnClicked { get; set; }

         public Option(string text)
         {
            Text = text;
         }
      }

      public new bool Enabled
      {
         get => btnMain.Enabled;
         set
         {
            btnMain.Enabled = value;
            btnContext.Enabled = value;
         }
      }

      public new string Text
      {
         get => btnMain.Text;
         set => btnMain.Text = value;
      }

      public Image? Image
      {
         get => btnMain.Image;
         set => btnMain.Image = value;
      }

      public event EventHandler? MainButtonClick;

      private readonly ContextMenuStrip _contextMenu = new ContextMenuStrip();

      public IList<Option> Options { get; } = new List<Option>();

      public SplitButton()
      {
         InitializeComponent();
      }

      private void OnClickedContextButton(object sender, EventArgs e)
      {
         _contextMenu.Items.Clear();

         if (Options.Count > 0)
         {
            foreach (var option in Options)
            {
               _contextMenu.Items.Add(option.Text, null, option.OnClicked);
            }

            var spawnPoint = PointToScreen(btnContext.Location);
            spawnPoint.Y += btnContext.Height;

            _contextMenu.Show(spawnPoint);
         }
      }

      private void OnMainButtonClicked(object sender, EventArgs e)
      {
         MainButtonClick?.Invoke(this, EventArgs.Empty);
      }
   }
}
