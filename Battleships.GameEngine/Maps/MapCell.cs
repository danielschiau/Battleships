﻿using Battleships.GameEngine.Characters;

namespace Battleships.GameEngine.Maps
{
    public class MapCell
    {
        public int Column { get; }
        public int Row { get; }
        public MapCellStateType State { get; set; }
        public ICharacter Character { get; set; }

        public MapCell(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public bool Equals(MapCell other)
        {
            return Row == other?.Row && Column == other.Column;
        }
    }
}
