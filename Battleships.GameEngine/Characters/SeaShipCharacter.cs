using System.Collections.Generic;
using System.Linq;
using Battleships.GameEngine.Worlds;

namespace Battleships.GameEngine.Characters
{
    public class SeaShipCharacter : ICharacter
    {
        public string Name { get; set; }
        public int Size { get; }
        public List<WorldCell> Position { get; set; }
        public WorldCell Head => Position?.FirstOrDefault();
        public bool IsDestroyed => Position.All(x => x.State == WorldCellStateType.Hit);

        public SeaShipCharacter(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public void EvaluateHit(WorldCell hit)
        {
            if (Position == null)
                return;
            
            EvaluateHeadHit(hit);
            EvaluateTailHit(hit);
        }

        private void EvaluateTailHit(WorldCell hit)
        {
            var shipCellHit = Position.FirstOrDefault(cell => cell.Equals(hit));

            if (shipCellHit != null)
                shipCellHit.State = WorldCellStateType.Hit;
        }

        private void EvaluateHeadHit(WorldCell hit)
        {
            if (hit.Equals(Head))
                Position.ForEach(cell => cell.State = WorldCellStateType.Hit);
        }
    }
}
