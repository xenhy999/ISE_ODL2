namespace ISE_ODL.Odl
{
    /*internal*/
    public class Odl_VM : BaseOdl_VM
    {
        private bool mostraAltro;
        private bool filtro;
        public Odl_VM(Odl_M odl_M, AggiungiOdl aggiungiOdl, AggiornaOdl aggiornaOdl) : base(odl_M)
        {
            AggiungiOdl = aggiungiOdl;
            AggiornaOdl = aggiornaOdl;
            Filtro = false;
        }
        public bool OdlInModifica { get; set; }
        public bool MostraAltro
        {
            get => mostraAltro;
            set
            {
                mostraAltro = value;
                OnPropertyChanged(nameof(MostraAltro));
            }
        }
        public AggiungiOdl AggiungiOdl { get; set; }
        public AggiornaOdl AggiornaOdl { get; set; }
        public string Id { get => ((Odl_M)Model).Id; set => ((Odl_M)Model).Id = value; }
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
        public bool Completata
        {
            get => ((Odl_M)Model).Completata;
            set
            {
                ((Odl_M)Model).Completata = value;
                OnPropertyChanged(nameof(Completata));
                Filtro = Completata && (!Completata || !ObjContainer.MenuPrincipale_VM.MostraCompletati);
                OnPropertyChanged(nameof(Filtro));
                if (value && Stato) ObjContainer.MenuPrincipale_VM.Commisioni[0].Stato = true;
                if (value) Stato = false;
            }
        }
        public bool Filtro
        {
            get => filtro;
            set
            {
                filtro = value;
                OnPropertyChanged(nameof(Filtro));
            }
        }
    }
}
