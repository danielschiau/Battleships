using Battleships.GameEngine.Characters;

namespace Battleships.GameEngine.Worlds
{
    public interface IWorld
    {
        MapCell[,] Map { get; set; }
        void EvaluateHit(MapCell hit);
        void PlaceOnMap(ICharacter character);
    }
}
