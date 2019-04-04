using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Battleships.GameEngine.Worlds;

namespace Battleships.Presenter.Style.Converters
{
    public class DebugModeMapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cell = (WorldCell) value;

            if (cell?.Character != null)
            {
                return cell.Equals(cell.Character?.Head) ? new SolidColorBrush(Colors.DarkBlue) : new SolidColorBrush(Colors.Blue);
            }

            return new SolidColorBrush(Colors.WhiteSmoke);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
