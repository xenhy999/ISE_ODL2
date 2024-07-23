namespace ISE_ODL.Odl
{
    public class Odl_M
    {
        public Odl_M()
        {
            Id = "";
            Cliente = "";
            Note = "";
            Stato = false;
            Completata = false;
        }
        public string Id { get; set; }
        public string Cliente { get; set; }
        public string Note { get; set; }
        public bool Stato { get; set; }
        public bool Completata { get; set; }
        public List<DateTime> OrariInizio { get; set; } = [];
        public List<DateTime> OrariFine { get; set; } = [];
        public List<TimeSpan> DurataOrari { get; set; } = [];
        public static explicit operator Odl_M(Odl_VM v)
        {
            Odl_M odl_M = new()
            {
                Id = v.Id,
                Cliente = v.Cliente,
                Note = v.Note,
                Stato = v.Stato,
                OrariInizio = v.OrariInizio,
                OrariFine = v.OrariFine,
                DurataOrari = v.DurataOrari
            };
            return odl_M;
        }
    }
}
