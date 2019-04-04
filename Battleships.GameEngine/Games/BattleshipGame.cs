using System.Collections.Generic;
using System.Linq;
using Battleships.GameEngine.Characters;
using Battleships.GameEngine.Maps;

namespace Battleships.GameEngine.Games
{
    public class BattleshipGame : IGamePlay
    {
        public bool IsGameOver { get; set; }
        public IWorld World { get; set; }
        public List<ICharacter> Characters { get; set; }

        public BattleshipGame(GameSettings settings)
        {
            World = new SeaWorld(settings.MapSize);

            Characters = settings.Characters;
            Characters.ForEach(x => World.PlaceOnMap(x));
        }

        public void EvaluateHit(MapCell hit)
        {
            World.Map[hit.Row, hit.Column].State = MapCellStateType.Tested;
            Characters.ForEach(_ => _.EvaluateHit(hit));
            IsGameOver = Characters.All(x => x.IsDestroyed);
        }
    }
}
