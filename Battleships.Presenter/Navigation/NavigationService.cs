using System.Windows;
using Battleships.Presenter.Pages.Base;
using Battleships.Presenter.Pages.MainWindow;
using MahApps.Metro.Controls.Dialogs;

namespace Battleships.Presenter.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        public NavigationService(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public void NavigateToViewModel(BaseViewModel viewModel)
        {
            _mainWindowViewModel.ContainerViewModel = viewModel;
        }

        public void PopUpMessage(string title, string message)
        {
            Application.Current.Dispatcher.Invoke(() => DialogCoordinator.Instance.ShowMessageAsync(_mainWindowViewModel, title, message));
        }
    }
}
