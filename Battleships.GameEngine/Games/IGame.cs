using Battleships.GameEngine.Worlds;

namespace Battleships.GameEngine.Games
{
    public interface IGame
    {
        bool IsOver { get; }
        IWorld World { get; }
        void Start(GameSettings settings);
        void EvaluateHit(MapCell hit);
    }
}
