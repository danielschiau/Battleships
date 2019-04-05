using System.Windows;
using Battleships.Presenter.Pages.Base;
using Battleships.Presenter.Pages.Settings;
using MahApps.Metro.Controls.Dialogs;

namespace Battleships.Presenter.Pages.MainWindow
{
    public class MainWindowViewModel : BaseViewModel, IMainWindowViewModel
    {
        private IViewModel _containerViewModel;
        public IViewModel ContainerViewModel
        {
            get => _containerViewModel;
            set { _containerViewModel = value; OnPropertyChanged(nameof(ContainerViewModel)); }
        }

        public MainWindowViewModel(ISettingsViewModel settingsViewModel)
        {
            ContainerViewModel = settingsViewModel;
        }
    }
}
