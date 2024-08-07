using System.Globalization;
using System.Windows.Data;
namespace ISE_ODL.Converter
{
    /// <summary>
    /// La classe NotBool implementa l'interfaccia IValueConverter
    /// per convertire valori Booleani in valori di Booleani (bool) in WPF.
    /// </summary>
    public class NotBool : IValueConverter
    {
        /// <summary>
        /// Converte un valore Booleano nel suo opposto.
        /// </summary>
        /// <param name="value">Il valore di tipo Booleano da convertire.</param>
        /// <param name="targetType">Il tipo del valore di destinazione (non utilizzato).</param>
        /// <param name="parameter">Parametro opzionale (non utilizzato).</param>
        /// <param name="culture">Le informazioni di cultura da utilizzare nella conversione (non utilizzato).</param>
        /// <returns>
        /// Restituisce il Booleano Contrario; 
        /// </returns>
        /// <exception cref="InvalidCastException">Lanciata se il valore non è di tipo Booleano.</exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value;
        /// <summary>
        /// Questo metodo non è implementato e lancia sempre un'eccezione.
        /// </summary>
        /// <param name="value">Il valore di bool da convertire indietro (non utilizzato).</param>
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
