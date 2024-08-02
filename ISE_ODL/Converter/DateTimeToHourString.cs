using System.Globalization;
using System.Windows.Data;

namespace ISE_ODL.Converter
{
    class DateTimeToHourString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => ((DateTime)value).Year < 2000 ? "/" : ((DateTime)value).ToString("t");
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
    }
}
