using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.src.Notepad.TestSuite.TestCases
{
    public class TestBase : TestSuiteSetup
    {
        [Test]
        public void Login()
        {
           
            Log.Information($"Enter email :{Config.UserEmail}");
            Log.Information($"Enter password :{Config.UserPassword}");
          

        }

        [Test]
        public void AddToCourse()
        {
            Log.Information("Add to course");
            Log.Information("Create quizz");
        }

        [Test]
        public void FaileCase()
        {
            Assert.Fail();
        }
    }
}
