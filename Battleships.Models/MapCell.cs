﻿namespace Battleships.Models
{
    public class MapCell
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public CellStateType State { get; set; }
        public Ship Ship { get; set; }
    }
}
