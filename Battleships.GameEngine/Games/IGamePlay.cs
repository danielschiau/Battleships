using Battleships.GameEngine.Worlds;

namespace Battleships.GameEngine.Games
{
    public interface IGamePlay
    {
        bool IsGameOver { get; }
        IWorld World { get; }
        void EvaluateHit(MapCell hit);
    }
}
