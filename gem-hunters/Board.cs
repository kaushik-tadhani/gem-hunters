using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace gem_hunters
{
    public class Board
    {
        // Represents the grid of cells
        public Cell[,] Grid { get; set; }

        /// <summary>
        /// Constructor initializes the board
        /// </summary>
        public Board()
        {
            // Create a 6x6 grid of cells
            Grid = new Cell[6, 6];

            // Initialize each cell with an empty string "-"
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Grid[i, j] = new Cell("-");
                }
            }

            // Place Player 1 at (0, 0) and Player 2 at (5, 5)
            Grid[0, 0] = new Cell("P1");
            Grid[5, 5] = new Cell("P2");

            // Place gems and obstacles
            PlaceGems();
            PlaceObstacles();
        }

        /// <summary>
        /// Places gems randomly on the board
        /// </summary>
        private void PlaceGems()
        {
            // Place gems randomly until 7 gems are placed
            int totalGemsPlaced = 0;
            Random random = new Random();
            while (totalGemsPlaced != 7)
            {
                int x = random.Next(0, 6);
                int y = random.Next(0, 6);

                Cell cell = Grid[x, y];

                // If the cell is empty and not occupied by a player, place a gem
                if (cell.Occupant == "-" && cell.Occupant != "P1" && cell.Occupant != "P2")
                {
                    Grid[x, y] = new Cell("G");
                    totalGemsPlaced++;
                }
            }
        }

        /// <summary>
        /// Places obstacles randomly on the board
        /// </summary>
        private void PlaceObstacles()
        {
            // Place obstacles randomly until 7 obstacles are placed
            int totalObstaclesPlaced = 0;
            Random random = new Random();
            while (totalObstaclesPlaced != 7)
            {
                // Ensure that obstacles are not placed at the edges to avoid surrounding players
                int x = random.Next(1, 5);
                int y = random.Next(1, 5);

                Cell cell = Grid[x, y];

                // If the cell is empty and not occupied by a player, place an obstacle
                if (cell.Occupant == "-" && cell.Occupant != "P1" && cell.Occupant != "P2")
                {
                    Grid[x, y] = new Cell("O");
                    totalObstaclesPlaced++;
                }
            }
        }

        /// <summary>
        /// Displays the current state of the board
        /// </summary>
        public void Display()
        {
            Console.Write("\n");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Cell currentCell = Grid[i, j];
                    Console.Write(string.Format("{0, -4}", currentCell.Occupant));
                }
                Console.Write("\n");
            }
        }

        /// <summary>
        /// Checks if a move is valid for a player in a given direction
        /// </summary>
        /// <param name="player">Current player</param>
        /// <param name="direction">Direction of movement</param>
        /// <returns>Returns true if the move is valid or there is not an obstacle, otherwise false.</returns>
        public bool IsValidMove(Player player, string direction)
        {
            Position position = player.Position;
            int x = position.X;
            int y = position.Y;
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
                    Console.WriteLine("\nInvalid input. You miss your turn !!!");
                    break;
            }

            // Ensure the position is within matrix edges
            if (x > 5) x = 5;
            if (y > 5) y = 5;

            // Check if the move is valid (not an obstacle)
            bool isValidMove = Grid[x, y].Occupant != "O" && !Grid[x, y].Occupant.Contains('P');

            if (isValidMove)
            {
                // Update the previous cell's occupant to empty
                Grid[position.X, position.Y].Occupant = "-";
            }

            return isValidMove;
        }

        /// <summary>
        /// Checks and collects gem at the player's position
        /// </summary>
        /// <param name="player">Current player</param>
        public void CollectGem(Player player)
        {
            Position position = player.Position;
            if (Grid[position.X, position.Y].Occupant == "G")
            {
                player.GemCount++;
                Console.WriteLine($"\nYeah! {player.Name} got a gem!");
            }
            Grid[position.X, position.Y].Occupant = player.Alias;
        }
    }
}
