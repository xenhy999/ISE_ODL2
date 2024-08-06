using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISE_ODL.Odl;

namespace ISE_ODL.Intervallo
{
    internal static class Intertevallo_F
    {
        public static Intervallo_M StartNew()
        {
            return new Intervallo_M
            {
                Giorno = DateTime.Now,
                OrarioInizio = DateTime.Now,
                OrarioCompleto = false
            };
        }
        public static Intervallo_VM Create(Intervallo_M intervallo_M, BaseOdl_VM baseOdl_VM)
        {
            EliminaIntervallo eliminaIntervallo = new EliminaIntervallo();
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
