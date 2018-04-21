using System.Collections.Generic;

namespace MyLittleProjectManager.Models
{
	public class PlayerProject
    {
		public int ProjectId { get; set; }
		public Project Project { get; set; }

		public int PlayerId { get; set; }
		public PlayerProfile Player { get; set; }

		public override bool Equals(object obj)
		{
			var project = obj as PlayerProject;
			return project != null &&
				   ProjectId == project.ProjectId &&
				   PlayerId == project.PlayerId;
		}

		public override int GetHashCode()
		{
			var hashCode = -962533896;
			hashCode = hashCode * -1521134295 + ProjectId.GetHashCode();
			hashCode = hashCode * -1521134295 + PlayerId.GetHashCode();
			return hashCode;
		}

		public static bool operator ==(PlayerProject project1, PlayerProject project2)
		{
			return EqualityComparer<PlayerProject>.Default.Equals(project1, project2);
		}

		public static bool operator !=(PlayerProject project1, PlayerProject project2)
		{
			return !(project1 == project2);
		}
	}
}
