using System.Linq;
using Battleships.Business.Maps;

namespace Battleships.Business.Games
{
    public class BattleshipGame : IGamePlay
    {
        private readonly IMap _map;

        public GameState State { get; set; }

        public BattleshipGame(IMap map)
        {
            _map = map;
        }

        public void Start(GameSettings settings)
        {
            var map = _map.Create(settings.MapSize);
            settings.Characters.ForEach(x => _map.PlaceOnMap(x, map));

            State = new GameState { Map = map, Characters = settings.Characters };
        }

        public void EvaluateHit(MapCell hit)
        {
            State.Map[hit.Row, hit.Column].State = MapCellStateType.Tested;
            State.Characters.ForEach(_ => _.EvaluateHit(hit));
            State.IsGameOver = State.Characters.All(x => x.IsDestroyed);
        }
    }
}
