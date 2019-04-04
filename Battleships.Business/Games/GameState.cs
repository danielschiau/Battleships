using System.Collections.Generic;
using Battleships.Business.Characters;
using Battleships.Business.Maps;

namespace Battleships.Business.Games
{
    public class GameState
    {
        public MapCell[,] Map { get; set; }
        public List<ICharacter> Characters { get; set; }

        public bool IsGameOver { get; set; }
    }
}
