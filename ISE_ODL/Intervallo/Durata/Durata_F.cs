using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_ODL.Intervallo.Durata
{
    public static class Durata_F
    {
        public static Durata_VM Create(DateOnly data, TimeSpan ore)
        {
            return new Durata_VM() { Data=data,
                                    Ore=ore
            };
        }
    }
}
