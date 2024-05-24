namespace Kassenverwaltung.Util
{
   public class TempFileHelper
   {
      private readonly HashSet<string> _tempFiles = new();

      private static TempFileHelper? _inst;
      public static TempFileHelper Inst
      {
         get
         {
            if (_inst == null)
            {
               _inst = new TempFileHelper();
            }

            return _inst;
         }
      }

      private TempFileHelper()
      {
      }

      public void TryDeleteTempFiles()
      {
         HashSet<string> deletedFiles = new();

         foreach (var tempFile in _tempFiles)
         {
            try
            {
               File.Delete(tempFile);
               deletedFiles.Add(tempFile);
            }
            catch
            {
            }
         }

         foreach (var deletedFile in deletedFiles)
         {
            _tempFiles.Remove(deletedFile);
         }
      }

      public void Register(string file)
      {
         if (Path.Exists(file))
         {
            _tempFiles.Add(file);
         }
      }
   }
}
