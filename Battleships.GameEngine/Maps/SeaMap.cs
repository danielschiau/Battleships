using System;
using System.Collections.Generic;
using Battleships.GameEngine.Characters;

namespace Battleships.GameEngine.Maps
{
    public class SeaMap : IMap
    {
        private const int MaxAllocationRetries = 10000;
        private readonly Random _random;

        public SeaMap()
        {
            _random = new Random();
        }

        public MapCell[,] Create(int mapSize)
        {
            var map = new MapCell[mapSize, mapSize];

            for (var row = 0; row < mapSize; row++)
            {
                for (var column = 0; column < mapSize; column++)
                {
                    map[row, column] = new MapCell { Row = row, Column = column };
                }
            }

            return map;
        }

        public void PlaceOnMap(ICharacter character, MapCell[,] map)
        {
            character.Position = GetCharacterPosition(character.Size, map);
            character.Position.ForEach(x => map[x.Row, x.Column].Character = character);
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

                for (var index = 0; index < endBorder; index++)
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
