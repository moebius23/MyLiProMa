using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleProjectManager.Models
{
    public class PlayerProject
    {
		public int ProjectId { get; set; }
		public Project Project { get; set; }

		public int PlayerId { get; set; }
		public PlayerProfile Player { get; set; }

	}
}
