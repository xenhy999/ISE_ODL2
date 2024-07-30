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
            Intervallo_M m = new()
            {
                Giorno = DateOnly.FromDateTime(DateTime.Now),
                OrarioInizio = DateTime.Now,
                OrarioCompleto = false
            };
            return m;
        }

        public static Intervallo_VM Create(Intervallo_M m, BaseOdl_VM baseOdl_VM)
        {
            EliminaIntervallo eliminaIntervallo = new EliminaIntervallo();
            Intervallo_VM i = new Intervallo_VM(m,eliminaIntervallo);
            eliminaIntervallo.IntervalloDaEliminare = m;
            eliminaIntervallo.OdlDellIntervallo = baseOdl_VM;
            return i;
        }
    }
}
