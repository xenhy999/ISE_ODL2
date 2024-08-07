using System.Text.Json.Serialization;
using ISE_ODL.Intervallo;
namespace ISE_ODL.Odl
{
    [JsonDerivedType(typeof(Odl_M))]
    /// <summary>
    /// La classe BaseOdl_M rappresentail Model di ordine di lavoro (Odl) e gestisce le proprietà relative all'attività e agli intervalli di tempo associati.
    /// </summary>
    public class BaseOdl_M
    {
        /// <summary>
        /// Proprieta che indica il nome dell'attività associata all'ordine di lavoro.
        /// </summary>
        public string Attivita { get; set; }
        /// <summary>
        /// Proprieta che indica la lista degli intervalli di tempo associati all'ordine di lavoro.
        /// </summary>
        public List<Intervallo_M> Intervalli { get; set; } = [];
        private bool stato;
        /// <summary>
        /// Proprietà che indica lo stato dell'ordine di lavoro.
        /// Quando lo stato viene impostato su <c>true</c>, viene aggiunto un nuovo intervallo alla lista.
        /// Quando lo stato viene impostato su <c>false</c>, l'ultimo intervallo viene terminato.
        /// </summary>
        public bool Stato
        {
            get => stato;
            set
            {
                stato = value;
                UpdateIntervalli();
            }
        }
        /// <summary>
        /// Aggiorna la lista degli intervalli in base allo stato dell'ordine di lavoro.
        /// Se lo stato è <c>true</c>, viene aggiunto un nuovo intervallo.
        /// Se lo stato è <c>false</c>, l'ultimo intervallo viene terminato.
        /// </summary>
        private void UpdateIntervalli()
        {
            if (Stato)
                Intervalli.Add(Intertevallo_F.StartNew());
            else
                Intervalli.LastOrDefault()?.EndThis();

        }
    }
}
