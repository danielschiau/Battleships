using Battleships.GameEngine.Characters;

namespace Battleships.GameEngine.Maps
{
    public interface IWorld
    {
        MapCell[,] Map { get; set; }
        void PlaceOnMap(ICharacter character);
    }
}
