using System.Collections.Generic;
using System.Linq;
using Battleships.GameEngine.Characters;
using Battleships.GameEngine.Worlds;

namespace Battleships.GameEngine.Games
{
    public class BattleshipGame : IGamePlay
    {
        public bool IsGameOver { get; private set; }
        public IWorld World { get; private set; }
        public List<ICharacter> Characters { get; private set; }

        public BattleshipGame(GameSettings settings)
        {
            World = new SeaWorld(settings.MapSize);

            Characters = settings.Characters;
            Characters?.ForEach(x => World.PlaceOnMap(x));
        }

        public void EvaluateHit(MapCell hit)
        {
            World.EvaluateHit(hit);
            EvaluateGameOver();
        }

        private void EvaluateGameOver()
        {
            IsGameOver = Characters.All(x => x.IsDestroyed);
        }
    }
}
