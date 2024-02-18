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

        public Game() 
        { 
            Player1 = new Player("P1", new Position(0, 0));
            Player2 = new Player("P2", new Position(5, 5));
            TotalTurns = 0;
            CurrentPlayerTurn = Player1;
            Board = new Board();
        }

        public void Start() 
        {
            Board.Display();
            do
            {
                SwitchTurn();
                string playerDirections = Console.ReadLine() ?? string.Empty;

                bool isValidPosistion = Board.IsValidMove(CurrentPlayerTurn, playerDirections);
                if (isValidPosistion)
                {
                    Board.CollectGem(CurrentPlayerTurn);
                }

                Board.Display();
            } while (!IsGameOver());
        }

        public void SwitchTurn() 
        {
            TotalTurns = TotalTurns + 1;
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

        public bool IsGameOver() => TotalTurns == 30;

        public void AnnounceWinner()
        { 
        
        }
    }
}
