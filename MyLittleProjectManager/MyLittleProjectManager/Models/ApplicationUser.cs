using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyLittleProjectManager.Models
{																							   
    public class ApplicationUser : IdentityUser
    {
		public PlayerProfile PlayerProfile { get; set; }

		public override bool Equals(object obj)
		{
			var user = obj as ApplicationUser;
			return user != null &&
				   EqualityComparer<PlayerProfile>.Default.Equals(PlayerProfile, user.PlayerProfile);
		}

		public override int GetHashCode()
		{
			return -916948691 + EqualityComparer<PlayerProfile>.Default.GetHashCode(PlayerProfile);
		}

		public static bool operator ==(ApplicationUser user1, ApplicationUser user2)
		{
			return EqualityComparer<ApplicationUser>.Default.Equals(user1, user2);
		}

		public static bool operator !=(ApplicationUser user1, ApplicationUser user2)
		{
			return !(user1 == user2);
		}

	}
}
