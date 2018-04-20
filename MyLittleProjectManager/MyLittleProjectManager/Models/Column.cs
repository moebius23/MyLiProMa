using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleProjectManager.Models
{
    public class Column
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Card> Cards { get; set; }

        public Column()
        {
            Cards = new ObservableCollection<Card>();
        }
    }
}
