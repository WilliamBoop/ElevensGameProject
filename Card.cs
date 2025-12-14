namespace ElevensConsole;
// Enum for the four suits in a standard deck
public enum Suit { Hearts, Diamonds, Clubs, Spades }
// Enum for ranks; Ace starts at 1, then goes up
public enum Rank
{
    Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
    Jack, Queen, King
}

public class Card
{
    public Suit Suit { get; }
    public Rank Rank { get; }

    // Constructor initializes the card with a suit and rank
    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    // For the “sum to 11” rule:
    public int PointValue =>
        Rank switch
        {
            Rank.Ace => 1,
            Rank.Two => 2,
            Rank.Three => 3,
            Rank.Four => 4,
            Rank.Five => 5,
            Rank.Six => 6,
            Rank.Seven => 7,
            Rank.Eight => 8,
            Rank.Nine => 9,
            Rank.Ten => 10,
            _ => 0 // Jack/Queen/King not used in 11-pairs
        };

    // Converts the card into a short, readable string for display
    public override string ToString()
    {
        string r = Rank switch
        {
            Rank.Ace => "A",
            Rank.Jack => "J",
            Rank.Queen => "Q",
            Rank.King => "K",
            _ => ((int)Rank).ToString()
        };

        string s = Suit switch
        {
            Suit.Hearts => "♥",
            Suit.Diamonds => "♦",
            Suit.Clubs => "♣",
            Suit.Spades => "♠",
            _ => "?"
        };

        return $"{r}{s}";
    }
}
