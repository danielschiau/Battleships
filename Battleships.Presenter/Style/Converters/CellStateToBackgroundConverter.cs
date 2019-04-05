using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Battleships.GameEngine.Worlds;

namespace Battleships.Presenter.Style.Converters
{
    public class CellStateToBackgroundConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cell = (MapCell)value;

            if (cell == null)
                return new SolidColorBrush(Colors.WhiteSmoke);

            switch (cell.State)
            {
                case MapCellState.Untouched: return new SolidColorBrush(Colors.WhiteSmoke);
                case MapCellState.Touched: return new SolidColorBrush(Colors.Gray);
                case MapCellState.Hit:
                {
                    return cell.Equals(cell.Character?.Head)
                        ? new SolidColorBrush(Colors.DarkRed)
                        : new SolidColorBrush(Colors.Red);
                }
                default: return new SolidColorBrush(Colors.WhiteSmoke);
            }            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
