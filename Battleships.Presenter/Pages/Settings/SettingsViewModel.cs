using Battleships.Presenter.Navigation;
using Battleships.Presenter.Pages.Base;
using Battleships.Presenter.Pages.GamePlay;

namespace Battleships.Presenter.Pages.Settings
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly GamePlayViewModel _gamePlayViewModel;

        public SettingsViewModel(INavigationService navigationService, GamePlayViewModel gamePlayViewModel)
        {
            _navigationService = navigationService;
            _gamePlayViewModel = gamePlayViewModel;
        }

        public DelegateCommand NavigateToGamePlayCommand => new DelegateCommand(() =>
        {
            _navigationService.NavigateToViewModel(_gamePlayViewModel);
        });
    }
}
