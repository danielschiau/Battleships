using Battleships.Models;

namespace Battleships.Business.MapService
{
    public interface IBattleMapService
    {
        MapCell[,] CreateMap(int rows, int columns);
    }
}
