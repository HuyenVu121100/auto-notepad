using NUnit.Framework;
using Serilog;
using Notepad.src.Notepad.Core;

namespace Notepad.src.Notepad.TestSuite;

[SetUpFixture]
public class TestFixtureSetup
{
    [OneTimeSetUp]
    public void GlobalSetup()
    {
        // Initialize Serilog with HTML formatting support
        LoggerConfig.InitializeLogger();

        TestContext.WriteLine("=== GLOBAL SETUP INITIALIZED ===");

        // Professional Header for the HTML Report
        Log.Information("<div style='background-color: #e3f2fd; padding: 15px; border-radius: 5px; border-left: 5px solid #2196F3;'>");
        Log.Information("<h2>📊 AUTOMATION EXECUTION REPORT</h2>");
        Log.Information($"<p><b>Execution Start:</b> {DateTime.Now:yyyy-MM-dd HH:mm:ss}</p>");
        Log.Information($"<p><b>Environment:</b> Windows Desktop (Notepad App)</p>");
        Log.Information("</div>");
        Log.Information("<hr />");
    }

    [OneTimeTearDown]
    public void GlobalTearDown()
    {
        Log.Information("<hr />");
        Log.Information("<div style='background-color: #f5f5f5; padding: 10px; border-radius: 5px;'>");
        Log.Information("<h3>🏁 TEST RUN COMPLETED</h3>");
        Log.Information($"<p><b>Finish Time:</b> {DateTime.Now:yyyy-MM-dd HH:mm:ss}</p>");
        Log.Information("</div>");

        // Ensure all logs are written before closing
        LoggerConfig.ShutdownLogger();

        TestContext.WriteLine("=== GLOBAL TEARDOWN COMPLETED ===");
    }
}