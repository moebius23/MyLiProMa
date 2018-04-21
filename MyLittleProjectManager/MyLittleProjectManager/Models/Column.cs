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

		public override bool Equals(object obj)
		{
			var column = obj as Column;
			return column != null &&
				   Id == column.Id;
		}

		public override int GetHashCode()
		{
			return 2108858624 + Id.GetHashCode();
		}

		public static bool operator ==(Column column1, Column column2)
		{
			return EqualityComparer<Column>.Default.Equals(column1, column2);
		}

		public static bool operator !=(Column column1, Column column2)
		{
			return !(column1 == column2);
		}
	}
}
