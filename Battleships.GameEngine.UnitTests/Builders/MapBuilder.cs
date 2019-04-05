using Battleships.GameEngine.Worlds;

namespace Battleships.GameEngine.UnitTests.Builders
{
    public class MapBuilder
    {
        private MapCell[,] _map;

        public MapBuilder(int size)
        {
            Create(size);
        }

        private void Create(int size)
        {
            _map = new MapCell[size, size];

            for (var row = 0; row < size; row++)
            {
                for (var column = 0; column < size; column++)
                {
                    _map[row, column] = new MapCell(row, column);
                }
            }
        }

        public MapCell[,] Build()
        {
            return _map;
        }
    }
}
