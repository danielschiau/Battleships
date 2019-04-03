using Battleships.Business.BattleService;
using Battleships.Models;
using Battleships.Presenter.Pages.Base;
using Battleships.Presenter.Pages.Battlefield;

namespace Battleships.Presenter.Pages.GamePlay
{
    public class GamePlayViewModel : BaseViewModel
    {
        private readonly IBattleService<SeaBattle, SeaBattleSettings> _battleService;

        private SeaBattle _battleMatch;
        public SeaBattle BattleMatch
        {
            get => _battleMatch;
            set { _battleMatch = value; OnPropertyChanged(nameof(BattleMatch)); }
        }

        private BattlefieldViewModel _battleField;
        public BattlefieldViewModel BattleField
        {
            get => _battleField;
            set { _battleField = value; OnPropertyChanged(nameof(BattleField)); }
        }

        public GamePlayViewModel(IBattleService<SeaBattle, SeaBattleSettings> battleService,
            BattlefieldViewModel battlefieldViewModel)
        {
            _battleService = battleService;
            BattleField = battlefieldViewModel;
        }

        public void StartBattle(SeaBattleSettings settings)
        {
            BattleMatch = _battleService.CreateBattle(settings);
            BattleField.Render(BattleMatch.Map, OnCellSelected);
        }

        public void OnCellSelected(MapCell cell)
        {
            cell.State = CellStateType.Tested;
            _battleService.EvaluateHit(cell);
            BattleField.Render(BattleMatch.Map, OnCellSelected);
        }
    }
}
