using System.Globalization;
using System.Windows.Data;
namespace ISE_ODL.Converter
{
    /// <summary>
    /// La classe DateToString implementa l'interfaccia IValueConverter
    /// per convertire valori DateOnly in valori di Stringa (string) in WPF.
    /// </summary>
    internal class DateToString : IValueConverter
    {
        /// <summary>
        /// Converte un valore DateOnly in una Stringa.
        /// </summary>
        /// <param name="value">Il valore di tipo DateOnly da convertire.</param>
        /// <param name="targetType">Il tipo del valore di destinazione (non utilizzato).</param>
        /// <param name="parameter">Parametro opzionale (non utilizzato).</param>
        /// <param name="culture">Le informazioni di cultura da utilizzare nella conversione (non utilizzato).</param>
        /// <returns>
        /// Restituisce una stringa "/" se l'anno della data è inferiore al 2000; 
        /// altrimenti, restituisce la rappresentazione della data.
        /// </returns>
        /// <exception cref="InvalidCastException">Lanciata se il valore non è di tipo DateOnly.</exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => ((DateOnly)value).Year < 2000 ? "-" : ((DateOnly)value).ToString();
        /// <summary>
        /// Questo metodo non è implementato e lancia sempre un'eccezione.
        /// </summary>
        /// <param name="value">Il valore di DateOnly da convertire indietro (non utilizzato).</param>
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
