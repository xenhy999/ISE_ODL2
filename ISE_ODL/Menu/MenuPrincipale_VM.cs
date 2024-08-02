using ISE_ODL.Lista_Odl;
using ISE_ODL.Odl;
using ISE_ODL.Resoconto;
using ISE_ODL.Settings;
namespace ISE_ODL.Menu
{
    internal class Menuprincipale_VM : BaseBinding
    {
        public BaseBinding VistaCorrente
        {
            get => vistaCorrente;
            set
            {
                vistaCorrente = value;
                if (vistaCorrente== Resoconto_VM) Resoconto_VM.CreaGiorni();
            }
        }
        public ListaOdl_VM ListaOdl_VM { get;}
        public Settings_VM Settings_VM { get;}
        public Resoconto_VM Resoconto_VM { get; }

        private bool mostraSettings;
        public bool MostraSettings
        {
            get => mostraSettings;
            set
            {
                mostraSettings = value;
                VistaCorrente = Settings_VM;
                OnPropertyChanged(nameof(VistaCorrente));
            }
        }
        private bool mostraResoconto;
        public bool MostraResoconto
        {
            get => mostraResoconto;
            set
            {
                mostraResoconto = value;
                VistaCorrente = Resoconto_VM;
                Resoconto_VM.CreaGiorni();
                OnPropertyChanged(nameof(VistaCorrente));
            }
        }
        private bool mostraLista;
        private BaseBinding vistaCorrente;

        public bool MostraLista
        {
            get => mostraLista;
            set
            {
                mostraLista = value;
                VistaCorrente = ListaOdl_VM;
                OnPropertyChanged(nameof(VistaCorrente));
            }
        }
        public Menuprincipale_VM(ListaOdl_VM listaOdl_VM, Settings_VM settings_VM, Resoconto_VM resoconto_VM)
        {
            ListaOdl_VM = listaOdl_VM;
            Settings_VM = settings_VM;
            Resoconto_VM = resoconto_VM;
            MostraSettings = false;
            MostraResoconto = false;
            MostraLista = false;
        }
    }
}
