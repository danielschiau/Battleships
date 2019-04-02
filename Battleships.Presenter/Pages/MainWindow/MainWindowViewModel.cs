using System.Windows;
using Battleships.Presenter.Pages.Base;
using Battleships.Presenter.Pages.Settings;
using MahApps.Metro.Controls.Dialogs;

namespace Battleships.Presenter.Pages.MainWindow
{
    public class MainWindowViewModel : BaseViewModel
    {
        private BaseViewModel _containerViewModel;
        public BaseViewModel ContainerViewModel
        {
            get => _containerViewModel;
            set { _containerViewModel = value; OnPropertyChanged(nameof(ContainerViewModel)); }
        }

        public MainWindowViewModel()
        {
            ContainerViewModel = new SettingsViewModel();
        }

        public void PopUpMessage(string title, string message)
        {
            Application.Current.Dispatcher.Invoke(() => DialogCoordinator.Instance.ShowMessageAsync(this, title, message));
        }

        public void NavigateToPage(BaseViewModel viewModel)
        {
            ContainerViewModel = viewModel;
        }
    }
}
