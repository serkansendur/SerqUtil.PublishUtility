using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
namespace SerqUtil.PublishUtility.Tests
{
    [TestClass]
    public class TFSUtilityTest
    {
        [TestMethod]
        public void GetLatest()
        {
            var appSettings = ConfigurationManager.AppSettings;
            string workspaceName = appSettings["WorkspaceName"];

            Uri projectCollectionURI = new Uri(appSettings["ProjectCollectionURI"]);
            string branchName = appSettings["BranchName"];
            TFSUtility.GetLatest(branchName, workspaceName, projectCollectionURI);
        }
    }
}