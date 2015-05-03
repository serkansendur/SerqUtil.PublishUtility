using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Logging;
using Microsoft.Build.Execution;

namespace SerqUtil.PublishUtility
{
    public class MSBuildUtility
    {

        public static void Build(string solutionFileName,string configuration,string platform, string logFilePath=null)
        {
            FileLogger fl = new FileLogger();
            var buildManager = BuildManager.DefaultBuildManager;
            ProjectCollection pc = new ProjectCollection();
            var buildParameters = new BuildParameters(pc);
            if(!string.IsNullOrEmpty(logFilePath))
            {
                fl.Parameters = string.Concat("logfile=",logFilePath);
                buildParameters.Loggers = new List<Microsoft.Build.Framework.ILogger> { fl }.AsEnumerable();
            }
            Dictionary<string,string> GlobalProperty = new Dictionary<string,string>();
            GlobalProperty.Add("Configuration",configuration);
            GlobalProperty.Add("Platform",platform);
            BuildRequestData BuildRequest =  new BuildRequestData(solutionFileName, GlobalProperty,
            null, new string[] { "Build" }, null);
            BuildResult buildResult = buildManager.Build(buildParameters, BuildRequest);
        }
    }
}
