namespace Kassenverwaltung.Util
{
   public static class DateTimePickerExtensions
   {
      public static void SetValueSafe(this DateTimePicker target, DateTime value, DateTime @default)
      {
         try
         {
            target.Value = value;
         }
         catch
         {
            target.Value = @default;
         }
      }
   }
}
