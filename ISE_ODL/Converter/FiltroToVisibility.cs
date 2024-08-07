using System.Globalization;
using System.Windows;
using System.Windows.Data;
namespace ISE_ODL.Converter
{
    /// <summary>
    /// La classe FiltroToVisibility implementa l'interfaccia IValueConverter
    /// per convertire valori Booleani in valori di Stringa (string) in WPF.
    /// </summary>
    class FiltroToVisibility : IValueConverter
    {
        /// <summary>
        /// Converte un valore Booleano in una Visibilità.
        /// </summary>
        /// <param name="value">Il valore di tipo Booleano da convertire.</param>
        /// <param name="targetType">Il tipo del valore di destinazione (non utilizzato).</param>
        /// <param name="parameter">Parametro opzionale (non utilizzato).</param>
        /// <param name="culture">Le informazioni di cultura da utilizzare nella conversione (non utilizzato).</param>
        /// <returns>
        /// Restituisce Visible se il Booleano è vero ; 
        /// altrimenti, restituisce Collpsed.
        /// </returns>
        /// <exception cref="InvalidCastException">Lanciata se il valore non è di tipo Booleano.</exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (ObjContainer.Menuprincipale_VM.ListaOdl_VM.MostraCompletati && (bool)value) || !(bool)value
                ? Visibility.Visible
                : (object)Visibility.Collapsed;
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
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
    }
}
