namespace GemHunters
{
    public class Game
    {
        public Board Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player CurrentPlayerTurn { get; set; }
        public int TotalTurns { get; set; }

        /// <summary>
        /// Constructor initializes the game
        /// </summary>
        /// <param name="player1Name">Player 1's actual name</param>
        /// <param name="player2Name">Player 2's actual name</param>
        public Game(string player1Name, string player2Name)
        {
            // Initialize Player 1 at position (0, 0)
            Player1 = new Player(player1Name, GameElement.PLAYER_1_ALIAS, new Position(0, 0));

            // Initialize Player 2 at position (5, 5)
            Player2 = new Player(player2Name, GameElement.PLAYER_2_ALIAS, new Position(5, 5));

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
                while (!IsValidUserInput(playerDirections))
                {
                    Console.Write("\nInvalid user input. Please enter (U-Up, D-Down, L-Left, R-Right): ");
                    playerDirections = Console.ReadLine() ?? string.Empty;
                }

                playerDirections = playerDirections.ToUpper();
                
                // Check if the player's move is valid
                bool isValidPosition = Board.IsValidMove(CurrentPlayerTurn, playerDirections);
                if (isValidPosition)
                {
                    // If the move is valid, move the player and collect gems if any
                    CurrentPlayerTurn.Move(playerDirections);
                    Board.CollectGem(CurrentPlayerTurn);
                }
                else
                {
                    Console.WriteLine("\nYou cannot move onto or through squares containing obstacles or another player!");
                }

                // Display the updated game board
                Board.Display();

            } while (!IsGameOver()); // Continue the loop until the game is over

            // Announce the winner
            AnnounceWinner();
        }

        /// <summary>
        /// Validate user input from console.
        /// </summary>
        /// <param name="userInput">Received input on console.</param>
        /// <returns></returns>
        private bool IsValidUserInput(string userInput)
        {
            userInput = userInput.ToUpper();
            switch (userInput)
            {
                case GameMovement.UP:
                    return true;
                case GameMovement.DOWN:
                    return true;
                case GameMovement.RIGHT:
                    return true;
                case GameMovement.LEFT:
                    return true;
                default :
                    return false;
            }
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
            }
            else
            {
                CurrentPlayerTurn = Player2;
            }

            Console.Write($"\n{CurrentPlayerTurn.Name}'s turn({CurrentPlayerTurn.Alias}). Please enter (U-Up, D-Down, L-Left, R-Right): ");
        }

        /// <summary>
        /// Method to check if the game is over. The game ends if the total number of turns finished or if the total number of collected gems by both players.
        /// </summary>
        /// <returns>Returns true if the game is over, otherwise false.</returns>
        public bool IsGameOver() => TotalTurns == GameElement.TOTAL_PLAYER_TURNS || (Player1.GemCount + Player2.GemCount) == GameElement.TOTAL_GEM;

        /// <summary>
        /// Method to announce the winner
        /// </summary>
        public void AnnounceWinner()
        {
            Console.WriteLine("\n****** Game Over ******");

            // Display the number of gems collected by each player
            Console.WriteLine($"\nCollected gems by {Player1.Name} : {Player1.GemCount}");
            Console.WriteLine($"\nCollected gems by {Player2.Name} : {Player2.GemCount}");

            // Determine and display the winner or if it's a tie
            if (Player1.GemCount == Player2.GemCount)
            {
                Console.WriteLine("\nIt's a tie!");
            }
            else if (Player1.GemCount > Player2.GemCount)
            {
                Console.WriteLine($"\n{Player1.Name} is the winner!");
            }
            else
            {
                Console.WriteLine($"\n{Player2.Name} is the winner!");
            }
        }
    }
}
