using Battleships.Models;

namespace Battleships.Business.AllocationService
{
    public interface ITargetPlacementService<T>
    {
        T PlaceTargetsOnMap(T targets, MapCell[,] map);
    }
}
