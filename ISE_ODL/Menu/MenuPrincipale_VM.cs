using ISE_ODL.Lista_Odl;
using ISE_ODL.Settings;
namespace ISE_ODL.Menu
{
    internal class Menuprincipale_VM : BaseBinding
    {
        private bool mostraSettings;

        public bool MostraSettings
        {
            get => mostraSettings;
            set
            {
                if (value) VistaCorrente = ListaOdl_VM;
                else VistaCorrente = Settings_VM;
                OnPropertyChanged(nameof(VistaCorrente));
                mostraSettings = value;
            }
        }
        public BaseBinding VistaCorrente { get; set; } 
        public ListaOdl_VM ListaOdl_VM { get;}
        public Settings_VM Settings_VM { get;}

        public Menuprincipale_VM(ListaOdl_VM listaOdl_VM, Settings_VM settings_VM)
        {
            ListaOdl_VM = listaOdl_VM;
            Settings_VM = settings_VM;
            MostraSettings = false;
        }



        // Da spostare in ListaOdl_VM

        //public MenuPrincipale_M MenuPrincipale_M = new();
        //public MenuPrincipale_VM(CreaOdl definisciOdl, EliminaOdl eliminaOdl, ModificaOdl modificaOdl)
        //{
        //    DefinisciOdl = definisciOdl;
        //    EliminaOdl = eliminaOdl;
        //    ModificaOdl = modificaOdl;
        //    MostraCompletati = false;
        //    OnPropertyChanged(nameof(MostraCompletati));
        //}
        //public CreaOdl DefinisciOdl { get; set; }
        //public EliminaOdl EliminaOdl { get; set; }
        //public ModificaOdl ModificaOdl { get; set; }
        //public ObservableCollection<BaseOdl_VM> Commisioni { get; set; } = [BaseOdl_F.Create()];
        //private Odl_VM? odlSelezionata;
        //public Odl_VM? OdlSelezionata
        //{
        //    get => odlSelezionata;
        //    set
        //    {
        //        odlSelezionata = value;
        //        ModificaOdl.OnRaiseCanExecuteChanged();
        //        EliminaOdl.OnRaiseCanExecuteChanged();
        //    }
        //}
        //private bool mostraCompletati;
        //public bool MostraCompletati
        //{
        //    get => mostraCompletati;
        //    set
        //    {
        //        mostraCompletati = value;
        //        foreach (Odl_VM item in Commisioni.Where(c => c is Odl_VM).Cast<Odl_VM>())
        //        {
        //            item.Filtro = !(!item.Completata || item.Completata && ObjContainer.MenuPrincipale_VM.MostraCompletati);
        //            OnPropertyChanged(nameof(item.Filtro));
        //        }
        //        OnPropertyChanged(nameof(MostraCompletati));
        //    }
        //}
    }
}
