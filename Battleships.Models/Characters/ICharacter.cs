using System.Collections.Generic;
using Battleships.Models.Map;

namespace Battleships.Models.Characters
{
    public interface ICharacter
    {
        string Name { get; set; }
        int Size { get; }
        MapCell Head { get; }
        List<MapCell> Position { get; set; }
        bool IsDestroyed { get; }
        void EvaluateHit(MapCell hit);
    }
}
