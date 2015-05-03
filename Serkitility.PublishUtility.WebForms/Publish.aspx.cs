using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
namespace SerqUtil.PublishUtility.WebForms
{
    public partial class Publish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string workspaceName = appSettings["WorkspaceName"];

            Uri projectCollectionURI = new Uri(appSettings["ProjectCollectionURI"]);
            string branchName = appSettings["BranchName"];

            TFSUtility.GetLatest(branchName, workspaceName, projectCollectionURI);

            string solutionFileName = appSettings["SolutionFileName"];
            string configuration = appSettings["Configuration"];
            string platform = appSettings["Platform"];
            string logFilePath = appSettings["LogFilePath"];
            MSBuildUtility.Build(solutionFileName, configuration, platform,logFilePath);

            string fromPath = appSettings["FromPath"];
            string toPath = appSettings["ToPath"];
            string[] excludedFiles = appSettings["ExcludedFiles"].Split(new char[]{','});

            XCopyUtility.Copy(fromPath, toPath,excludedFiles);
        }
    }
}