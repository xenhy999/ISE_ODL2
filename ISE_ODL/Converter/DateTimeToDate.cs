using System.Globalization;
using System.Windows.Data;
namespace ISE_ODL.Converter
{
    internal class DateTimeToDate : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => ((DateTime)value).Year < 2000 ? "/" : ((DateTime)value).ToString("d");
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
