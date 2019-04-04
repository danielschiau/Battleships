using System.Collections.Generic;
using Battleships.Business.Characters;

namespace Battleships.Business.Games
{
    public class GameSettings
    {
        public int MapSize { get; set; }
        public List<ICharacter> Characters { get; set; }
    }
}
