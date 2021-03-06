﻿using System.Collections.Generic;
using System.Linq;
using Battleships.GameEngine.Characters;
using Battleships.GameEngine.Worlds;

namespace Battleships.GameEngine.Games
{
    public class BattleshipGame : IGame
    {
        public bool IsOver { get; private set; }
        public IWorld World { get; }
        public List<ICharacter> Characters { get; private set; }

        public BattleshipGame(IWorld world)
        {
            World = world;
        }

        public void Start(GameSettings settings)
        {
            World.CreateMap(settings.MapSize);

            Characters = settings.Characters;
            Characters?.ForEach(x => x.PlaceOnMap(World.Map));
        }

        public void EvaluateHit(MapCell hit)
        {
            World.EvaluateHit(hit);
            Characters?.ForEach(x => x.EvaluateHit(hit));
            EvaluateGameOver();
        }

        private void EvaluateGameOver()
        {
            IsOver = Characters.All(x => x.IsDestroyed);
        }
    }
}
