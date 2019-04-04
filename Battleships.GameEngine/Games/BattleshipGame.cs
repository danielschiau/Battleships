using System.Collections.Generic;
using System.Linq;
using Battleships.GameEngine.Characters;
using Battleships.GameEngine.Worlds;

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

        public void EvaluateHit(WorldCell hit)
        {
            World.EvaluateHit(hit);
            Characters.ForEach(x => x.EvaluateHit(hit));
            EvaluateGameOver();
        }

        private void EvaluateGameOver()
        {
            IsGameOver = Characters.All(x => x.IsDestroyed);
        }
    }
}
