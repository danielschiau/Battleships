using Battleships.GameEngine.Maps;

namespace Battleships.GameEngine.Games
{
    public interface IGamePlay
    {
        GameState State { get; set; }
        void Start(GameSettings settings);
        void EvaluateHit(MapCell hit);
    }
}
