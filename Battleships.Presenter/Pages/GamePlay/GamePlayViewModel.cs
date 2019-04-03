using Battleships.Presenter.Navigation;
using Battleships.Presenter.Pages.Base;
using Battleships.Presenter.Pages.GameOver;

namespace Battleships.Presenter.Pages.GamePlay
{
    public class GamePlayViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly GameOverViewModel _gameOverViewModel;

        public GamePlayViewModel(INavigationService navigationService, GameOverViewModel gameOverViewModel)
        {
            _navigationService = navigationService;
            _gameOverViewModel = gameOverViewModel;
        }

        public DelegateCommand NavigateToGamePlayCommand => new DelegateCommand(() =>
        {
            _navigationService.NavigateToViewModel(_gameOverViewModel);
        });
    }
}
