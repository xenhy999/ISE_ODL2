using System.Globalization;
using System.Windows.Data;

namespace ISE_ODL.Converter
{
    class TimeSpanToHourMinute : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTime.Today.Add((TimeSpan)value).ToString("t");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
