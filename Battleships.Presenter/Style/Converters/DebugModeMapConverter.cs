using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Battleships.Models;

namespace Battleships.Presenter.Style.Converters
{
    public class DebugModeMapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((MapCell)value).Ship != null ? new SolidColorBrush(Colors.Blue) : new SolidColorBrush(Colors.WhiteSmoke);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
