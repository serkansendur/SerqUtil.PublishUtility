using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.Client;

namespace SerqUtil.PublishUtility
{
    public class TFSUtility
    {

        public static void GetLatest(string branchName,
            string workspaceName, Uri projectCollectionURI)
        {
            TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(projectCollectionURI);
            tfs.EnsureAuthenticated();
            VersionControlServer sourceControl = (VersionControlServer)tfs.GetService(typeof(VersionControlServer));

            Workspace workspace = sourceControl.QueryWorkspaces(workspaceName, sourceControl.AuthenticatedUser, Workstation.Current.Name)[0];
            GetRequest request = new GetRequest(new ItemSpec(branchName, RecursionType.Full), VersionSpec.Latest);
            GetStatus status = workspace.Get(request, GetOptions.GetAll | GetOptions.Overwrite); // this line doesn't do anything - no failures or errors

        }
    }
}
