using System.Collections.Generic;

namespace MyLittleProjectManager.Models
{
	public class PlayerTitle
    {
		public int TitleId { get; set; }
		public Title Title { get; set; }

		public int PlayerId { get; set; }
		public PlayerProfile Player { get; set; }

		public bool IsSelected { get; set; }

		public override bool Equals(object obj)
		{
			var title = obj as PlayerTitle;
			return title != null &&
				   TitleId == title.TitleId &&
				   PlayerId == title.PlayerId;
		}

		public override int GetHashCode()
		{
			var hashCode = -857101207;
			hashCode = hashCode * -1521134295 + TitleId.GetHashCode();
			hashCode = hashCode * -1521134295 + PlayerId.GetHashCode();
			return hashCode;
		}

		public static bool operator ==(PlayerTitle title1, PlayerTitle title2)
		{
			return EqualityComparer<PlayerTitle>.Default.Equals(title1, title2);
		}

		public static bool operator !=(PlayerTitle title1, PlayerTitle title2)
		{
			return !(title1 == title2);
		}
	}
}
