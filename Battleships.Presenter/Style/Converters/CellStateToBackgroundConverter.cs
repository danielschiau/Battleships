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
            var state = (CellStateType)value;

            switch (state)
            {
                case CellStateType.Tested: return new SolidColorBrush(Colors.Gray);
                case CellStateType.Hit: return new SolidColorBrush(Colors.Red);
                case CellStateType.NotTouched: 
                default: return new SolidColorBrush(Colors.WhiteSmoke);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
