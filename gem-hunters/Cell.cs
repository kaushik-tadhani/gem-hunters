using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gem_hunters
{
    public class Cell
    {
        public string Occupant { get; set; }

        public Cell(string occupant) 
        { 
            Occupant = occupant;
        }
    }
}
