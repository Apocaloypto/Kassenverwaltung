using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Kassenverwaltung.Util
{
   public static class EnumExtensions
   {
      public static string GetValueName(this Enum value)
      {
         DisplayAttribute? displayAttribute = value.GetType()
            .GetMember(value.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>();

         if (displayAttribute != null && !string.IsNullOrEmpty(displayAttribute.Name))
         {
            return displayAttribute.Name;
         }
         else
         {
            return value.ToString();
         }
      }
   }
}
