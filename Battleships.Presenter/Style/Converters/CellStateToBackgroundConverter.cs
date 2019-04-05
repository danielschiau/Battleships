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

            if (cell.Equals(cell.Character?.Head) && cell.State == MapCellStateType.Hit)
                return new SolidColorBrush(Colors.DarkRed);

            switch (cell.State)
            {
                case MapCellStateType.NotTouched: return new SolidColorBrush(Colors.WhiteSmoke);
                case MapCellStateType.Tested: return new SolidColorBrush(Colors.Gray);
                case MapCellStateType.Hit: return new SolidColorBrush(Colors.Red);
                default: return new SolidColorBrush(Colors.WhiteSmoke);
            }            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
