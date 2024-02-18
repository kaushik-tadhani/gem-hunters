using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemHunters
{
    public static class GameElement
    {
        public const string PLAYER_1_ALIAS = "P1";
        public const string PLAYER_2_ALIAS = "P2";
        public const string GEM = "G";
        public const string OBSTACLE = "O";
        public const string EMPTY_SPACE = "-";
        public const int TOTAL_GEM = 7;
        public const int TOTAL_OBSTACLE = 7;
        public const int TOTAL_PLAYER_TURNS = 30;
    }

    public static class GameMovement
    {
        public const string UP = "U";
        public const string DOWN = "D";
        public const string RIGHT = "R";
        public const string LEFT = "L";
    }
}
