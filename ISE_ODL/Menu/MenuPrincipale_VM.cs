using System.Collections.ObjectModel;
using ISE_ODL.Odl;
namespace ISE_ODL.Menu
{
    internal class MenuPrincipale_VM : BaseBinding
    {
        public MenuPrincipale_M MenuPrincipale_M = new();
        public ObservableCollection<BaseOdl_VM> Commisioni { get; set; } = [BaseOdl_F.Create()];
        public CreaOdl DefinisciOdl { get; set; }
        public EliminaOdl EliminaOdl { get; set; }
        public ModificaOdl ModificaOdl { get; set; }
        public Esci Esci { get; set; }

        private Odl_VM odlSelezionata;
        private bool mostraCompletati;

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
        public MenuPrincipale_VM(CreaOdl definisciOdl, EliminaOdl eliminaOdl, ModificaOdl modificaOdl, Esci esci)
        {
            DefinisciOdl = definisciOdl;
            EliminaOdl = eliminaOdl;
            ModificaOdl = modificaOdl;
            Esci = esci;
        }
        public bool MostraCompletati
        {
            get => mostraCompletati;
            set
            {
                mostraCompletati = value;
                OnPropertyChanged(nameof(MostraCompletati));
            }
        }
    }
}
