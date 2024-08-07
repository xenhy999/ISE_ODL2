using System.Globalization;
using System.Windows.Data;
namespace ISE_ODL.Converter
{
    /// <summary>
    /// La classe TimeSpanToHourMinute implementa l'interfaccia IValueConverter
    /// per convertire valori TimeSpan in stringhe che rappresentano ore e minuti.
    /// </summary>
    class TimeSpanToHourMinute : IValueConverter
    {
        /// <summary>
        /// Converte un valore TimeSpan in una stringa che rappresenta l'ora e i minuti.
        /// </summary>
        /// <param name="value">Il valore da convertire, atteso di tipo TimeSpan.</param>
        /// <param name="targetType">Il tipo del valore di destinazione (non utilizzato).</param>
        /// <param name="parameter">Parametro opzionale (non utilizzato).</param>
        /// <param name="culture">Le informazioni di cultura da utilizzare nella conversione (non utilizzato).</param>
        /// <returns>
        /// Restituisce una stringa che rappresenta l'ora e i minuti del TimeSpan aggiunto alla data di oggi,
        /// formattata come ora breve ("t").
        /// </returns>
        /// <exception cref="InvalidCastException">Lanciata se il valore non è di tipo TimeSpan.</exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => DateTime.Today.Add((TimeSpan)value).ToString("t");
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
