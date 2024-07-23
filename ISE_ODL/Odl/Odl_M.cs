using System.Collections.ObjectModel;
using System.Security.AccessControl;

namespace ISE_ODL.Odl
{
    public class Odl_M
    {
        private List<DateTime> orariFine = new List<DateTime>();
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
        public List<DateTime> OrariInizio { get; set; }=new List<DateTime>();
        public List<DateTime> OrariFine
        {
            get => orariFine;
            set
            {
                orariFine = value;
            }
        }
        public List<TimeSpan> DurataOrari { get; set; } = new List<TimeSpan>();
        public static explicit operator Odl_M(Odl_VM v)
        {
            Odl_M odl_M= new Odl_M();
            odl_M.Id=v.Id;
            odl_M.Cliente=v.Cliente;
            odl_M.Note=v.Note;
            odl_M.Stato=v.Stato;
            odl_M.OrariInizio = v.OrariInizio;
            odl_M.OrariFine = v.OrariFine;
            odl_M.DurataOrari=v.DurataOrari;
            return odl_M;
        }
    }
}
