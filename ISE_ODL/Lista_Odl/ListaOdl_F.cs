namespace ISE_ODL.Lista_Odl
{
    /// <summary>
    /// La classe statica ListaOdl_F fornisce un metodo per creare una nuova istanza di ListaOdl_VM.
    /// Si tratta della factory degli elementi ListOdl_VM
    /// </summary>
    public class ListaOdl_F
    {
        /// <summary>
        /// Crea una nuova istanza di ListaOdl_VM utilizzando i comandi forniti per creare, eliminare e modificare Odl, 
        /// e per generare report di Odl.
        /// </summary>
        /// <returns>
        /// Una nuova istanza di ListaOdl_VM configurata con i comandi specificati.
        /// </returns>
        public static ListaOdl_VM Create() => new(new Odl.CreaOdl(), new Odl.EliminaOdl(), new Odl.ModificaOdl(), new Report.ReportOdl());
    }
}
