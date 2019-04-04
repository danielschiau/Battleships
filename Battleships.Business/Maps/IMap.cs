using Battleships.Business.Characters;

namespace Battleships.Business.Maps
{
    public interface IMap
    {
        MapCell[,] Create(int size);
        void PlaceOnMap(ICharacter character, MapCell[,] map);
    }
}
