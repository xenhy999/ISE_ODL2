using System.Globalization;
using System.Windows.Data;
namespace ISE_ODL.Converter
{
    internal class DateToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => ((DateOnly)value).Year < 2000 ? "-" : ((DateOnly)value).ToString();
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string[]? valori = value.ToString()?.Split('/');
            List<int> valoriNumerici = new List<int>();
            foreach (string s in valori)
                valoriNumerici.Add(int.Parse(s));
            return new DateTime(valoriNumerici[2], valoriNumerici[1], valoriNumerici[0]);
        }
    }
}
