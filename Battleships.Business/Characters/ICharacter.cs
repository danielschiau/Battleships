using System.Collections.Generic;
using Battleships.Business.Maps;

namespace Battleships.Business.Characters
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
