using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleProjectManager.Models
{
    public class StoreViewModel
    {
        public PlayerProfile Profile { get; set; }
        public List<Item> StoreItems { get; set; }
        
        public List<Item> BoughtItems { get; set; }
    }
}
