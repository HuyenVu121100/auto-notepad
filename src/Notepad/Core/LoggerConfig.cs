using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.src.Notepad.Core
{
    internal class LoggerConfig
    {
        public static void InitializeLogger()
        {

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string reportFolder = Path.Combine(baseDirectory, "../../../Reports");

            if (!Directory.Exists(reportFolder))
            {
                Directory.CreateDirectory(reportFolder);
            }


            string logFilePath = Path.Combine(reportFolder, "Log-.html");

            Console.WriteLine($"Log file created at: {logFilePath}");

            Console.WriteLine($"save path: {logFilePath}");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(
                    logFilePath,
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "<div>{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}</div>"
                )
                .CreateLogger();
        }


        public static void ShutdownLogger()

        {

            Log.CloseAndFlush();

        }
    }
}
