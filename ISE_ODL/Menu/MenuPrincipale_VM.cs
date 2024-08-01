using ISE_ODL.Lista_Odl;
using ISE_ODL.Odl;
using ISE_ODL.Resoconto;
using ISE_ODL.Settings;
namespace ISE_ODL.Menu
{
    internal class Menuprincipale_VM : BaseBinding
    {
        public BaseBinding VistaCorrente { get; set; } 
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
                VistaCorrente = value ? Settings_VM : ListaOdl_VM;
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
                VistaCorrente = value ? Resoconto_VM : ListaOdl_VM;
                if(value)
                    Resoconto_VM.CreaGiorni();
                OnPropertyChanged(nameof(VistaCorrente));
            }
        }
        public Menuprincipale_VM(ListaOdl_VM listaOdl_VM, Settings_VM settings_VM, Resoconto_VM resoconto_VM)
        {
            ListaOdl_VM = listaOdl_VM;
            Settings_VM = settings_VM;
            Resoconto_VM = resoconto_VM;
            MostraSettings = false;
            //MostraResoconto = false;
        }
    }
}
