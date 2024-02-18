namespace GemHunters
{
    public class Player
    {
        // Player's name
        public string Name { get; set; }
        // Player's alias name(e.g P1 or P2)
        public string Alias { get; set; }
        // Player's position on the board
        public Position Position { get; set; }
        // Number of gems collected by the player
        public int GemCount { get; set; }

        /// <summary>
        /// Constructor to initialize the player with a name and position
        /// </summary>
        /// <param name="name">Player name</param>
        /// <param name="position">Initial position of player</param>
        public Player(string name, string alias, Position position)
        {
            Name = name;
            Alias = alias;
            Position = position;
            GemCount = 0; // Initialize gem count to zero
        }

        /// <summary>
        /// Method to move the player in a given direction
        /// </summary>
        /// <param name="direction">Direction (U, D, L and R)</param>
        public void Move(string direction)
        {
            int x = Position.X;
            int y = Position.Y;

            // Update coordinates based on the direction
            switch (direction)
            {
                case GameMovement.UP:
                    x = Math.Max(0, x - 1);
                    break;
                case GameMovement.DOWN:
                    x = Math.Min(5, x + 1);
                    break;
                case GameMovement.LEFT:
                    y = Math.Max(0, y - 1);
                    break;
                case GameMovement.RIGHT:
                    y = Math.Min(5, y + 1);
                    break;
                default:
                    Console.WriteLine("Invalid input. You miss your turn !!!");
                    break;
            }

            // Ensure the player stays within the bounds of the board
            if (x > 5) x = 5;
            if (y > 5) y = 5;

            // Update the player's position
            Position = new Position(x, y);
        }
    }
}
