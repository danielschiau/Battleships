using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.GameEngine.Worlds;

namespace Battleships.GameEngine.Characters
{
    public class SeaShipCharacter : ICharacter
    {
        private const int MaxAllocationRetries = 10000;
        private readonly Random _random;

        public string Name { get; set; }
        public int Size { get; }
        public List<MapCell> Position { get; set; }
        public MapCell Head => Position?.FirstOrDefault();
        public bool IsDestroyed => Position.All(x => x.State == MapCellStateType.Hit);

        public SeaShipCharacter(string name, int size)
        {
            Name = name;
            Size = size;

            _random = new Random();
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
                shipCellHit.State = MapCellStateType.Hit;
        }

        private void EvaluateHeadHit(MapCell hit)
        {
            if (hit.Equals(Head))
                Position.ForEach(cell => cell.State = MapCellStateType.Hit);
        }

        public void PlaceOnMap(MapCell[,] map)
        {
            Position = GetCharacterPosition(Size, map);
            Position?.ForEach(x => map[x.Row, x.Column].Character = this);
        }

        private List<MapCell> GetCharacterPosition(int shipSize, MapCell[,] map)
        {
            var isHorizontal = _random.Next(2) == 0;

            var rowsNr = map.GetLength(0);
            var columnsNr = map.GetLength(1);

            var rowsBorder = !isHorizontal ? rowsNr : rowsNr - shipSize;
            var columnsBorder = isHorizontal ? columnsNr : columnsNr - shipSize;
            var endBorder = isHorizontal ? rowsBorder : columnsBorder;

            var allocationRetries = 0;
            while (allocationRetries < MaxAllocationRetries)
            {
                var position = new List<MapCell>();
                var randomRow = _random.Next(rowsBorder);
                var randomColumn = _random.Next(columnsBorder);

                for (var index = 0; index <= endBorder; index++)
                {
                    var cell = isHorizontal
                        ? GetEmptyCell(map[index, randomColumn])
                        : GetEmptyCell(map[randomRow, index]);

                    if (cell == null)
                        break;

                    position.Add(cell);

                    if (position.Count == shipSize)
                        return position;
                }

                allocationRetries++;
            }

            return null;
        }

        private MapCell GetEmptyCell(MapCell cell)
        {
            return cell.Character == null ? cell : null;
        }
    }
}
