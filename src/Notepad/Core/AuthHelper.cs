using Notepad.src.Notepad.TestSuite;
using System.Diagnostics;

namespace Notepad.src.Notepad.Core
{
    public static class AuthHelper
    {
        public static Process LaunchApplication()
        {
            var ApplicationPath = Config.ApplicationPath;
            string realPath = ProcessHelper.FindAppPath(ApplicationPath);
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = realPath,
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Normal
            };

            return Process.Start(startInfo);
        }
    }
}
