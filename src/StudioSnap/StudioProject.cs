using EnvDTE;

namespace StudioSnap
{
    public class StudioProject
    {
        private readonly Project _project;

        public StudioProject(Project project)
        {
            _project = project;
        }

        public string Directory
        {
            get { return _project.FileName; }
        }

        public void IncludeFile(string file)
        {
            var items = _project.ProjectItems;
            items.AddFromFile(file);
        }
    }
}