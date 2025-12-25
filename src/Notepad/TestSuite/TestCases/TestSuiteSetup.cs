using Notepad.src.Notepad.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Serilog;
using System.Diagnostics;

namespace Notepad.src.Notepad.TestSuite.TestCases;

[TestFixture]
public class TestSuiteSetup
{
    private Process _process;

    [SetUp]
    public void SetUp()
    {
        Log.Information("----------------------------------------------------------");
        Log.Information($"STARTING TEST: {TestContext.CurrentContext.Test.Name}");

        _process = Process.Start("notepad.exe");

        Assert.That(_process, Is.Not.Null);
        Log.Information("Notepad opened");
    }

    [TearDown]
    public void Teardown()
    {
        var testCaseName = TestContext.CurrentContext.Test.Name;
        var priority =  "Low";
        var status = TestContext.CurrentContext.Result.Outcome.Status;

        if (status == TestStatus.Passed)
        {
            Log.Information($"[PASS] {testCaseName} | Priority: {priority}");
            UpdateSummaryCounters(priority, true);
        }
        else if (status == TestStatus.Failed)
        {
            Log.Error($"[FAIL] {testCaseName} | Priority: {priority}");
            Log.Error($"Reason: {TestContext.CurrentContext.Result.Message}");
            UpdateSummaryCounters(priority, false);
        }

       
        if (_process != null && !_process.HasExited)
        {
            _process.CloseMainWindow();   
            _process.WaitForExit(3000);

            if (!_process.HasExited)
                _process.Kill();         
        }

        Log.Information("Notepad closed");
        Log.Information($"FINISHED TEST: {testCaseName}");
        Log.Information("----------------------------------------------------------");
    }

    private void UpdateSummaryCounters(string priority, bool isPassed)
    {
        // TODO: implement if needed
    }
}
