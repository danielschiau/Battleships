using System.Windows;
using Battleships.Presenter.Pages.Base;
using MahApps.Metro.Controls.Dialogs;

namespace Battleships.Presenter.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly IMainWindowProvider _mainWindowProvider;

        public NavigationService(IMainWindowProvider mainWindowProvider)
        {
            _mainWindowProvider = mainWindowProvider;
        }

        public void NavigateToViewModel(IViewModel viewModel)
        {
            _mainWindowProvider.GetMainWindowContext().ContainerViewModel = viewModel;
        }

        public void PopUpMessage(string title, string message)
        {
            Application.Current.Dispatcher.Invoke(() => DialogCoordinator.Instance.ShowMessageAsync(_mainWindowProvider.GetMainWindowContext(), title, message));
        }
    }
}
