using System.Collections.Generic;

namespace Battleships.Models
{
    public class SeaBattle
    {
        public int Rows => Map.GetLength(0);
        public int Columns => Map.GetLength(1);

        public MapCell[,] Map { get; set; }
        public List<Ship> Ships { get; set; }
    }
}
