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

        public Player CurrentTurn { get; set; }

        public int TotalTurns { get; set; }

        public Game() 
        { 
            Player1 = new Player("P1", new Position(0, 0));
            Player2 = new Player("P2", new Position(5, 5));

            CurrentTurn = Player1;
            TotalTurns = 0;

            Board = new Board();
        }

        public void Start() 
        { 
        
        }

        public void SwitchTurn() 
        { 
        
        }

        public void IsGameOver()
        { 
        
        }

        public void AnnounceWinner()
        { 
        
        }
    }
}
