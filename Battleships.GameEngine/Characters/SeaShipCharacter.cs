using System.Collections.Generic;
using System.Linq;
using Battleships.GameEngine.MapAllocation;
using Battleships.GameEngine.Worlds;

namespace Battleships.GameEngine.Characters
{
    public class SeaShipCharacter : ICharacter
    {
        public string Name { get; set; }
        public int Size { get; }
        public List<MapCell> Position { get; set; }
        public MapCell Head => Position?.FirstOrDefault();
        public bool IsDestroyed => Position.All(x => x.State == MapCellState.Hit);

        public SeaShipCharacter(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public void EvaluateHit(MapCell hit)
        {
            if (Position == null)
                return;
            
            EvaluateHeadHit(hit);
            EvaluateTailHit(hit);
        }

        private void EvaluateTailHit(MapCell hit)
        {
            var shipCellHit = Position.FirstOrDefault(cell => cell.Equals(hit));

            if (shipCellHit != null)
                shipCellHit.State = MapCellState.Hit;
        }

        private void EvaluateHeadHit(MapCell hit)
        {
            if (hit.Equals(Head))
                Position.ForEach(cell => cell.State = MapCellState.Hit);
        }

        public void PlaceOnMap(MapCell[,] map)
        {
            Position = new CharacterAllocation(Size, map).Allocate().ToList();
            Position?.ForEach(x => map[x.Row, x.Column].Character = this);
        }
    }
}
