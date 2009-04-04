using System.IO;
using System.Linq;
using StudioSnap.Automation;
using StudioSnap.Infrastructure;

namespace StudioSnap
{
    public class ProjectFileIncluder
    {
        public ISimpleLogger Log { get; set; }

        public void IncludeFile(string fileToAdd)
        {
            var newFilePath = Path.GetDirectoryName(fileToAdd);
            var projectPath = FindProjectFileFor(newFilePath);

            var studio = new Studio { Log = Log };
            var project = studio.FindProjectAt(projectPath);

            if (project != null)
                project.IncludeFile(fileToAdd);
        }

        private string FindProjectFileFor(string filePath)
        {
            Log.Info("Searching for project file in {0}", filePath);
            if (Directory.GetFiles(filePath).Any(file => file.EndsWith(".csproj") || file.EndsWith(".vbproj")))
                return filePath;

            var parentFolder = new DirectoryInfo(filePath).Parent;
            return parentFolder == null ? null :
                            FindProjectFileFor(parentFolder.FullName);
        }
    }
}