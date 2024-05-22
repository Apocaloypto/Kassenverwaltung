namespace Kassenverwaltung.Util
{
   public static class ListViewExtensions
   {
      public static void SelectItem<T>(this ListView listView, Func<T?, bool> predicate) where T : class
      {
         foreach (ListViewItem item in listView.Items)
         {
            T? data = item.Tag as T;
            if (predicate(data))
            {
               item.Focused = true;
               item.Selected = true;
               item.EnsureVisible();
               listView.Select();
               return;
            }
         }
      }
   }
}
