using System.Collections.Generic;
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

        public void EvaluateHit(MapCell hit)
        {
            
        }

        
    }
}
