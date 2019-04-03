using Battleships.Models;
using Battleships.Presenter.Pages.Base;

namespace Battleships.Presenter.Pages.Battlefield
{
    public class BattlefieldViewModel : BaseViewModel
    {
        private SeaBattle _seaBattle;
        public SeaBattle SeaBattle
        {
            get => _seaBattle;
            set { _seaBattle = value; OnPropertyChanged(nameof(SeaBattle));}
        }

        private MapCell _selectedCell;
        public MapCell SelectedCell
        {
            get => _selectedCell;
            set { _selectedCell = value;  OnPropertyChanged(nameof(SelectedCell)); }
        }

        public void Render(SeaBattle seaBattle)
        {
            SeaBattle = seaBattle;
        }
    }
}
