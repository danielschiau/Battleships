using Battleships.Business.BattleService;
using Battleships.Models;
using Battleships.Presenter.Navigation;
using Battleships.Presenter.Pages.Base;
using Battleships.Presenter.Pages.Battlefield;

namespace Battleships.Presenter.Pages.GamePlay
{
    public class GamePlayViewModel : BaseViewModel
    {
        private SeaBattleSettings _settings;
        private readonly IBattleService<SeaBattle, SeaBattleSettings> _battleService;
        private readonly INavigationService _navigationService;

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
            INavigationService navigationService,
            BattlefieldViewModel battlefieldViewModel)
        {
            _battleService = battleService;
            _navigationService = navigationService;
            BattleField = battlefieldViewModel;
        }

        public DelegateCommand StartBattleCommand => new DelegateCommand(() => StartBattle(_settings));

        public void StartBattle(SeaBattleSettings settings)
        {
            _settings = settings;
            BattleMatch = _battleService.CreateBattle(_settings);
            BattleField.Render(BattleMatch.Map, OnCellSelected);
        }

        public void OnCellSelected(MapCell cell)
        {
            _battleService.EvaluateHit(BattleMatch, cell);

            if (BattleMatch.IsGameOver)
            {
                _navigationService.PopUpMessage("You won!", "Game over.\nFor a new round, press \"Start battle\"");
            }
        }
    }
}
