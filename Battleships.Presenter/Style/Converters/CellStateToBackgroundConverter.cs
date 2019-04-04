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
            var cell = (WorldCell)value;

            if (cell.Equals(cell.Character?.Head) && cell.State == WorldCellStateType.Hit)
                return new SolidColorBrush(Colors.DarkRed);

            switch (cell.State)
            {
                case WorldCellStateType.NotTouched: return new SolidColorBrush(Colors.WhiteSmoke);
                case WorldCellStateType.Tested: return new SolidColorBrush(Colors.Gray);
                case WorldCellStateType.Hit: return new SolidColorBrush(Colors.Red);
                default: return new SolidColorBrush(Colors.Gray);
            }            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
