using System.Collections.Generic;

namespace MyLittleProjectManager.Models
{
	public class Title
    {
		public int Id { get; set; }
		public int Price { get; set; }
        public string Text { get; set; }
		public List<PlayerTitle> PlayerTitles { get; set; }

		public Title()
		{
			PlayerTitles = new List<PlayerTitle>();
		}

		public override bool Equals(object obj)
		{
			var title = obj as Title;
			return title != null &&
				   Id == title.Id;
		}

		public override int GetHashCode()
		{
			return 2108858624 + Id.GetHashCode();
		}

		public static bool operator ==(Title title1, Title title2)
		{
			return EqualityComparer<Title>.Default.Equals(title1, title2);
		}

		public static bool operator !=(Title title1, Title title2)
		{
			return !(title1 == title2);
		}

	}
}
