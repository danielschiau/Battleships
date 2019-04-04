using System.Collections.Generic;
using System.Linq;
using Battleships.Models.Map;

namespace Battleships.Models.Characters
{
    public class SeaShipCharacter : ICharacter
    {
        public string Name { get; set; }
        public int Size { get; }
        public List<MapCell> Position { get; set; }
        public MapCell Head => Position.FirstOrDefault();
        public bool IsDestroyed => Position.All(x => x.State == MapCellStateType.Hit);

        public SeaShipCharacter(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public void EvaluateHit(MapCell hit)
        {
            EvaluateHeadHit(hit);
            EvaluateTailHit(hit);
        }

        private void EvaluateTailHit(MapCell hit)
        {
            var shipCellHit = Position.FirstOrDefault(cell => cell.Equals(hit));

            if (shipCellHit != null)
                shipCellHit.State = MapCellStateType.Hit;
        }

        private void EvaluateHeadHit(MapCell hit)
        {
            if (hit.Equals(Head))
                Position.ForEach(cell => cell.State = MapCellStateType.Hit);
        }
    }
}
