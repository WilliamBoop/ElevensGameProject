namespace ElevensConsole;

public class GameManager
{
    private Deck _deck = null!;
    private Board _board = null!;
    public int Score { get; private set; }

    // Starts a new game
    public void StartGame()
    {
        _deck = new Deck();
        _deck.Shuffle();
        _board = new Board(_deck);
        _board.DealInitial();
        Score = 0;

        RunLoop();
    }

    // Main Game Loop
    private void RunLoop()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Score: {Score}\n");
            
            _board.Display();

            // Win condition
            if (_board.IsCleared())
            {
                Console.WriteLine("You win!");
                Console.WriteLine($"Final score: {Score}");
                return;
            }

            // Lose Condition
            if (!_board.HasAnyMove())
            {
                Console.WriteLine("No moves left. You lose.");
                Console.WriteLine($"Final score: {Score}");
                return;
            }

            Console.Write("Select 2 or 3 positions (e.g. '2 5' or '1 3 9'), or 'r' restart, 'q' quit: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) continue;
            input = input.Trim().ToLower();

            if (input == "q") return;
            if (input == "r")
            {
                StartGame();
                return;
            }

            // Parse user input into board indices
            List<int> indices = ParseIndices(input);
            if (indices.Count == 0)
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            if (_board.IsValidSelection(indices))
            {
                Score += 1;
                _board.RemoveAndReplace(indices);
                Console.WriteLine("Valid move!");
            }
            else
            {
                Console.WriteLine("Invalid move.");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            
        }
    }

    // Converts user input like "2 5" into zero-based indices
    private List<int> ParseIndices(string input)
    {
        // This expects 1-9 from the user, convert to 0-8
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        List<int> result = new();

        foreach (var p in parts)
        {
            if (!int.TryParse(p, out int num)) return new();
            if (num < 1 || num > 9) return new();
            result.Add(num - 1);
        }

        return result;
    }
}
