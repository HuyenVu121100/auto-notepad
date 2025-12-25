
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.src.Notepad.TestSuite.TestCases
{
    public class TestBase : NotepadTestSuiteBase
    {
        [Test]
        public void Login()
        {
           
            Log.Information("Enter email : vuhuyen@gmail.com");
            Log.Information("Enter password : 12345464");
          

        }

        [Test]
        public void AddToCourse()
        {
            Log.Information("Add to course");
            Log.Information("Create quizz");
        }
    }
}
