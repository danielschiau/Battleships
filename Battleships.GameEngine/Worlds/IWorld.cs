using Battleships.GameEngine.Characters;

namespace Battleships.GameEngine.Worlds
{
    public interface IWorld
    {
        WorldCell[,] World { get; set; }
        void EvaluateHit(WorldCell hit);
        void PlaceOnMap(ICharacter character);
    }
}
