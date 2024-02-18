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
        public Cell[,] Grid { get; set; }

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

            PlaceGems();
            PlaceObstacles();

        }

        /// <summary>
        /// 
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
        /// 
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
        /// 
        /// </summary>
        public void Display()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Cell currentCell = Grid[i, j];
                    Console.Write($" {currentCell.Occupant} ");
                }
                Console.Write("\n");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="direction"></param>
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
                    x = Math.Max(0, x + 1);
                    break;
                case "L":
                    y = Math.Max(0, y - 1);
                    break;
                case "R":
                    y = Math.Max(0, y + 1);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again!!");
                    break;
            }

            if (x > 5) x = 5;
            if (y > 5) y = 5;

            bool isValidMove = Grid[x, y].Occupant != "O";

            if (isValidMove)
            {
                Grid[position.X, position.Y].Occupant = "-";
                player.Position = new Position(x, y);
            }

            return isValidMove;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void CollectGem(Player player)
        {
            Position position = player.Position;
            if (Grid[position.X, position.Y].Occupant == "G")
            {
                player.GemCount++;
            }

            Grid[position.X, position.Y].Occupant = player.Name;
        }
    }
}
