using ISE_ODL.Lista_Odl;
using ISE_ODL.Settings;
namespace ISE_ODL.Menu
{
    internal class Menuprincipale_VM : BaseBinding
    {
        public BaseBinding VistaCorrente { get; set; } 
        public ListaOdl_VM ListaOdl_VM { get;}
        public Settings_VM Settings_VM { get;}
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
        public Menuprincipale_VM(ListaOdl_VM listaOdl_VM, Settings_VM settings_VM)
        {
            ListaOdl_VM = listaOdl_VM;
            Settings_VM = settings_VM;
            MostraSettings = false;
        }
    }
}
