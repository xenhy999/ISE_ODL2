using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_ODL.Intervallo
{
    internal static class Intertevallo_F
    {
        public static Intervallo_M StartNew()
        {
            Intervallo_M m = new()
            {
                OrarioInizio = DateTime.Now,
                OrarioCompleto = false
            };
            return m;
        }

        public static Intervallo_VM Create(Intervallo_M m) => new Intervallo_VM(m);

    }
}
