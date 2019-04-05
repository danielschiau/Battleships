namespace Battleships.GameEngine.Worlds
{
    public class SeaWorld : IWorld
    {
        public MapCell[,] Map { get; set; }

        public void EvaluateHit(MapCell hit)
        {
            Map[hit.Row, hit.Column].State = MapCellState.Touched;
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
    }
}
