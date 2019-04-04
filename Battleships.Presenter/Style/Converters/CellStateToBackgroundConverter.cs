using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Battleships.Models;

namespace Battleships.Presenter.Style.Converters
{
    public class CellStateToBackgroundConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cell = (MapCell)value;

            if (cell.Equals(cell.Ship?.Head) && cell.State == CellStateType.Hit)
                return new SolidColorBrush(Colors.DarkRed);

            switch (cell.State)
            {
                case CellStateType.NotTouched: return new SolidColorBrush(Colors.WhiteSmoke);
                case CellStateType.Tested: return new SolidColorBrush(Colors.Gray);
                case CellStateType.Hit: return new SolidColorBrush(Colors.Red);
                default: return new SolidColorBrush(Colors.Gray);
            }            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
