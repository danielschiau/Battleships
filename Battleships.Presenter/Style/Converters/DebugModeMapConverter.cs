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
            var cell = (MapCell) value;
            var result = cell?.Ship != null ? new SolidColorBrush(Colors.Blue) : new SolidColorBrush(Colors.WhiteSmoke);

            return cell?.Ship?.Head.Row == cell?.Row && cell?.Ship.Head.Column == cell?.Column
                ? new SolidColorBrush(Colors.DarkBlue)
                : result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
