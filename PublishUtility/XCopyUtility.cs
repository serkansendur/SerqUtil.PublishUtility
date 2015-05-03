using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerqUtil.PublishUtility
{
    public class XCopyUtility
    {
        public static void Copy(string fromPath, string toPath, params string[] exludedFiles)
        {
            exludedFiles = exludedFiles.Select(f => f.ToLowerInvariant()).ToArray();
            ClearFolder(toPath, exludedFiles);
            CopyContent(fromPath, toPath, exludedFiles);
        }

        private static void ClearFolder(string FolderName, params string[] exludedFiles)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                if (!exludedFiles.Contains(fi.Name.ToLowerInvariant()))
                {
                    fi.IsReadOnly = false;
                    fi.Delete();
                }
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                ClearFolder(di.FullName,exludedFiles);
                try
                {
                    di.Delete();
                }
                catch
                {
                    // it won't be able to delete a directory if that is not empty because of the excludedFiles
                }
            }
        }

        private static void CopyContent(string from, string to, params string[] exludedFiles)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(from, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(from, to));

            //Copy all the files
            foreach (string newPath in Directory.GetFiles(from, "*.*",
                SearchOption.AllDirectories))
            {
                string fileName = Path.GetFileName(newPath).ToLowerInvariant();
                if(!exludedFiles.Contains(fileName))
                {
                    File.Copy(newPath, newPath.Replace(from, to));
                }
            }
               
        }
    }
}
