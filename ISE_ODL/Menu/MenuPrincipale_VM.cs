using ISE_ODL.Lista_Odl;
using ISE_ODL.Resoconto;
using ISE_ODL.Settings;
namespace ISE_ODL.Menu
{
    /// <summary>
    /// La classe Menuprincipale_VM rappresenta il ViewModel principale per la gestione delle viste nel menu.
    /// Gestisce la visualizzazione di tre diverse viste: Lista degli Odl, Impostazioni e Resoconto.
    /// </summary>
    public class Menuprincipale_VM : BaseBinding
    {
        private BaseBinding vistaCorrente;
        /// <summary>
        /// Proprietà che indica la vista corrente visualizzata nel menu principale.
        /// Se la vista corrente è Resoconto_VM, viene chiamato il metodo CreaGiorni per aggiornare i giorni nel resoconto.
        /// </summary>
        public BaseBinding VistaCorrente
        {
            get => vistaCorrente;
            set
            {
                vistaCorrente = value;
                if (vistaCorrente == Resoconto_VM) Resoconto_VM.CreaGiorni();
            }
        }
        /// <summary>
        /// Proprieta GetOnly che contiene l'istanza del ViewModel per la lista degli Odl.
        /// </summary>
        public ListaOdl_VM ListaOdl_VM { get; }
        /// <summary>
        /// Proprieta GetOnly che contiene l'istanza del ViewModel per le impostazioni.
        /// </summary>
        public Settings_VM Settings_VM { get; }
        /// <summary>
        /// Proprieta GetOnly che contiene l'istanza del ViewModel per il resoconto.
        /// </summary>
        public Resoconto_VM Resoconto_VM { get; }
        private bool mostraSettings;
        /// <summary>
        /// Proprieta Booleana che indica se deve essere mostrata la vista delle impostazioni.
        /// Imposta la vista corrente su Settings_VM quando il valore è true e notifica la modifica della proprietà.
        /// </summary>
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
        /// <summary>
        /// Proprieta Booleana che indica se deve essere mostrata la vista delresoconto.
        /// Imposta la vista corrente su Settings_VM quando il valore è true e notifica la modifica della proprietà.
        /// </summary>
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
        /// <summary>
        /// Proprieta Booleana che indica se deve essere mostrata la vista della lista delle Odl.
        /// Imposta la vista corrente su Settings_VM quando il valore è true e notifica la modifica della proprietà.
        /// </summary>
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
        /// <summary>
        /// Inizializza una nuova istanza di Menuprincipale_VM con i ViewModel forniti per la lista degli Odl, le impostazioni 
        /// e il resoconto. Imposta le proprietà MostraSettings e MostraResoconto su false e MostraLista su true per impostazione predefinita.
        /// </summary>
        /// <param name="listaOdl_VM">Il ViewModel per la lista degli Odl.</param>
        /// <param name="settings_VM">Il ViewModel per le impostazioni.</param>
        /// <param name="resoconto_VM">Il ViewModel per il resoconto.</param>
        public Menuprincipale_VM(ListaOdl_VM listaOdl_VM, Settings_VM settings_VM, Resoconto_VM resoconto_VM)
        {
            ListaOdl_VM = listaOdl_VM;
            Settings_VM = settings_VM;
            Resoconto_VM = resoconto_VM;
            MostraSettings = false;
            MostraResoconto = false;
            MostraLista = true;
        }
    }
}
