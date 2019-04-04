using System.Collections.Generic;
using Battleships.GameEngine.Characters;
using Battleships.GameEngine.Maps;

namespace Battleships.GameEngine.Games
{
    public class GameState
    {
        public MapCell[,] Map { get; set; }
        public List<ICharacter> Characters { get; set; }

        public bool IsGameOver { get; set; }
    }
}
