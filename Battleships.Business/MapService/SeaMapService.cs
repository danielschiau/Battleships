using Battleships.Models;

namespace Battleships.Business.MapService
{
    public class SeaMapService : IBattleMapService
    {
        public MapCell[,] CreateMap(int rows, int columns)
        {
            var map = new MapCell[rows, columns];

            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    map[row, column] = new MapCell { Row = row, Column = column };
                }
            }

            return map;
        }
    }
}
