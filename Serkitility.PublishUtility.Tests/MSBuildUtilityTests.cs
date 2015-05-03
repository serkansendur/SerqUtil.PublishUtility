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
    public class MSBuildUtilityTests
    {
        [TestMethod]
        public void Build()
        {
            var appSettings = ConfigurationManager.AppSettings;
            string solutionFileName = appSettings["SolutionFileName"];
            string configuration = appSettings["Configuration"];
            string platform = appSettings["Platform"];
            string logFilePath = appSettings["LogFilePath"];
            MSBuildUtility.Build(solutionFileName, configuration, platform,logFilePath);
        }
    }
}
