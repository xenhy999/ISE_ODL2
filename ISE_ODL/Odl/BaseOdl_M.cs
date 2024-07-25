using System.Collections.ObjectModel;

namespace ISE_ODL.Odl
{
    public class BaseOdl_M
    {
        public string Attivita { get; set; }
        public bool Stato { get; set; }
        public ObservableCollection<DateTime> OrariInizio { get; set; } = [];
        public ObservableCollection<DateTime> OrariFine { get; set; } = [];
        public ObservableCollection<string> DurataOrari { get; set; } = [];
    }
}
