using System;
using ElevensGame.GameLogic;

class Program
{
    static void Main()
    {
        // Card objects for testing
        Card card1 = new Card(5, "Hearts");
        Card card2 = new Card(10, "Spades");
        Card card3 = new Card(3, "Diamonds");

        // Print card details
        Console.WriteLine("Testing Card Class:");
        Console.WriteLine(card1);
        Console.WriteLine(card2);
        Console.WriteLine(card3);
    }
}

