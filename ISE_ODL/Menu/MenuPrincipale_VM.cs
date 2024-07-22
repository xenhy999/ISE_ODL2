using System.Collections.ObjectModel;
using ISE_ODL.Odl;

namespace ISE_ODL.Menu
{
    internal class MenuPrincipale_VM : BaseBinding
    {
        public ObservableCollection<Odl_VM> Commisioni { get; set; } = new ObservableCollection<Odl_VM>();
        public CreaOdl DefinisciOdl { get; set; }
        public MenuPrincipale_VM(CreaOdl definisciOdl)
        {
            DefinisciOdl = definisciOdl;
        }
    }
}
