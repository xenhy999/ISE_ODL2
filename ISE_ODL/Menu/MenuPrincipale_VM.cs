using System.Collections.ObjectModel;
using ISE_ODL.Odl;
namespace ISE_ODL.Menu
{
    internal class MenuPrincipale_VM : BaseBinding
    {
        public MenuPrincipale_M MenuPrincipale_M = new();
        public MenuPrincipale_VM(CreaOdl definisciOdl, EliminaOdl eliminaOdl, ModificaOdl modificaOdl)
        {
            DefinisciOdl = definisciOdl;
            EliminaOdl = eliminaOdl;
            ModificaOdl = modificaOdl;
            MostraCompletati = false;
            OnPropertyChanged(nameof(MostraCompletati));
        }
        public CreaOdl DefinisciOdl { get; set; }
        public EliminaOdl EliminaOdl { get; set; }
        public ModificaOdl ModificaOdl { get; set; }
        public ObservableCollection<BaseOdl_VM> Commisioni { get; set; } = [BaseOdl_F.Create()];
        private Odl_VM? odlSelezionata;
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
        private bool mostraCompletati;
        public bool MostraCompletati
        {
            get => mostraCompletati;
            set
            {
                mostraCompletati = value;
                foreach (Odl_VM item in Commisioni.Where(c => c is Odl_VM).Cast<Odl_VM>())
                {
                    item.Filtro = !(!item.Completata || item.Completata && ObjContainer.MenuPrincipale_VM.MostraCompletati);
                    OnPropertyChanged(nameof(item.Filtro));
                }
                OnPropertyChanged(nameof(MostraCompletati));
            }
        }
    }
}
