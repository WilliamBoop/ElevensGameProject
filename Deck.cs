namespace ElevensConsole;

public class Deck
{
    // List that stores all cards currently in the deck
    private readonly List<Card> _cards = new();
 
    // Constructor builds a full 52-card deck
    public Deck()
    {
        // Build 52 cards
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                _cards.Add(new Card(suit, rank));
            }
        }
    }
  
    // Returns how many cards are left in the deck
    public int Remaining => _cards.Count;

    public void Shuffle()
    {
        // Fisher-Yates shuffle
        Random rng = new Random();
        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (_cards[i], _cards[j]) = (_cards[j], _cards[i]);
        }
    }

    // Deals one card from the top of the deck
    // Returns null if the deck is empty
    public Card? Deal()
    {
        if (_cards.Count == 0) return null;
        Card top = _cards[^1];
        _cards.RemoveAt(_cards.Count - 1);
        return top;
    }
}
