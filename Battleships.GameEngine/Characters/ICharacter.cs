using System.Collections.Generic;
using Battleships.GameEngine.Worlds;

namespace Battleships.GameEngine.Characters
{
    public interface ICharacter
    {
        string Name { get; set; }
        int Size { get; }
        WorldCell Head { get; }
        List<WorldCell> Position { get; set; }
        bool IsDestroyed { get; }
        void EvaluateHit(WorldCell hit);
    }
}
