using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISE_ODL.Odl;

namespace ISE_ODL.Intervallo
{
    /// <summary>
    /// La classe statica Intertevallo_F fornisce metodi per la creazione e gestione degli intervalli di tempo.
    /// Si tratta della factory di Intervallo_VM
    /// </summary>
    internal static class Intertevallo_F
    {
        /// <summary>
        /// Crea e avvia un nuovo intervallo di tempo.
        /// </summary>
        /// <returns>Restituisce una nuova istanza di Intervallo_M con la data e l'orario di inizio impostati all'ora corrente e OrarioCompleto impostato su false.</returns>
        public static Intervallo_M StartNew()
        {
            return new Intervallo_M
            {
                Giorno = DateTime.Now,
                OrarioInizio = DateTime.Now,
                OrarioCompleto = false
            };
        }
        /// <summary>
        /// Crea un nuovo ViewModel dell'intervallo di tempo (Intervallo_VM) e inizializza i comandi per l'eliminazione e la modifica dell'intervallo.
        /// </summary>
        /// <param name="intervallo_M">L'istanza di Intervallo_M da associare al ViewModel.</param>
        /// <param name="baseOdl_VM">L'istanza di BaseOdl_VM a cui l'intervallo appartiene.</param>
        /// <returns>Restituisce una nuova istanza di Intervallo_VM a partire dal MOdel configurata con i comandi di eliminazione e modifica.</returns>
        public static Intervallo_VM Create(Intervallo_M intervallo_M, BaseOdl_VM baseOdl_VM)
        {
            EliminaIntervallo eliminaIntervallo = new();
            ModificaIntervallo modificaIntervallo = new();
            Intervallo_VM intervallo_VM = new(intervallo_M, eliminaIntervallo, modificaIntervallo);
            eliminaIntervallo.IntervalloDaEliminare = intervallo_M;
            eliminaIntervallo.OdlDellIntervallo = baseOdl_VM;
            modificaIntervallo.OdlDellIntervallo = baseOdl_VM;
            modificaIntervallo.IntervalloDaModificare = intervallo_M;
            return intervallo_VM;
        }
    }
}
