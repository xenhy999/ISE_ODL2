using System.Collections.ObjectModel;
using ISE_ODL.Intervallo;

namespace ISE_ODL.Odl
{
    public class BaseOdl_M
    {
        public BaseOdl_M()
        {
            Intervalli = new List<Intervallo_M>();
        }

        public string Attivita { get; set; }
        public bool Stato { get; set; }
        public List<Intervallo_M> Intervalli { get; set; }
    }
}
