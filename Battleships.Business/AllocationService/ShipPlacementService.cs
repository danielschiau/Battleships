using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Models;

namespace Battleships.Business.AllocationService
{
    public class ShipPlacementService : ITargetPlacementService<List<Ship>>
    {
        private readonly Random _random;

        public ShipPlacementService()
        {
            _random = new Random();
        }

        public List<Ship> PlaceTargetsOnMap(List<Ship> ships, MapCell[,] map)
        {
            foreach (var ship in ships)
            {
                var isHorizontal = _random.Next(2) == 0;
                ship.Position = PositionShip(isHorizontal, ship.Size, map);
                ship.Head = ship.Position.First();

                foreach (var cell in ship.Position)
                {
                    map[cell.Row, cell.Column].Ship = ship;
                }
            }

            return ships;
        }

        private List<MapCell> PositionShip(bool isHorizontal, int shipSize, MapCell[,] map)
        {
            var tries = 0;
            var maxTries = 10000;
            var placeFound = false;

            var rows = map.GetLength(0);
            var columns = map.GetLength(1);

            var rowsBorder = !isHorizontal ? rows : rows - shipSize;
            var columnsBorder = isHorizontal ? columns : columns - shipSize;

            while (tries < maxTries)
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

                maxTries++;
            }

            return null;
        }
    }
}
