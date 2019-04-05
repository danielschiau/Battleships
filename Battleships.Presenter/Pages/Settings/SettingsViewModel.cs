using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Battleships.GameEngine.Characters;
using Battleships.GameEngine.Games;
using Battleships.Presenter.Navigation;
using Battleships.Presenter.Pages.Base;
using Battleships.Presenter.Pages.GamePlay;

namespace Battleships.Presenter.Pages.Settings
{
    public class SettingsViewModel : BaseViewModel, ISettingsViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IGamePlayViewModel _gamePlayViewModel;

        private ObservableCollection<KeyValuePair<int, int>> _gridSizeOptions;
        public ObservableCollection<KeyValuePair<int, int>> GridSizeOptions
        {
            get => _gridSizeOptions;
            set { _gridSizeOptions = value; OnPropertyChanged(nameof(GridSizeOptions)); }
        }

        private KeyValuePair<int, int> _selectedGridSize;
        public KeyValuePair<int, int> SelectedGridSize
        {
            get => _selectedGridSize;
            set { _selectedGridSize = value; OnPropertyChanged(nameof(SelectedGridSize)); }
        }

        private ObservableCollection<ICharacter> _ships;
        public ObservableCollection<ICharacter> Ships
        {
            get => _ships;
            set { _ships = value; OnPropertyChanged(nameof(Ships)); }
        }

        public DelegateCommand NavigateToGamePlayCommand => new DelegateCommand(() =>
        {
            _gamePlayViewModel.Start(new GameSettings
            {
                MapSize = SelectedGridSize.Value,
                Characters = Ships.ToList()
            });

            _navigationService.NavigateToViewModel(_gamePlayViewModel);
        });

        public SettingsViewModel(INavigationService navigationService, IGamePlayViewModel gamePlayViewModel)
        {
            _navigationService = navigationService;
            _gamePlayViewModel = gamePlayViewModel;

            GetDefaultSettings();
        }

        private void GetDefaultSettings()
        {
            GridSizeOptions = new ObservableCollection<KeyValuePair<int, int>>
            {
                new KeyValuePair<int, int>(10, 10),
                new KeyValuePair<int, int>(12, 12),
                new KeyValuePair<int, int>(14, 14)
            };

            SelectedGridSize = GridSizeOptions.First();

            Ships = new ObservableCollection<ICharacter>
            {
                new BattleshipCharacter("Colorado Battleship"),
                new DestroyerCharacter("USS Bulkeley Destroyer"),
                new DestroyerCharacter("USS Carney Destroyer")
            };
        }
    }
}
