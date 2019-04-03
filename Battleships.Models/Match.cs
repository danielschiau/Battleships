using System.Collections.Generic;

namespace Battleships.Models
{
    public class Match
    {
        public MapCell[,] Map { get; set; }
        public List<Ship> Ships { get; set; }
    }
}
