using System.Collections.ObjectModel;
using ISE_ODL.Intervallo;
using ISE_ODL.Intervallo.Durata;
namespace ISE_ODL.Odl
{
    /// <summary>
    /// La classe BaseOdl_VM rappresenta il ViewModel per un ordine di lavoro (Odl) e gestisce la logica di visualizzazione e aggiornamento dei dati relativi all'ordine di lavoro.
    /// </summary>
    public class BaseOdl_VM : BaseBinding
    {
        /// <summary>
        /// Modello di dati associato al ViewModel.
        /// </summary>
        protected readonly BaseOdl_M model;
        /// <summary>
        /// Ottiene il Model di dati associato a questa vista.
        /// </summary>
        public BaseOdl_M Model => model;
        /// <summary>
        /// Proprieta che indica il nome dell'attività associata all'ordine di lavoro.
        /// é direttamente collegata al Model
        /// </summary>
        public string Attivita { get => model.Attivita; set => model.Attivita = value; }
        /// <summary>
        /// Indica che l'ordine di lavoro con "Nessuna attivita" non è completato. Questa proprietà è sovrascritta nelle classi derivate.
        /// </summary>
        public virtual bool Completata { get => false; set { return; } }
        /// <summary>
        /// Inizializza una nuova istanza della classe BaseOdl_VM a partire dal modello di dati.
        /// Si tratta del costruttore di BaseOdl_VM
        /// </summary>
        /// <param name="nessunoOdl_M">Il modello di dati associato a questa vista.</param>
        public BaseOdl_VM(BaseOdl_M nessunoOdl_M)
        {
            EliminaIntervallo = new();
            model = nessunoOdl_M;
        }
        /// <summary>
        /// Comando per eliminare un intervallo di tempo associato a questo ordine di lavoro.
        /// </summary>
        public EliminaIntervallo EliminaIntervallo { get; set; }
        /// <summary>
        /// Conrtiene la lista degli intervalli di tempo come una raccolta osservabile. 
        /// Viene creata a partire dal Model.
        /// </summary>
        public ObservableCollection<Intervallo_VM> Intervalli
        {
            get
            {
                // La lista viene ricreata ogi volta a partire da quella del model
                ObservableCollection<Intervallo_VM> Out = [];
                foreach (Intervallo_M i in Model.Intervalli)
                    Out.Add(Intertevallo_F.Create(i, this));
                OrarioVisibile = Out.Count != 0;
                OnPropertyChanged(nameof(OrarioVisibile));
                return Out;
            }
        }
        /// <summary>
        /// Contiene la lista delle durate come una raccolta osservabile.
        /// Ogni durata è calcolata in base agli intervalli di tempo associati a ciascun giorno.
        /// </summary>
        public ObservableCollection<Durata_VM> Durate
        {
            get
            {
                ObservableCollection<Durata_VM> Out = [];
                foreach (DateOnly g in Intervalli.Select(i => i.Giorno).Distinct())
                    Out.Add(Durata_F.Create(g, new TimeSpan(Intervalli.Where(c => c.Giorno == g).Select(b => b.Durata).Sum(r => r.Ticks))));
                return Out;
            }
        }
        /// <summary>
        /// Indica se l'orario è visibile. Questa proprietà viene utilizzata per mostrare o nascondere gli intervalli di tempo.
        /// </summary>
        public bool OrarioVisibile { get; set; }
        /// <summary>
        /// Proprietà che indica lo stato dell'ordine di lavoro. 
        /// Quando lo stato viene cambiato, viene eseguita una serie di aggiornamenti e controlli.
        /// é direttamente collegata al Model
        /// </summary>
        public bool Stato
        {
            get => model.Stato;
            set
            {
                ObjContainer.OdlTimer?.ResetTimer();
                if (model.Stato == value)
                    return;
                model.Stato = value;
                OrarioVisibile = true;
                if (!value)
                {
                    // Quando spengo un odl controllo la sua durata minima
                    if (Intervalli != null)
                    {
                        Intervallo_VM? UltimoIntervallo = Intervalli.LastOrDefault();
                        if (UltimoIntervallo.Durata < ObjContainer.Menuprincipale_VM.Settings_VM.DurataMinimaOdl)
                            EliminaIntervallo.Elimina(this, UltimoIntervallo.Model);
                    }
                }
                OnPropertyChanged(nameof(Stato));
                OnPropertyChanged(nameof(Intervalli));
                OnPropertyChanged(nameof(Durate));
                OnPropertyChanged(nameof(OrarioVisibile));
            }
        }
    }
}
