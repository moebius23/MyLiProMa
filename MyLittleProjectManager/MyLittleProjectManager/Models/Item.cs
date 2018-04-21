using System.Collections.Generic;

namespace MyLittleProjectManager.Models
{
	public enum EItemType
	{
		Avatar,
		Hat,
		Glasses,
		Tie,
		Shoes,
		Accessory
	}

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }
		public int Price { get; set; }
		public EItemType Type { get; set; }
		public List<PlayerItem> PlayerItems { get; set; }

		public Item()
		{
			PlayerItems = new List<PlayerItem>();
		}

		public override bool Equals(object obj)
		{
			var avatar = obj as Item;
			return avatar != null &&
				   Id == avatar.Id;
		}

		public override int GetHashCode()
		{
			return 2108858624 + Id.GetHashCode();
		}

		public static bool operator ==(Item avatar1, Item avatar2)
		{
			return EqualityComparer<Item>.Default.Equals(avatar1, avatar2);
		}

		public static bool operator !=(Item avatar1, Item avatar2)
		{
			return !(avatar1 == avatar2);
		}

	}
}
