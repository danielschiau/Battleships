using System.Collections.Generic;

namespace Battleships.Models
{
    public class Ship
    {
        public string Name { get; set; }
        public MapCell Head { get; set; }
        public List<MapCell> Position { get; set; }
        public bool IsSunk { get; set; }
    }
}
