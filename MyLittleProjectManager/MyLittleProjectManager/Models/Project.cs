using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyLittleProjectManager.Models
{
	public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public string Description { get; set; }
		public ObservableCollection<Column> Columns { get; set; }
		public List<PlayerProject> PlayerProjects { get; set; }

		public Project()
        {
            Columns = new ObservableCollection<Column>();
			PlayerProjects = new List<PlayerProject>();
        }

		public override bool Equals(object obj)
		{
			var project = obj as Project;
			return project != null &&
				   Id == project.Id;
		}

		public override int GetHashCode()
		{
			return 2108858624 + Id.GetHashCode();
		}

		public static bool operator ==(Project project1, Project project2)
		{
			return EqualityComparer<Project>.Default.Equals(project1, project2);
		}

		public static bool operator !=(Project project1, Project project2)
		{
			return !(project1 == project2);
		}
	}
}
