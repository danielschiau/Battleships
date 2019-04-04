using Battleships.GameEngine.Characters;

namespace Battleships.GameEngine.Worlds
{
    public class WorldCell
    {
        public int Column { get; }
        public int Row { get; }
        public WorldCellStateType State { get; set; }
        public ICharacter Character { get; set; }

        public WorldCell(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public bool Equals(WorldCell other)
        {
            return Row == other?.Row && Column == other.Column;
        }
    }
}
