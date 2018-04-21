using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleProjectManager.Models
{
    public class PlayerItem
    {
		public int ItemId { get; set; }
		public Item Item { get; set; }

		public int PlayerId { get; set; }
		public PlayerProfile Player { get; set; }
	}
}
