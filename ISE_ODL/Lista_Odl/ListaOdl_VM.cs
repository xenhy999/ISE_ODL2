using System.Collections.ObjectModel;
using ISE_ODL.Odl;
using ISE_ODL.Report;
namespace ISE_ODL.Lista_Odl
{
    /// <summary>
    /// La classe ListaOdl_VM rappresenta il ViewModel per la gestione di una lista di Odl (Ordini di Lavoro).
    /// Fornisce proprietà e metodi per definire, eliminare, modificare e generare report per gli Odl.
    /// </summary>
    public class ListaOdl_VM : BaseBinding
    {
        /// <summary>
        /// Costruttore di una istanza di ListaOdl_VM con i comandi specificati per creare, eliminare e modificare Odl,
        /// e per generare report di Odl.
        /// </summary>
        /// <param name="definisciOdl">Istanza per definire un nuovo Odl.</param>
        /// <param name="eliminaOdl">Istanza per eliminare un Odl esistente.</param>
        /// <param name="modificaOdl">Istanza per modificare un Odl esistente.</param>
        /// <param name="reportOdl">Istanza per generare report sugli Odl.</param>
        public ListaOdl_VM(CreaOdl definisciOdl, EliminaOdl eliminaOdl, ModificaOdl modificaOdl, ReportOdl reportOdl)
        {
            DefinisciOdl = definisciOdl;
            EliminaOdl = eliminaOdl;
            ModificaOdl = modificaOdl;
            ReportOdl = reportOdl;
            MostraCompletati = true;
            OnPropertyChanged(nameof(MostraCompletati));
        }
        /// <summary>
        /// Proprietà che contiene l'istanza per definire un nuovo Odl.
        /// </summary>
        public CreaOdl DefinisciOdl { get; set; }
        /// <summary>
        /// Proprietà che contiene l'istanza per eliminare un Odl.
        /// </summary>
        public EliminaOdl EliminaOdl { get; set; }
        /// <summary>
        /// Proprietà che contiene l'istanza per modificare un Odl.
        /// </summary>
        public ModificaOdl ModificaOdl { get; set; }
        /// <summary>
        /// Proprietà che contiene l'istanza per definire un nuovo report di Odl.
        /// </summary>
        public ReportOdl ReportOdl { get; set; }
        /// <summary>
        /// Proprietà che indica una collezione osservabile di oggetti BaseOdl_VM che rappresentano gli Odl.
        /// </summary>
        public ObservableCollection<BaseOdl_VM> Commisioni { get; set; } = [BaseOdl_F.Create()];
        private Odl_VM? odlSelezionata;
        /// <summary>
        /// Proprieta che contiene l'Odl selezionato attualmente. Notifica i comandi di eliminazione e modifica in base all'Odl selezionato.
        /// </summary>
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
        /// <summary>
        /// Proprieta che indica se devono essere mostrati solo gli Odl non completati.
        /// Aggiorna il filtro degli Odl e notifica la modifica della proprietà.
        /// </summary>
        public bool MostraCompletati
        {
            get => mostraCompletati;
            set
            {
                mostraCompletati = value;
                foreach (Odl_VM item in Commisioni.Where(c => c is Odl_VM).Cast<Odl_VM>())
                {
                    item.Filtro = !(!item.Completata || item.Completata && ObjContainer.Menuprincipale_VM.ListaOdl_VM.MostraCompletati);
                    OnPropertyChanged(nameof(item.Filtro));
                }
                OnPropertyChanged(nameof(MostraCompletati));
            }
        }
        /// <summary>
        /// Metodo che ordina la lista di Odl in base al loro stato di completamento.
        /// </summary>
        public void OrdinaLista()
        {
            Commisioni = new ObservableCollection<BaseOdl_VM>(Commisioni.OrderBy(c => c.Completata));
            OnPropertyChanged(nameof(Commisioni));
        }
    }
}
