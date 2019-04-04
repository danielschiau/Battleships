using Battleships.GameEngine.Worlds;

namespace Battleships.GameEngine.Games
{
    public interface IGamePlay
    {
        bool IsGameOver { get; set; }
        IWorld World { get; set; }
        void EvaluateHit(WorldCell hit);
    }
}
