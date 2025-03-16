namespace ElevensGame.GameLogic
{
    public class Card
    {
        public int Rank { get; }  // Values 1-10, J, Q, K
        public string Suit { get; }  // Hearts, Diamonds, Clubs, Spades

        public Card(int rank, string suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}
