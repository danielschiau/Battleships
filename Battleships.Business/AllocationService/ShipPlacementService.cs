using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Models;

namespace Battleships.Business.AllocationService
{
    public class ShipPlacementService : ITargetPlacementService<List<Ship>>
    {
        private const int MaxAllocationRetries = 10000;
        private readonly Random _random;

        public ShipPlacementService()
        {
            _random = new Random();
        }

        public List<Ship> PlaceTargetsOnMap(List<Ship> shipsSettings, MapCell[,] map)
        {
            var result = new List<Ship>();

            shipsSettings.ForEach(shipSettings =>
            {
                var position = GetShipPosition(shipSettings.Size, map);
                result.Add(CreateShip(shipSettings, position, map));
            });

            return result;
        }

        private static Ship CreateShip(Ship shipSettings, List<MapCell> position, MapCell[,] map)
        {
            var ship = new Ship
            {
                Position = position,
                Head = position.First(),
                IsSunk = false,
                Size = shipSettings.Size,
                Name = shipSettings.Name
            };

            ship.Position.ForEach(cell => map[cell.Row, cell.Column].Ship = ship);

            return ship;
        }

        private List<MapCell> GetShipPosition(int shipSize, MapCell[,] map)
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
                var result = new List<MapCell>();
                var allocatedCells = 0;
                var randomRow = _random.Next(rowsBorder);
                var randomColumn = _random.Next(columnsBorder);
                var shipDoesNotFit = false;

                for (int index = 0; index < endBorder && shipDoesNotFit == false; index++)
                {
                    if (isHorizontal && map[index, randomColumn].Ship == null)
                    {
                        result.Add(map[index, randomColumn]);
                        allocatedCells++;
                    }
                    else if (!isHorizontal && map[randomRow, index].Ship == null)
                    {
                        result.Add(map[randomRow, index]);
                        allocatedCells++;
                    }
                    else
                    {
                        shipDoesNotFit = true;
                    }

                    if (allocatedCells == shipSize)
                    {
                        return result;
                    }
                }

                allocationRetries++;
            }

            return null;
        }
    }
}
