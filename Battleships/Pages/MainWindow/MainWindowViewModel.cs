using Battleships.Pages.Base;
using Battleships.Pages.Battlefield;
using Battleships.Pages.Settings;

namespace Battleships.Pages.MainWindow
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
