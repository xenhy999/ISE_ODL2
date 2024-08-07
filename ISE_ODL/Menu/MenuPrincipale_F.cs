using ISE_ODL.Lista_Odl;
using ISE_ODL.Resoconto;
using ISE_ODL.Settings;

namespace ISE_ODL.Menu
{
    /// <summary>
    /// La classe MenuPrincipale_F fornisce un metodo per creare una nuova istanza di Menuprincipale_VM.
    /// Si tratta della factori per Menuprincipale_VM
    /// </summary>
    public class MenuPrincipale_F
    {
        /// <summary>
        /// Crea una nuova istanza di Menuprincipale_VM configurata con le istanze specificate di ListaOdl_VM, 
        /// Settings_VM e Resoconto_VM create a partire dalle loro factory.
        /// </summary>
        /// <returns>
        /// Una nuova istanza di Menuprincipale_VM configurata con i ViewModel per la lista degli Odl, le impostazioni 
        /// e il resoconto.
        /// </returns>
        static public Menuprincipale_VM Create() => new(ListaOdl_F.Create(), Setting_F.Create(), Resoconto_F.Create());
    }
}
