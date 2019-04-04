using System.Collections.Generic;
using Battleships.Models.Characters;

namespace Battleships.Models.Game
{
    public class GameSettings
    {
        public int MapSize { get; set; }
        public List<ICharacter> Characters { get; set; }
    }
}
