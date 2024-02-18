using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gem_hunters
{
    public class Player
    {
        public string Name { get; set; }

        public Position Position { get; set; }

        public int GemCount { get; set; }

        public Player(string name, Position position) 
        {
            Name = name;
            Position = position;
            GemCount = 0;
        }

        public void Move(char direction) 
        { 
        
        }
    }
}
