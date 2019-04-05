using System;
using System.Collections.Generic;
using Battleships.GameEngine.Characters;

namespace Battleships.GameEngine.Worlds
{
    public class SeaWorld : IWorld
    {
        private const int MaxAllocationRetries = 10000;
        private readonly Random _random;

        public MapCell[,] Map { get; set; }

        public SeaWorld()
        {
            _random = new Random();
        }

        public void EvaluateHit(MapCell hit)
        {
            Map[hit.Row, hit.Column].State = MapCellStateType.Tested;
            Map[hit.Row, hit.Column].Character?.EvaluateHit(hit);
        }

        public void CreateMap(int mapSize)
        {
            Map = new MapCell[mapSize, mapSize];

            for (var row = 0; row < mapSize; row++)
            {
                for (var column = 0; column < mapSize; column++)
                {
                    Map[row, column] = new MapCell(row, column);
                }
            }
        }

        public void PlaceOnMap(ICharacter character)
        {
            character.Position = GetCharacterPosition(character.Size);
            character.Position?.ForEach(x => Map[x.Row, x.Column].Character = character);
        }

        private List<MapCell> GetCharacterPosition(int shipSize)
        {
            var isHorizontal = _random.Next(2) == 0;

            var rowsNr = Map.GetLength(0);
            var columnsNr = Map.GetLength(1);

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
                        ? GetEmptyCell(Map[index, randomColumn])
                        : GetEmptyCell(Map[randomRow, index]);

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
