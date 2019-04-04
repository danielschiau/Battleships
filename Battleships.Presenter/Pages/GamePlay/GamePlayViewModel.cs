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
        private readonly INavigationService _navigationService;

        private IGamePlay _game;
        public IGamePlay Game
        {
            get => _game;
            set { _game = value; OnPropertyChanged(nameof(Game)); }
        }

        private BattlefieldViewModel _battleField;
        public BattlefieldViewModel BattleField
        {
            get => _battleField;
            set { _battleField = value; OnPropertyChanged(nameof(BattleField)); }
        }

        public GamePlayViewModel(INavigationService navigationService, BattlefieldViewModel battlefieldViewModel)
        {
            _navigationService = navigationService;
            BattleField = battlefieldViewModel;
        }

        public DelegateCommand StartBattleCommand => new DelegateCommand(() => StartBattle(_settings));

        public void StartBattle(GameSettings settings)
        {
            _settings = settings;
            Game = new BattleshipGame(_settings);
            BattleField.Render(Game.World.Map, OnCellSelected);
        }

        public void OnCellSelected(MapCell cell)
        {
            _game.EvaluateHit(cell);
            if (Game.IsGameOver)
                _navigationService.PopUpMessage("You won!", "Press \"Start new game\" for another round.");
        }
    }
}
