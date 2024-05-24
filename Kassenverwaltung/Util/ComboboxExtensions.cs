namespace Kassenverwaltung.Util
{
   public static class ComboboxExtensions
   {
      public static void SelectItem<T>(this ComboBox comboBox, Func<T, bool> predicate) where T : class
      {
         foreach (T item in comboBox.Items)
         {
            if (predicate(item))
            {
               comboBox.SelectedItem = item;
               return;
            }
         }
      }
   }
}
