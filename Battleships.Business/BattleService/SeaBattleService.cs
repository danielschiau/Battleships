using System.Collections.Generic;
using System.Linq;
using Battleships.Business.AllocationService;
using Battleships.Business.MapService;
using Battleships.Models;

namespace Battleships.Business.BattleService
{
    public class SeaBattleService : IBattleService<SeaBattle, SeaBattleSettings>
    {
        private readonly ITargetPlacementService<List<Ship>> _targetPlacementService;
        private readonly IBattleMapService _battleMapService;

        public SeaBattleService(ITargetPlacementService<List<Ship>> targetPlacementService, IBattleMapService battleMapService)
        {
            _targetPlacementService = targetPlacementService;
            _battleMapService = battleMapService;
        }

        public SeaBattle CreateBattle(SeaBattleSettings settings)
        {
            var map = _battleMapService.CreateMap(settings.Rows, settings.Columns);
            var ships = _targetPlacementService.PlaceTargetsOnMap(settings.Ships, map);

            return new SeaBattle { Map = map, Ships = ships };
        }

        public void EvaluateHit(SeaBattle battle, MapCell hit)
        {
            if (battle.Map[hit.Row, hit.Column].State == CellStateType.NotTouched)
                battle.Map[hit.Row, hit.Column].State = CellStateType.Tested;

            foreach (var ship in battle.Ships)
            {
                var shipCellHit = ship.Position.FirstOrDefault(x => IsSamePosition(x, hit));
                if (shipCellHit != null)
                {
                    battle.Map[hit.Row, hit.Column].State = CellStateType.Hit;
                    shipCellHit.State = CellStateType.Hit;
                }

                if (IsSamePosition(ship.Head, hit))
                {
                    ship.IsSunk = true;
                    ship.Position.ForEach(x =>
                    {
                        battle.Map[x.Row, x.Column].State = CellStateType.Hit;
                        x.State = CellStateType.Hit;
                    });
                }
                else if (ship.Position.All(x => x.State == CellStateType.Hit))
                {
                    ship.IsSunk = true;
                }
            }

            battle.IsGameOver = battle.Ships.All(x => x.IsSunk);
        }

        private static bool IsSamePosition(MapCell mapCell, MapCell other)
        {
            return mapCell.Row == other.Row && mapCell.Column == other.Column;
        }
    }
}
