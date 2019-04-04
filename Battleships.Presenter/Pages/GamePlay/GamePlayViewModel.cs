using Battleships.GameEngine.Games;
using Battleships.GameEngine.Maps;
using Battleships.Presenter.Navigation;
using Battleships.Presenter.Pages.Base;
using Battleships.Presenter.Pages.Battlefield;

namespace Battleships.Presenter.Pages.GamePlay
{
    public class GamePlayViewModel : BaseViewModel
    {
        private GameSettings _settings;
        private readonly IGamePlay _gamePlay;
        private readonly INavigationService _navigationService;

        private GameState _gameStateMatch;
        public GameState GameStateMatch
        {
            get => _gameStateMatch;
            set { _gameStateMatch = value; OnPropertyChanged(nameof(GameStateMatch)); }
        }

        private BattlefieldViewModel _battleField;
        public BattlefieldViewModel BattleField
        {
            get => _battleField;
            set { _battleField = value; OnPropertyChanged(nameof(BattleField)); }
        }

        public GamePlayViewModel(IGamePlay gamePlay, INavigationService navigationService, BattlefieldViewModel battlefieldViewModel)
        {
            _gamePlay = gamePlay;
            _navigationService = navigationService;
            BattleField = battlefieldViewModel;
        }

        public DelegateCommand StartBattleCommand => new DelegateCommand(() => StartBattle(_settings));

        public void StartBattle(GameSettings settings)
        {
            _settings = settings;
            _gamePlay.Start(_settings);
            GameStateMatch = _gamePlay.State;
            BattleField.Render(GameStateMatch.Map, OnCellSelected);
        }

        public void OnCellSelected(MapCell cell)
        {
            _gamePlay.EvaluateHit(cell);
            if (GameStateMatch.IsGameOver)
                _navigationService.PopUpMessage("You won!", "Press \"Start new game\" for another round.");
        }
    }
}
