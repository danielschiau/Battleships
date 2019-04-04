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
            battle.Map[hit.Row, hit.Column].State = MapCellStateType.Tested;

            battle.Ships.ForEach(ship =>
            {
                EvaluateTailHit(hit, ship);
                EvaluateHeadHit(hit, ship);
                EvaluateSunk(ship);
            });

            EvaluateGameOver(battle);
        }

        private static void EvaluateGameOver(SeaBattle battle)
        {
            battle.IsGameOver = battle.Ships.All(x => x.IsSunk);
        }

        private static void EvaluateSunk(Ship ship)
        {
            ship.IsSunk = ship.Position.All(x => x.State == MapCellStateType.Hit);
        }

        private static void EvaluateHeadHit(MapCell hit, Ship ship)
        {
            if (hit.Equals(ship.Head))
            {
                ship.Position.ForEach(cell => cell.State = MapCellStateType.Hit);
            }
        }

        private static void EvaluateTailHit(MapCell hit, Ship ship)
        {
            var shipCellHit = ship.Position.FirstOrDefault(cell => cell.Equals(hit));

            if (shipCellHit != null)
            {
                shipCellHit.State = MapCellStateType.Hit;
            }
        }
    }
}
