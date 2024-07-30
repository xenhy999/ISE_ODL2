using System.Collections.ObjectModel;
using ISE_ODL.Odl;
namespace ISE_ODL.Menu
{
    internal class MenuPrincipale_VM : BaseBinding
    {
        public MenuPrincipale_M MenuPrincipale_M = new();
        private ObservableCollection<BaseOdl_VM> commisioni = [BaseOdl_F.Create()];
        public ObservableCollection<BaseOdl_VM> Commisioni
        {
            get
            {
                
                return commisioni;
            }

            set => commisioni = value;
        }
        public CreaOdl DefinisciOdl { get; set; }
        public EliminaOdl EliminaOdl { get; set; }
        public ModificaOdl ModificaOdl { get; set; }
        private Odl_VM? odlSelezionata;
        private bool mostraCompletati;

        public Odl_VM? OdlSelezionata
        {
            get => odlSelezionata;
            set
            {
                odlSelezionata = value;
                ModificaOdl.OnRaiseCanExecuteChanged();
                EliminaOdl.OnRaiseCanExecuteChanged();
            }
        }
        public MenuPrincipale_VM(CreaOdl definisciOdl, EliminaOdl eliminaOdl, ModificaOdl modificaOdl)
        {
            DefinisciOdl = definisciOdl;
            EliminaOdl = eliminaOdl;
            ModificaOdl = modificaOdl;
            MostraCompletati = false;
            OnPropertyChanged(nameof(MostraCompletati));
        }
        public bool MostraCompletati
        {
            get => mostraCompletati;
            set
            {
                mostraCompletati = value;
                IEnumerable<Odl_VM> l = Commisioni.Where(c => c is Odl_VM).Cast<Odl_VM>();
                foreach (Odl_VM item in l)
                {
                    if (!item.Completata || (item.Completata && ObjContainer.MenuPrincipale_VM.MostraCompletati)) item.Filtro = false;
                    else item.Filtro = true;
                    OnPropertyChanged(nameof(item.Filtro));
                }
                OnPropertyChanged(nameof(MostraCompletati));
            }
        }
    }
}
