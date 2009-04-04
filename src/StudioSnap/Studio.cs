using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using EnvDTE;

namespace StudioSnap
{
    public class Studio
    {
        public ISimpleLogger Log { get; set; }

        private readonly DTE _dte;

        public Studio()
        {
            Log = new NullLogger();

            _dte = Marshal.GetActiveObject("VisualStudio.DTE") as DTE;
            if (_dte == null)
                throw new Exception("Visual Studio is not running");
        }

        public string SolutionDirectory
        {
            get { return Path.GetDirectoryName(_dte.Solution.FullName); }
        }

        public StudioProject FindProjectAt(string path)
        {
            Log.Info("Finding project owner for {0}", path);

            var projects = ((object[]) _dte.ActiveSolutionProjects).Cast<Project>();
            var project = 
                projects.FirstOrDefault(
                    delegate(Project p) {
                            Log.Info("  Project: {0}", p.FileName);
                            return Path.GetDirectoryName(p.FileName).Equals(path, StringComparison.CurrentCultureIgnoreCase);
                        }
                    );

            if (project == null)
            {
                Log.Error("Couldn't find any project running to add file");
                return null;
            }
            Log.Info("Found project at {0}", project.FileName);
            return new StudioProject(project);
        }
    }
}