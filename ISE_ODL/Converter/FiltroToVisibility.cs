using System.Globalization;
using System.Windows;
using System.Windows.Data;
namespace ISE_ODL.Converter
{
    class FiltroToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (ObjContainer.Menuprincipale_VM.ListaOdl_VM.MostraCompletati && (bool)value) || !(bool)value
                ? Visibility.Visible
                : (object)Visibility.Collapsed;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
    }
}
