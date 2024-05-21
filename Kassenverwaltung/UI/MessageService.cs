namespace Kassenverwaltung.UI
{
   public static class MessageService
   {
      public static void ShowError(string message, string title)
      {
         MessageBox.Show(message, title);
      }

      public static bool ShowYesNo(string question, string title)
      {
         return MessageBox.Show(question, title, MessageBoxButtons.YesNo) == DialogResult.Yes;
      }
   }
}
