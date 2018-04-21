using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleProjectManager.Models
{
    public class PlayerTitle
    {
		public int TitleId { get; set; }
		public Title Title { get; set; }

		public int PlayerId { get; set; }
		public PlayerProfile Player { get; set; }
	}
}
