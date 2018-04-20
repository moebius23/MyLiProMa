using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleProjectManager.Models
{
    public class Card
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
