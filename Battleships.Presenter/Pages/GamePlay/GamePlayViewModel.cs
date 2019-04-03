using Battleships.Models;
using Battleships.Presenter.Navigation;
using Battleships.Presenter.Pages.Base;
using Battleships.Presenter.Pages.GameOver;

namespace Battleships.Presenter.Pages.GamePlay
{
    public class GamePlayViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly GameOverViewModel _gameOverViewModel;

        private SeaBattle _battleMatch;
        public SeaBattle BattleMatch
        {
            get => _battleMatch;
            set { _battleMatch = value; OnPropertyChanged(nameof(BattleMatch)); }
        }


        public GamePlayViewModel(INavigationService navigationService, GameOverViewModel gameOverViewModel)
        {
            _navigationService = navigationService;
            _gameOverViewModel = gameOverViewModel;

            BattleMatch = new SeaBattle();
        }

        public DelegateCommand NavigateToGamePlayCommand => new DelegateCommand(() =>
        {
            _navigationService.NavigateToViewModel(_gameOverViewModel);
        });
    }
}
