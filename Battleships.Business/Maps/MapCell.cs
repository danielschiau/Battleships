using Battleships.Business.Characters;

namespace Battleships.Business.Maps
{
    public class MapCell
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public MapCellStateType State { get; set; }
        public ICharacter Character { get; set; }

        public bool Equals(MapCell other)
        {
            return Row == other?.Row && Column == other.Column;
        }
    }
}
