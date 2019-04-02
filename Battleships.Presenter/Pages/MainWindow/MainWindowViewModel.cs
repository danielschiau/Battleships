using Battleships.Presenter.Pages.Base;
using Battleships.Presenter.Pages.Settings;

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
    }
}
