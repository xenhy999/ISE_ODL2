using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ISE_ODL.Odl
{
    /// <summary>
    /// La classe Odl_M rappresenta un modello di dati per un ordine di lavoro (Odl).
    /// Eredita da "BaseOdl_M e aggiunge proprietà specifiche per la gestione degli Odl.
    /// </summary>
    public class Odl_M : BaseOdl_M
    {
        /// <summary>
        /// Proprietà che contiene l'identificatore unico dell'ODL. 
        /// Questo valore è generato automaticamente al momento della creazione dell'istanza.
        /// </summary>
        public Object _id { get; set; } = ObjectId.GenerateNewId();
        /// <summary>
        /// Proprietà che contiene l'identificativo dell'ODL.
        /// Questo è un valore univoco utilizzato per identificare l'ODL.
        /// </summary>
        public string OdlId { get; set; }
        /// <summary>
        /// Proprietà che contiene il nome del cliente associato all'ODL.
        /// Questo campo rappresenta il cliente per il quale l'ODL è stato creato.
        /// </summary>
        public string Cliente { get; set; }
        /// <summary>
        /// Proprietà che contiene lo stato di completamento dell'ODL.
        /// Se <c>true</c>, l'ODL è completato; altrimenti, è ancora in corso.
        /// </summary>
        public bool Completata { get; set; }
        /// <summary>
        /// Proprietà che contiene la data di completamento dell'ODL.
        /// Questo campo indica quando l'ODL è stato completato.
        /// </summary>
        public DateTime DataCompletamento { get; set; }
    }
}
