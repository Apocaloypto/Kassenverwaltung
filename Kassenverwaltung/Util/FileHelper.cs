using System.Diagnostics;

namespace Kassenverwaltung.Util
{
   public static class FileHelper
   {
      public static string GenerateTempFilename(string extension)
      {
         string tempPath = Path.GetTempPath();
         string filename = $"{Guid.NewGuid()}{extension}";

         return Path.Combine(tempPath, filename);
      }

      public static void OpenFileWithDefaultProgram(string path)
      {
         using Process process = new Process();
         process.StartInfo.FileName = "explorer.exe";
         process.StartInfo.Arguments = $"\"{path}\"";
         process.StartInfo.UseShellExecute = false;

         process.Start();
      }
   }
}
