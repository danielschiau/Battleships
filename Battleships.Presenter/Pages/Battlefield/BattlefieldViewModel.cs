using System;
using System.Collections.ObjectModel;
using Battleships.Models;
using Battleships.Presenter.Pages.Base;
using Gu.Wpf.DataGrid2D;

namespace Battleships.Presenter.Pages.Battlefield
{
    public class BattlefieldViewModel : BaseViewModel
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
            set { _map = value; OnPropertyChanged(nameof(Map));}
        }

        private RowColumnIndex _selectedCellIndex;
        public RowColumnIndex SelectedCellIndex
        {
            get => _selectedCellIndex;
            set { _selectedCellIndex = value; OnPropertyChanged(nameof(SelectedCellIndex)); }
        }

        public BattlefieldViewModel()
        {
            GenerateHeaders();
        }

        public DelegateCommand<MapCell> CellSelectedCommand => new DelegateCommand<MapCell>((cell) =>
        {
            _onCellSelected(Map[SelectedCellIndex.Row, SelectedCellIndex.Column]);
        });

        public void Render(MapCell[,] map, Action<MapCell> onCellSelected)
        {
            _onCellSelected = onCellSelected;
            Map = map;
        }

        private void GenerateHeaders()
        {
            ColumnHeaders = new ObservableCollection<string>{"a", "B"};
            RowHeaders = new ObservableCollection<string>{"1", "2"};

        }
    }
}
