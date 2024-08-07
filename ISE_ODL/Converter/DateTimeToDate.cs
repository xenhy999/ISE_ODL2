using System.Globalization;
using System.Windows.Data;
namespace ISE_ODL.Converter

{/// <summary>
 /// La classe DateTimeToDate implementa l'interfaccia IValueConverter
 /// per convertire valori DateTime in valori di Stringa (string) in WPF.
 /// </summary>
    internal class DateTimeToDate : IValueConverter
    {
        /// <summary>
        /// Converte un valore DateTime in una Stringa.
        /// </summary>
        /// <param name="value">Il valore di tipo DateTime da convertire.</param>
        /// <param name="targetType">Il tipo del valore di destinazione (non utilizzato).</param>
        /// <param name="parameter">Parametro opzionale (non utilizzato).</param>
        /// <param name="culture">Le informazioni di cultura da utilizzare nella conversione (non utilizzato).</param>
        /// <returns>
        /// Restituisce una stringa "/" se l'anno della data è inferiore al 2000; 
        /// altrimenti, restituisce la rappresentazione della data formattata come stringa breve ("d").
        /// </returns>
        /// <exception cref="InvalidCastException">Lanciata se il valore non è di tipo DateTime.</exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => ((DateTime)value).Year < 2000 ? "/" : ((DateTime)value).ToString("d");
        /// <summary>
        /// Questo metodo non è implementato e lancia sempre un'eccezione.
        /// </summary>
        /// <param name="value">Il valore di DateTime da convertire indietro (non utilizzato).</param>
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
