using Battleships.Business.Maps;

namespace Battleships.Business.Games
{
    public interface IGamePlay
    {
        GameState State { get; set; }
        void Start(GameSettings settings);
        void EvaluateHit(MapCell hit);
    }
}
