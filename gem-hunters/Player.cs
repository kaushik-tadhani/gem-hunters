using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace gem_hunters
{
    public class Player
    {
        // Player's name
        public string Name { get; set; }

        // Player's position on the board
        public Position Position { get; set; }

        // Number of gems collected by the player
        public int GemCount { get; set; }

        /// <summary>
        /// Constructor to initialize the player with a name and position
        /// </summary>
        /// <param name="name">Player name</param>
        /// <param name="position">Initial position of player</param>
        public Player(string name, Position position)
        {
            Name = name;
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
                case "U":
                    x = Math.Max(0, x - 1);
                    break;
                case "D":
                    x = Math.Min(5, x + 1);
                    break;
                case "L":
                    y = Math.Max(0, y - 1);
                    break;
                case "R":
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
