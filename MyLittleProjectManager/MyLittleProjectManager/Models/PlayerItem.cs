using System.Collections.Generic;

namespace MyLittleProjectManager.Models
{
	public class PlayerItem
    {
		public int ItemId { get; set; }
		public Item Item { get; set; }

		public int PlayerId { get; set; }
		public PlayerProfile Player { get; set; }

		public override bool Equals(object obj)
		{
			var item = obj as PlayerItem;
			return item != null &&
				   ItemId == item.ItemId &&
				   PlayerId == item.PlayerId;
		}

		public override int GetHashCode()
		{
			var hashCode = 2004332272;
			hashCode = hashCode * -1521134295 + ItemId.GetHashCode();
			hashCode = hashCode * -1521134295 + PlayerId.GetHashCode();
			return hashCode;
		}

		public static bool operator ==(PlayerItem item1, PlayerItem item2)
		{
			return EqualityComparer<PlayerItem>.Default.Equals(item1, item2);
		}

		public static bool operator !=(PlayerItem item1, PlayerItem item2)
		{
			return !(item1 == item2);
		}
	}
}
