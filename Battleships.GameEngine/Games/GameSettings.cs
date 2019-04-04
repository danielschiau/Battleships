using System.Collections.Generic;
using Battleships.GameEngine.Characters;

namespace Battleships.GameEngine.Games
{
    public class GameSettings
    {
        public int MapSize { get; set; }
        public List<ICharacter> Characters { get; set; }
    }
}
