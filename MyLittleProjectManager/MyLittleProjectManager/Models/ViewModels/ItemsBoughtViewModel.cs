using System.Collections.Generic;

namespace MyLittleProjectManager.Models
{
	public class ItemsBoughtViewModel
    {
        public List<int> ItemsId { get; set; }
        public List<int> TitlesId { get; set; }
        public ItemsBoughtViewModel()
        {
            ItemsId = new List<int>();
            TitlesId = new List<int>();
        }
    }
}
