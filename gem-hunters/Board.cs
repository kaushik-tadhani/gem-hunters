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
            Grid = new Cell[6, 6];

            for (int i = 0; i< 6;  i++)
            {
                for (int j = 0; j < 6; j++) 
                {
                    Grid[i, j] = new Cell("-");
                }
            }

            Grid[0, 0] = new Cell("P1");
            Grid[5, 5] = new Cell("P2");

            int totalGemsPlaced = 0;
            Random random = new Random();
            while (totalGemsPlaced != 5) 
            { 
                int x = random.Next(0, 5);
                int y = random.Next(0, 5);

                Cell cell = Grid[x, y];

                if (cell.Occupant == "-" && cell.Occupant != "P1" && cell.Occupant != "P2")
                {
                    Grid[x, y] = new Cell("G");
                    totalGemsPlaced = totalGemsPlaced + 1;
                }
            }

            int totalObstaclesPlaced = 0;
            while (totalObstaclesPlaced != 5)
            {
                int x = random.Next(0, 5);
                int y = random.Next(0, 5);

                Cell cell = Grid[x, y];

                if (cell.Occupant == "-" && cell.Occupant != "P1" && cell.Occupant != "P2" && cell.Occupant != "G")
                {
                    Grid[x, y] = new Cell("O");
                    totalObstaclesPlaced  = totalObstaclesPlaced + 1;
                }
            }
        }

        public void Display()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Cell currentCell = Grid[i, j];
                    Console.Write($" {currentCell.Occupant} ");
                }
                Console.WriteLine();
            }
        }

        public void IsValidMove(Player player, char direction) 
        { }

        public void CollectGem(Player player)
        { 
        
        }
    }
}
