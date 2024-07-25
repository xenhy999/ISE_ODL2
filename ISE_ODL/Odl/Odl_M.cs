using System.Collections.ObjectModel;

namespace ISE_ODL.Odl
{
    public class Odl_M
    {
        public Odl_M()
        {
            Id = "";
            Cliente = "";
            Attività = "";
            Stato = false;
            Completata = false;
        }
        public string Id { get; set; }
        public string Cliente { get; set; }
        public string Attività { get; set; }
        public bool Stato { get; set; }
        public bool Completata { get; set; }
        public ObservableCollection<DateTime> OrariInizio { get; set; } = [];
        public ObservableCollection<DateTime> OrariFine { get; set; } = [];
        //public ObservableCollection<TimeSpan> DurataOrari { get; set; } = [];
        public ObservableCollection<string> DurataOrari { get; set; } = [];


        public static explicit operator Odl_M(Odl_VM v)
        {
            Odl_M odl_M = new()
            {
                Id = v.Id,
                Cliente = v.Cliente,
                Attività = v.Attività,
                Stato = v.Stato,
                OrariInizio = v.OrariInizio,
                OrariFine = v.OrariFine,
                DurataOrari = v.DurataOrari
            };
            return odl_M;
        }
    }
}
