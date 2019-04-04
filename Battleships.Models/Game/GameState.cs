using System.Collections.Generic;
using Battleships.Models.Characters;
using Battleships.Models.Map;

namespace Battleships.Models.Game
{
    public class GameState
    {
        public MapCell[,] Map { get; set; }
        public List<ICharacter> Characters { get; set; }

        public bool IsGameOver { get; set; }
    }
}
