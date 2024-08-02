namespace ISE_ODL.Odl
{
    public class Odl_VM : BaseOdl_VM
    {
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
                    DataCompletamento = DateOnly.FromDateTime(DateTime.Now);
                }
                OnPropertyChanged(nameof(Completata));
                OnPropertyChanged(nameof(ObjContainer.Menuprincipale_VM.ListaOdl_VM.MostraCompletati));
                OnPropertyChanged(nameof(Filtro));
                ObjContainer.Menuprincipale_VM.ListaOdl_VM.OrdinaLista();
            }
        }
        public Odl_VM(Odl_M odl_M, AggiungiOdl aggiungiOdl, AggiornaOdl aggiornaOdl) : base(odl_M)
        {
            AggiungiOdl = aggiungiOdl;
            AggiornaOdl = aggiornaOdl;
            Filtro = false;
        }
        public bool OdlInModifica { get; set; }
        public AggiungiOdl AggiungiOdl { get; set; }
        public AggiornaOdl AggiornaOdl { get; set; }
        public string Id { get => ((Odl_M)Model).Id; set => ((Odl_M)Model).Id = value; }
        public DateOnly DataCompletamento { get => ((Odl_M)Model).DataCompletamento; set => ((Odl_M)Model).DataCompletamento = value; }
        private bool mostraAltro;
        public bool MostraAltro
        {
            get => mostraAltro;
            set
            {
                mostraAltro = value;
                OnPropertyChanged(nameof(MostraAltro));
            }
        }
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
        public bool Filtro
        {
            get => filtro;
            set
            {
                filtro = value;
                OnPropertyChanged(nameof(Filtro));
            }
        }
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
