using ISE_ODL.Menu;
using ISE_ODL.Odl;
namespace ISE_ODL
{
    /// <summary>
    /// Contenitore statico per le principali istanze utilizzate nell'applicazione.
    /// </summary>
    internal static class ObjContainer
    {
        /// <summary>
        /// Istanza di Menuprincipale_VM che rappresenta la vista principale del menu.
        /// </summary>
        public static Menuprincipale_VM Menuprincipale_VM { get; set; }
        /// <summary>
        /// Istanza di OdlTimer utilizzata per gestire i timer delle attività.
        /// </summary>
        public static OdlTimer OdlTimer { get; set; }
         /// <summary>
        /// Metodo per inizializzare le istanze principali dell'applicazione.
        /// </summary>
        public static void Init()
        {
            Menuprincipale_VM = MenuPrincipale_F.Create();
            OdlTimer = new();
        }
    }
}
