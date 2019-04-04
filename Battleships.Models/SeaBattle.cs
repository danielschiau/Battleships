using System.Collections.Generic;

namespace Battleships.Models
{
    public class SeaBattle
    {
        public MapCell[,] Map { get; set; }
        public List<Ship> Ships { get; set; }

        public bool IsGameOver { get; set; }
    }
}
