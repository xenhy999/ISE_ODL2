using System.Text.Json.Serialization;
using ISE_ODL.Intervallo;
using ISE_ODL.Intervallo.Durata;

namespace ISE_ODL.Odl
{
    [JsonDerivedType(typeof(Odl_M))]
    public class BaseOdl_M
    {
        public string Attivita { get; set; }
        private bool stato;
        public bool Stato
        {
            get => stato;
            set
            {
                stato = value;
                UpdateIntervalli();
            }
        }
        public List<Intervallo_M> Intervalli { get; set; } = new List<Intervallo_M>();
        private void UpdateIntervalli()
        {
            if (Stato)
            {
                Intervalli.Add(Intertevallo_F.StartNew());

}
            else
            {
                Intervalli.LastOrDefault()?.EndThis();
            }
        }
    }
}
