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

            foreach (var shipSettings in shipsSettings)
            {
                var ship = Clone(shipSettings);
                var isHorizontal = _random.Next(2) == 0;
                ship.Position = PositionShip(isHorizontal, ship.Size, map);
                ship.Head = ship.Position.First();
                ship.Position.ForEach(cell => map[cell.Row, cell.Column].Ship = ship);
                result.Add(ship);
            }

            return result;
        }

        private List<MapCell> PositionShip(bool isHorizontal, int shipSize, MapCell[,] map)
        {
            var allocationRetries = 0;

            var rowsNr = map.GetLength(0);
            var columnsNr = map.GetLength(1);

            var rowsBorder = !isHorizontal ? rowsNr : rowsNr - shipSize;
            var columnsBorder = isHorizontal ? columnsNr : columnsNr - shipSize;

            while (allocationRetries < MaxAllocationRetries)
            {
                var allocatedCells = 0;
                var result = new List<MapCell>();

                var row = _random.Next(rowsBorder);
                var column = _random.Next(columnsBorder);

                var forBorder = isHorizontal ? rowsBorder : columnsBorder;

                var shipDoesNotFit = false;

                for (int index = 0; index < forBorder && shipDoesNotFit == false; index++)
                {
                    if (isHorizontal && map[index, column].Ship == null)
                    {
                        result.Add(map[index, column]);
                        allocatedCells++;
                    }
                    else if (!isHorizontal && map[row, index].Ship == null)
                    {
                        result.Add(map[row, index]);
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

        private static Ship Clone(Ship ship)
        {
            return new Ship
            {
                Position = ship.Position,
                Head = ship.Head,
                IsSunk = ship.IsSunk,
                Name = ship.Name,
                Size = ship.Size
            };
        }
    }
}
