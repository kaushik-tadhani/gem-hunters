using GemHunters;

class Program
{
    // Main Method 
    static public void Main(string[] args)
    {
        Console.WriteLine("\n*** Welcome to Gem Hunters: Console Edition ***\n");

        // Prompt the user to enter the name for Player 1
        Console.Write("Please enter player 1 name : ");
        string player1Name = Console.ReadLine() ?? "P1";  // Default to "P1" if no input is provided

        // Prompt the user to enter the name for Player 2
        Console.Write("\nPlease enter player 2 name : ");
        string player2Name = Console.ReadLine() ?? "P2"; // Default to "P2" if no input is provided

        // Create a new game instance with the provided player names and start the game
        Game game = new Game(player1Name, player2Name);
        game.Start();

        Console.WriteLine("\nThank you for playing the game.");
    }
}