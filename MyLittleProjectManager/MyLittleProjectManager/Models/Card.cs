using System.Collections.Generic;

namespace MyLittleProjectManager.Models
{
	public class Card
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

		public override bool Equals(object obj)
		{
			var card = obj as Card;
			return card != null &&
				   Id == card.Id;
		}

		public override int GetHashCode()
		{
			return 2108858624 + Id.GetHashCode();
		}

		public static bool operator ==(Card card1, Card card2)
		{
			return EqualityComparer<Card>.Default.Equals(card1, card2);
		}

		public static bool operator !=(Card card1, Card card2)
		{
			return !(card1 == card2);
		}

	}
}
