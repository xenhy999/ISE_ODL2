using MongoDB.Bson;

namespace ISE_ODL.Odl
{
    /// <summary>
    /// La classe Odl_F fornisce metodi statici per creare istanze di Odl_VM.
    /// </summary>
    public class Odl_F
    {
        /// <summary>
        /// Crea un'istanza dia partire dal Model .
        /// Inizializza anche i comandi per aggiungere e aggiornare l'ODL.
        /// </summary>
        /// <param name="odl_M">Il Model di dati utilizzato per creare l'istanza di Odl_VM.</param>
        /// <returns>Restituisce una nuova istanza di Odl_VM</returns>
        public static Odl_VM Create(Odl_M odl_M)
        {
            AggiungiOdl aggiungiOdl = new();
            AggiornaOdl aggiornaOdl = new();
            Odl_VM odl_VM = new(odl_M, aggiungiOdl, aggiornaOdl);
            aggiungiOdl.OdlDaAggiungere = odl_VM;
            aggiornaOdl.OdlDaAggiornare = odl_VM;
            return odl_VM;
        }
        /// <summary>
        /// Crea un'istanza di Odl_VM con un nuovo Model di dati Odl_M  non completato e con un ID generato.
        /// </summary>
        /// <returns>Restituisce una nuova istanza di Odl_VM</returns>
        public static Odl_VM Create()
        {
            Odl_M odl_M = new() { Completata = false, _id = ObjectId.GenerateNewId() };
            return Create(odl_M);
        }
    }
}
