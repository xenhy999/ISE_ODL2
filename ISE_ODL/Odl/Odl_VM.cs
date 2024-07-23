namespace ISE_ODL.Odl
{
    /*internal*/
    public class Odl_VM : BaseBinding
    {
        public Odl_M Odl_M;
        private List<DateTime> orariInizio = new List<DateTime>();
        private List<DateTime> orariFine = new List<DateTime>();
        private List<DateTime> durataOrari = new List<DateTime>();
        public string Id { get => Odl_M.Id; set => Odl_M.Id = value; }
        public string Cliente { get => Odl_M.Cliente; set => Odl_M.Cliente = value; }
        public string Note { get => Odl_M.Note; set => Odl_M.Note = value; }
        public bool Completata { get => Odl_M.Completata; set => Odl_M.Completata = value; }
        public DateTime OrarioUltimoOdlIniziato;
        public List<DateTime> OrariInizio
        {
            get => Odl_M.OrariInizio;
            set => Odl_M.OrariInizio = value;
        }
        public List<DateTime> OrariFine
        {
            get => Odl_M.OrariFine;
            set
            {
                Odl_M.OrariFine = value;
            }
        }
        public List<TimeSpan> DurataOrari { get => Odl_M.DurataOrari; set => Odl_M.DurataOrari = value; }
        public bool Stato
        {
            get => Odl_M.Stato;
            set
            {
                Odl_M.Stato = value;
                if (value)
                {
                    OrariInizio.Add(DateTime.Now);
                    OrarioUltimoOdlIniziato = DateTime.Now;
                }
                else
                {
                    OrariFine.Add(DateTime.Now);
                    DurataOrari.Add(DateTime.Now.Subtract(OrarioUltimoOdlIniziato));
                }
            }
        }
        public bool OdlInModifica { get; set; }
        public AggiungiOdl AggiungiOdl { get; set; }
        public AggiornaOdl AggiornaOdl { get; set; }
        public Odl_VM(Odl_M odl_M, AggiungiOdl aggiungiOdl, AggiornaOdl aggiornaOdl)
        {
            Odl_M = odl_M;
            AggiungiOdl = aggiungiOdl;
            AggiornaOdl = aggiornaOdl;
        }
        public static explicit operator Odl_VM(Odl_M v) => Odl_F.CreateWithData(v.Id, v.Cliente, v.Note, v.Stato, v.OrariInizio, v.OrariFine, v.DurataOrari);
    }
}
