using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleProjectManager.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Column> Columns { get; set; }

        public Project()
        {
            Columns = new ObservableCollection<Column>();
        }
    }
}
