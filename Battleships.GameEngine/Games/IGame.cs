using Battleships.GameEngine.Worlds;

namespace Battleships.GameEngine.Games
{
    public interface IGame
    {
        bool IsOver { get; }
        IWorld World { get; }
        void EvaluateHit(MapCell hit);
    }
}
