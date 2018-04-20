using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleProjectManager.Models
{
    public class PlayerProfile
    {
        public int Id { get; set; }
        public int MICoins { get; set; }

        public AnimalAvatar SelectedAvatar { get; set; }
        public List<AnimalAvatar> AvailableAnimals { get; set; }
        public Title SelectedTitle { get; set; }
        public List<Title> AvailableTitles { get; set; }

        public PlayerProfile()
        {
            AvailableAnimals = new List<AnimalAvatar>();
            AvailableTitles = new List<Title>();
        }

    }
}
