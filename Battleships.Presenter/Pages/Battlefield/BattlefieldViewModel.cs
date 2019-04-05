using System;
using System.Collections.ObjectModel;
using Battleships.GameEngine.Worlds;
using Battleships.Presenter.Pages.Base;
using Gu.Wpf.DataGrid2D;

namespace Battleships.Presenter.Pages.Battlefield
{
    public class BattlefieldViewModel : BaseViewModel, IBattlefieldViewModel
    {
        private Action<MapCell> _onCellSelected;

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

        private MapCell[,] _map;
        public MapCell[,] Map
        {
            get => _map;
            set { _map = value; OnPropertyChanged(nameof(Map)); }
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

        public DelegateCommand ToggleDebugModeCommand => new DelegateCommand(() => IsDebugMode = !IsDebugMode);

        public DelegateCommand CellSelectedCommand => new DelegateCommand(() => _onCellSelected(Map[SelectedCellIndex.Row, SelectedCellIndex.Column]));

        public BattlefieldViewModel()
        {
            IsDebugMode = true;
            GenerateHeaders(20);
        }

        public void Render(MapCell[,] map, Action<MapCell> onCellSelected)
        {
            _onCellSelected = onCellSelected;
            Map = map;
        }

        private void GenerateHeaders(int headerSize)
        {
            RowHeaders = new ObservableCollection<string>();
            ColumnHeaders = new ObservableCollection<string>();
            
            for (int index = 0; index < headerSize; index++)
            {
                RowHeaders.Add((index+1).ToString());
                ColumnHeaders.Add(((char)(index+65)).ToString());
            }
        }
    }
}
