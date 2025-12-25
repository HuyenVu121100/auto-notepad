using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Notepad.src.Notepad.TestSuite
{
    
    public static class Config
    {
        private static readonly IConfigurationRoot Configuration;

      
        static Config()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                Configuration = new ConfigurationBuilder()
                    .SetBasePath(baseDir)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                ApplicationPath = Configuration["ApplicationPath"];
                UserEmail = Configuration["UserEmail"];
            }
            catch (Exception ex)
            {
              
                Console.WriteLine($"[FATAL ERROR] : {ex.Message}");
            }
        }

       
        public static string ApplicationPath { get; private set; }
        public static string UserEmail { get; private set; }
    }
}