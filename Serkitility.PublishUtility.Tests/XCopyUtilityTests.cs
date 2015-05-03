using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
namespace SerqUtil.PublishUtility.Tests
{
    [TestClass]
    public class XCopyUtilityTests
    {
        [TestMethod]
        public void Copy()
        {
           var appSettings = ConfigurationManager.AppSettings;
           string fromPath = appSettings["FromPath"];
           string toPath = appSettings["ToPath"];
           string[] excludedFiles = appSettings["ExcludedFiles"].Split(new char[] { ',' });
           XCopyUtility.Copy(fromPath, toPath,"test1.txt","test2.txt","test3.txt");
        }
    }
}
