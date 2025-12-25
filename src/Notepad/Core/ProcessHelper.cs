namespace Notepad.src.Notepad.Core
{
    internal static class ProcessHelper
    {
        public static string FindAppPath(string appFileName)
        {
            string[] searchRoots =
            {
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                @"C:\"
            };

            foreach (var root in searchRoots)
            {
                if (string.IsNullOrEmpty(root) || !Directory.Exists(root)) continue;

                try
                {
                    var files = Directory.GetFiles(root, appFileName, SearchOption.AllDirectories);
                    if (files.Length > 0)
                        return files[0];
                }
                catch (UnauthorizedAccessException) { }
            }

            return null;
        }
    }
}
