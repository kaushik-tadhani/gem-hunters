using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gem_hunters
{
    public class Game
    {
        public Board Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player CurrentPlayerTurn { get; set; }
        public int TotalTurns { get; set; }

        // Constructor initializes the game
        public Game()
        {
            // Initialize Player 1 at position (0, 0)
            Player1 = new Player("P1", new Position(0, 0));

            // Initialize Player 2 at position (5, 5)
            Player2 = new Player("P2", new Position(5, 5));

            // Initialize the total number of turns to 0
            TotalTurns = 0;

            // Set Player 1 as the current player
            CurrentPlayerTurn = Player1;

            // Create a new game board
            Board = new Board();
        }

        /// <summary>
        /// Method to start the game
        /// </summary>
        public void Start()
        {
            // Display the initial game board
            Board.Display();

            do
            {
                // Switch turns between players
                SwitchTurn();

                // Read player's input for movement directions
                string playerDirections = Console.ReadLine() ?? string.Empty;

                // Check if the player's move is valid
                bool isValidPosition = Board.IsValidMove(CurrentPlayerTurn, playerDirections);
                if (isValidPosition)
                {
                    // If the move is valid, move the player and collect gems if any
                    CurrentPlayerTurn.Move(playerDirections);
                    Board.CollectGem(CurrentPlayerTurn);
                }

                // Display the updated game board
                Board.Display();

            } while (!IsGameOver()); // Continue the loop until the game is over

            // Announce the winner
            AnnounceWinner();
        }

        /// <summary>
        /// Method to switch turns between players
        /// </summary>
        public void SwitchTurn()
        {
            // Increment the total number of turns
            TotalTurns++;

            // Switch the turn based on the total number of turns
            if (TotalTurns % 2 != 0)
            {
                CurrentPlayerTurn = Player1;
                Console.Write("Player 1 turn: ");
            }
            else
            {
                CurrentPlayerTurn = Player2;
                Console.Write("Player 2 turn: ");
            }
        }

        /// <summary>
        /// Method to check if the game is over. The game ends if the total number of turns reaches 30 or if the total number of collected gems by both players equals 7.
        /// </summary>
        /// <returns>Returns true if the game is over, otherwise false.</returns>
        public bool IsGameOver() => TotalTurns == 30 || (Player1.GemCount + Player2.GemCount) == 7;

        /// <summary>
        /// Method to announce the winner
        /// </summary>
        public void AnnounceWinner()
        {
            // Display the number of gems collected by each player
            Console.WriteLine($"Collected gems by {Player1.Name} : {Player1.GemCount}");
            Console.WriteLine($"Collected gems by {Player2.Name} : {Player2.GemCount}");

            // Determine and display the winner or if it's a tie
            if (Player1.GemCount == Player2.GemCount)
            {
                Console.WriteLine("It's a tie!");
            }
            else if (Player1.GemCount > Player2.GemCount)
            {
                Console.WriteLine($"{Player1.Name} is the winner!");
            }
            else
            {
                Console.WriteLine($"{Player2.Name} is the winner!");
            }
        }
    }
}
