using Battleships.GameEngine.Games;
using Battleships.GameEngine.Worlds;
using Battleships.Presenter.Navigation;
using Battleships.Presenter.Pages.Base;
using Battleships.Presenter.Pages.Battlefield;

namespace Battleships.Presenter.Pages.GamePlay
{
    public class GamePlayViewModel : BaseViewModel, IGamePlayViewModel
    {
        private GameSettings _settings;
        private readonly INavigationService _navigationService;

        private IGame _game;
        public IGame Game
        {
            get => _game;
            set { _game = value; OnPropertyChanged(nameof(Game)); }
        }

        private IBattlefieldViewModel _battleField;
        public IBattlefieldViewModel BattleField
        {
            get => _battleField;
            set { _battleField = value; OnPropertyChanged(nameof(BattleField)); }
        }

        public DelegateCommand StartCommand => new DelegateCommand(() => Start(_settings));

        public GamePlayViewModel(INavigationService navigationService, IGame game, IBattlefieldViewModel battlefieldViewModel)
        {
            _navigationService = navigationService;
            Game = game;
            BattleField = battlefieldViewModel;
        }

        public void Start(GameSettings settings)
        {
            _settings = settings;
            Game.Start(_settings);
            BattleField.Render(Game.World.Map, OnCellSelected);
        }

        public void OnCellSelected(MapCell cell)
        {
            _game.EvaluateHit(cell);
            if (Game.IsOver)
                _navigationService.PopUpMessage("You won!", "Press \"Start new game\" for another round.");
        }
    }
}
