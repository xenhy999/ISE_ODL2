namespace ISE_ODL.Odl
{
    /// <summary>
    /// La classe il ViewModel per un ordine di lavoro (ODL).
    /// Eredita da BaseOdl_VM e aggiunge funzionalità specifiche per la gestione e l'interazione con gli ODL.
    /// </summary>
    public class Odl_VM : BaseOdl_VM
    {
        /// <summary>
        /// Proprietà che indica lo stato di completamento dell'ODL.
        /// Se impostato su <c>true</c>, l'ODL è considerato completato. Aggiorna anche il filtro e lo stato degli ODL.
        /// </summary>
        public override bool Completata
        {
            get => ((Odl_M)Model).Completata;
            set
            {
                ((Odl_M)Model).Completata = value;
                Filtro = Completata && (!Completata || !ObjContainer.Menuprincipale_VM.ListaOdl_VM.MostraCompletati);
                if (value && Stato) ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni[0].Stato = true;
                if (value)
                {
                    Stato = false;
                    DataCompletamento = DateTime.Now;
                }
                OnPropertyChanged(nameof(Completata));
                OnPropertyChanged(nameof(ObjContainer.Menuprincipale_VM.ListaOdl_VM.MostraCompletati));
                OnPropertyChanged(nameof(Filtro));
                ObjContainer.Menuprincipale_VM.ListaOdl_VM.OrdinaLista();
            }
        }
        /// <summary>
        /// Inizializza una nuova istanza di Odl_VM con il modello di dati specificato e i comandi associati.
        /// </summary>
        /// <param name="odl_M">Il modello di dati per l'ODL.</param>
        /// <param name="aggiungiOdl">Il comando per aggiungere un ODL.</param>
        /// <param name="aggiornaOdl">Il comando per aggiornare un ODL.</param>
        public Odl_VM(Odl_M odl_M, AggiungiOdl aggiungiOdl, AggiornaOdl aggiornaOdl) : base(odl_M)
        {
            AggiungiOdl = aggiungiOdl;
            AggiornaOdl = aggiornaOdl;
            Filtro = false;
        }
        /// <summary>
        /// Proprietà che indica se l'ODL è in fase di modifica.
        /// </summary>
        public bool OdlInModifica { get; set; }
        /// <summary>
        /// Proprietà che contiene il comando per aggiungere un ODL.
        /// </summary>
        public AggiungiOdl AggiungiOdl { get; set; }
        /// <summary>
        /// Proprietà che contiene il comando per aggiornare un ODL.
        /// </summary>
        public AggiornaOdl AggiornaOdl { get; set; }
        /// <summary>
        /// Proprietà che indica l'identificativo dell'ODL.
        /// È direttamente collegata al Model
        /// </summary>
        public string Id { get => ((Odl_M)Model).OdlId; set => ((Odl_M)Model).OdlId = value; }
        /// <summary>
        /// Proprietà che indica la data di completamento.
        /// È direttamente collegata al Model
        /// </summary>
        public DateTime DataCompletamento { get => ((Odl_M)Model).DataCompletamento; set => ((Odl_M)Model).DataCompletamento = value; }
        private bool mostraAltro;
        /// <summary>
        /// proprietà che indica se devono essere visualizzate ulteriori informazioni.
        /// </summary>
        public bool MostraAltro
        {
            get => mostraAltro;
            set
            {
                mostraAltro = value;
                OnPropertyChanged(nameof(MostraAltro));
            }
        }
        /// <summary>
        /// Proprietà che indica il cliente.
        /// È direttamente collegata al Model
        /// </summary>
        public string Cliente
        {
            get => ((Odl_M)Model).Cliente;
            set
            {
                ((Odl_M)Model).Cliente = value;
                AggiungiOdl.OnRaiseCanExecuteChanged();
                AggiornaOdl.OnRaiseCanExecuteChanged();
            }
        }
        private bool filtro;
        /// <summary>
        /// Proprietà che indica il filtro applicato all'ODL.
        /// </summary>
        public bool Filtro
        {
            get => filtro;
            set
            {
                filtro = value;
                OnPropertyChanged(nameof(Filtro));
            }
        }
        /// <summary>
        /// Determina se l'ODL è stato attivato in una data specifica e calcola la durata totale per quella data.
        /// </summary>
        /// <param name="g">La data da controllare.</param>
        /// <param name="durataTotale">La durata totale per la data specificata.</param>
        /// <returns>Restituisce <c>true</c> se l'ODL è stato attivato nella data specificata; altrimenti, <c>false</c>.</returns>
        public bool AttivatoIl(DateOnly g, out TimeSpan durataTotale)
        {
            if (!Durate.Any(d => d.Data == g))
            {
                durataTotale = TimeSpan.Zero;
                return false;
            }
            durataTotale = new TimeSpan(Durate.Where(d => d.Data == g).Sum(d => d.Ore.Ticks));
            return true;
        }
    }
}
