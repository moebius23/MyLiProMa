using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleProjectManager.Models
{
    public class PlayerProfile
    {
        public int Id { get; set; }
		public string Pseudo { get; set; }
		public int MICoins { get; set; }

		[NotMapped]
		public Dictionary<EItemType, Item> SelectedItems { get; set; }
		public string SelectedItemsJson {
			get { return JsonConvert.SerializeObject(SelectedItems); }
			set { SelectedItems = JsonConvert.DeserializeObject<Dictionary<EItemType, Item>>(value); }
		}
		public List<Item> AvailableItems { get; set; }

        public Title SelectedTitle { get; set; }
        public List<Title> AvailableTitles { get; set; }

        public PlayerProfile()
        {
            AvailableItems = new List<Item>();
            AvailableTitles = new List<Title>();
        }

		public override bool Equals(object obj)
		{
			var profile = obj as PlayerProfile;
			return profile != null &&
				   Id == profile.Id;
		}

		public override int GetHashCode()
		{
			return 2108858624 + Id.GetHashCode();
		}

		public static bool operator ==(PlayerProfile profile1, PlayerProfile profile2)
		{
			return EqualityComparer<PlayerProfile>.Default.Equals(profile1, profile2);
		}

		public static bool operator !=(PlayerProfile profile1, PlayerProfile profile2)
		{
			return !(profile1 == profile2);
		}

	}
}
