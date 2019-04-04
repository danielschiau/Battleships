using System;
using System.Collections.Generic;
using Battleships.GameEngine.Characters;

namespace Battleships.GameEngine.Worlds
{
    public class SeaWorld : IWorld
    {
        private const int MaxAllocationRetries = 10000;
        private readonly Random _random;

        public WorldCell[,] World { get; set; }

        public SeaWorld(int size)
        {
            _random = new Random();
            World = CreateMap(size);
        }

        public void EvaluateHit(WorldCell hit)
        {
            if (World[hit.Row, hit.Column].State == WorldCellStateType.NotTouched)
                World[hit.Row, hit.Column].State = WorldCellStateType.Tested;
        }

        private WorldCell[,] CreateMap(int mapSize)
        {
            var map = new WorldCell[mapSize, mapSize];

            for (var row = 0; row < mapSize; row++)
            {
                for (var column = 0; column < mapSize; column++)
                {
                    map[row, column] = new WorldCell(row, column);
                }
            }

            return map;
        }

        public void PlaceOnMap(ICharacter character)
        {
            character.Position = GetCharacterPosition(character.Size);
            character.Position?.ForEach(x => World[x.Row, x.Column].Character = character);
        }

        private List<WorldCell> GetCharacterPosition(int shipSize)
        {
            var isHorizontal = _random.Next(2) == 0;

            var rowsNr = World.GetLength(0);
            var columnsNr = World.GetLength(1);

            var rowsBorder = !isHorizontal ? rowsNr : rowsNr - shipSize;
            var columnsBorder = isHorizontal ? columnsNr : columnsNr - shipSize;
            var endBorder = isHorizontal ? rowsBorder : columnsBorder;

            var allocationRetries = 0;
            while (allocationRetries < MaxAllocationRetries)
            {
                var position = new List<WorldCell>();
                var randomRow = _random.Next(rowsBorder);
                var randomColumn = _random.Next(columnsBorder);

                for (var index = 0; index < endBorder; index++)
                {
                    var cell = isHorizontal
                        ? GetEmptyCell(World[index, randomColumn])
                        : GetEmptyCell(World[randomRow, index]);

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

        private WorldCell GetEmptyCell(WorldCell cell)
        {
            return cell.Character == null ? cell : null;
        }
    }
}
