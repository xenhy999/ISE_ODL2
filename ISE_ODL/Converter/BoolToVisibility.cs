using System.Globalization;
using System.Windows;
using System.Windows.Data;
namespace ISE_ODL.Converter
{
    /// <summary>
    /// La classe BoolToVisibility implementa l'interfaccia IValueConverter
    /// per convertire valori booleani in valori di visibilità (Visibility) in WPF.
    /// </summary>
    public class BoolToVisibility : IValueConverter
    {
        /// <summary>
        /// Converte un valore booleano in un valore di visibilità.
        /// </summary>
        /// <param name="value">Il valore booleano da convertire.</param>
        /// <param name="targetType">Il tipo del valore di destinazione (non utilizzato).</param>
        /// <param name="parameter">Parametro opzionale (non utilizzato).</param>
        /// <param name="culture">Le informazioni di cultura da utilizzare nella conversione (non utilizzato).</param>
        /// <returns>
        /// Restituisce Visibility.Visible se il valore booleano è true; 
        /// altrimenti, restituisce Visibility.Collapsed.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (bool)value == true ? Visibility.Visible : Visibility.Collapsed;
        /// <summary>
        /// Questo metodo non è implementato e lancia sempre un'eccezione.
        /// </summary>
        /// <param name="value">Il valore di visibilità da convertire indietro (non utilizzato).</param>
        /// <param name="targetType">Il tipo del valore di destinazione (non utilizzato).</param>
        /// <param name="parameter">Parametro opzionale (non utilizzato).</param>
        /// <param name="culture">Le informazioni di cultura da utilizzare nella conversione (non utilizzato).</param>
        /// <returns>
        /// Non restituisce nulla poiché il metodo lancia sempre un'eccezione.
        /// </returns>
        /// <exception cref="NotImplementedException">Viene sempre lanciata poiché il metodo non è implementato.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
