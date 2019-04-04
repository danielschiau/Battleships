using System;
using System.Collections.ObjectModel;
using Battleships.GameEngine.Worlds;
using Battleships.Presenter.Pages.Base;
using Gu.Wpf.DataGrid2D;

namespace Battleships.Presenter.Pages.Battlefield
{
    public class BattlefieldViewModel : BaseViewModel, IBattlefieldViewModel
    {
        private Action<WorldCell> _onCellSelected;

        private ObservableCollection<string> _columnHeaders;
        public ObservableCollection<string> ColumnHeaders
        {
            get => _columnHeaders;
            set { _columnHeaders = value; OnPropertyChanged(nameof(ColumnHeaders));}
        }

        private ObservableCollection<string> _rowHeaders;
        public ObservableCollection<string> RowHeaders
        {
            get => _rowHeaders;
            set { _rowHeaders = value; OnPropertyChanged(nameof(RowHeaders)); }
        }

        private WorldCell[,] _world;
        public WorldCell[,] World
        {
            get => _world;
            set { _world = value; OnPropertyChanged(nameof(World)); }
        }

        private bool _isDebugMode;
        public bool IsDebugMode
        {
            get => _isDebugMode;
            set { _isDebugMode = value; OnPropertyChanged(nameof(IsDebugMode)); }
        }

        private RowColumnIndex _selectedCellIndex;
        public RowColumnIndex SelectedCellIndex
        {
            get => _selectedCellIndex;
            set { _selectedCellIndex = value; OnPropertyChanged(nameof(SelectedCellIndex)); }
        }

        public BattlefieldViewModel()
        {
            IsDebugMode = true;
            GenerateHeaders();
        }

        public DelegateCommand ToggleDebugModeCommand => new DelegateCommand(() => IsDebugMode = !IsDebugMode);

        public DelegateCommand CellSelectedCommand => new DelegateCommand(() => _onCellSelected(World[SelectedCellIndex.Row, SelectedCellIndex.Column]));

        public void Render(WorldCell[,] world, Action<WorldCell> onCellSelected)
        {
            _onCellSelected = onCellSelected;
            World = world;
        }

        private void GenerateHeaders()
        {
            ColumnHeaders = new ObservableCollection<string>{"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N"};
            RowHeaders = new ObservableCollection<string>{"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14"};
        }
    }
}
