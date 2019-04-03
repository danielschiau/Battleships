namespace Battleships.Business.AllocationService
{
    public interface ITargetPlacementService<T>
    {
        T PlaceTargetsOnMap(T battle);
    }
}
