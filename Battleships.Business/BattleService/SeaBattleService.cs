using Battleships.Business.AllocationService;
using Battleships.Models;

namespace Battleships.Business.BattleService
{
    public class SeaBattleService : IBattleService<SeaBattle, SeaBattleSettings>
    {
        private readonly ITargetPlacementService<SeaBattle> _targetPlacementService;

        public SeaBattleService(ITargetPlacementService<SeaBattle> targetPlacementService)
        {
            _targetPlacementService = targetPlacementService;
        }

        public SeaBattle CreateBattle(SeaBattleSettings settings)
        {
            return new SeaBattle
            {
                Map = CreateMap(settings)
            };
        }

        private static MapCell[,] CreateMap(SeaBattleSettings settings)
        {
            var map = new MapCell[settings.Rows, settings.Columns];

            for (var row = 0; row < settings.Rows; row++)
            {
                for (var column = 0; column < settings.Columns; column++)
                {
                    map[row, column] = new MapCell { Row = row, Column = column };
                }
            }

            return map;
        }
    }
}
