namespace ElevensConsole;

public class Board
{
    // Reference to the deck (used to replace removed cards)
    private readonly Deck _deck;

    // Array holding the 9 active cards on the board
    // Some slots can be null when cards are removed
    private readonly Card?[] _slots = new Card?[9];

    // Constructor receives a deck to draw cards from
    public Board(Deck deck)
    {
        _deck = deck;
    }

    // Deals the initial 9 cards onto the board
    public void DealInitial()
    {
        for (int i = 0; i < _slots.Length; i++)
            _slots[i] = _deck.Deal();
    }

    // Displays the board to the console
    public void Display()
    {
        Console.WriteLine("\nBoard:");
        for (int i = 0; i < _slots.Length; i++)
        {
            string text = _slots[i] is null ? "(empty)" : _slots[i]!.ToString();
            Console.WriteLine($"{i + 1}: {text}");
        }
        Console.WriteLine($"Deck remaining: {_deck.Remaining}\n");
    }

    // Checks if the selected indices represent a valid move
    public bool IsValidSelection(List<int> indices)
    {
        // Indices are 0-8 !!!
        if (indices.Count != 2 && indices.Count != 3) return false;
        if (indices.Any(i => i < 0 || i > 8)) return false;
        if (indices.Distinct().Count() != indices.Count) return false;
        if (indices.Any(i => _slots[i] is null)) return false;

        if (indices.Count == 2)
        {
            int sum = _slots[indices[0]]!.PointValue + _slots[indices[1]]!.PointValue;
            return sum == 11;
        }

        // Indices.Count == 3 => must be J, Q, K
        var ranks = indices.Select(i => _slots[i]!.Rank).ToList();
        return ranks.Contains(Rank.Jack) && ranks.Contains(Rank.Queen) && ranks.Contains(Rank.King);
    }

    // Removes selected cards and replaces them with new ones from the deck
    public void RemoveAndReplace(List<int> indices)
    {
        // Remove cards (set slots to null)
        foreach (int i in indices)
            _slots[i] = null;

        // Replace removed cards if deck still has cards
        foreach (int i in indices)
        {
            if (_deck.Remaining > 0)
                _slots[i] = _deck.Deal();
        }
    }

    // Checks if there is at least one valid move on the board
    public bool HasAnyMove()
    {
        // Check for 11-pair
        List<int> active = Enumerable.Range(0, 9).Where(i => _slots[i] != null).ToList();

        for (int a = 0; a < active.Count; a++)
        {
            for (int b = a + 1; b < active.Count; b++)
            {
                int i = active[a], j = active[b];
                if (_slots[i]!.PointValue + _slots[j]!.PointValue == 11) return true;
            }
        }

        // Check for JQK triple
        bool hasJ = active.Any(i => _slots[i]!.Rank == Rank.Jack);
        bool hasQ = active.Any(i => _slots[i]!.Rank == Rank.Queen);
        bool hasK = active.Any(i => _slots[i]!.Rank == Rank.King);

        return hasJ && hasQ && hasK;
    }

    // Checks if the board is completely cleared and the deck is empty
    public bool IsCleared()
    {
        return _slots.All(c => c == null) && _deck.Remaining == 0;
    }
}
