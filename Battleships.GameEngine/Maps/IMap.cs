using Battleships.GameEngine.Characters;

namespace Battleships.GameEngine.Maps
{
    public interface IMap
    {
        MapCell[,] Create(int size);
        void PlaceOnMap(ICharacter character, MapCell[,] map);
    }
}
