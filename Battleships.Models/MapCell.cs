﻿namespace Battleships.Models
{
    public class MapCell
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public bool IsHit { get; set; }
    }
}