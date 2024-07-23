using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Xml.Serialization;
using ISE_ODL.Odl;

namespace ISE_ODL.Menu
{
    internal class MenuPrincipale_VM : BaseBinding
    {
        public MenuPrincipale_M MenuPrincipale_M =new MenuPrincipale_M();
        private ObservableCollection<Odl_VM>commisioni = new ObservableCollection<Odl_VM>();
        public ObservableCollection<Odl_VM> Commisioni
        {
            get
            {
                return commisioni;
            }
            set
            {
                commisioni = value;
            }
        }
        public CreaOdl DefinisciOdl { get; set; }
        public EliminaOdl EliminaOdl { get; set; }
        public ModificaOdl ModificaOdl { get; set; }
        public Esci Esci { get; set; }
        private Odl_VM odlSelezionata;
        public Odl_VM OdlSelezionata
        {
            get => odlSelezionata;
            set
            {
                odlSelezionata = value;
                ModificaOdl.OnRaiseCanExecuteChanged();
                EliminaOdl.OnRaiseCanExecuteChanged();

            }
        }
        public bool OdlInEsecuzione {  get; set; }
        public MenuPrincipale_VM(CreaOdl definisciOdl, EliminaOdl eliminaOdl, ModificaOdl modificaOdl,Esci esci)
        {
            DefinisciOdl = definisciOdl;
            EliminaOdl = eliminaOdl;
            ModificaOdl = modificaOdl;
            Esci = esci;
        }
    }
}
