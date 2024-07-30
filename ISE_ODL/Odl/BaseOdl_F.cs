using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_ODL.Odl
{
    public class BaseOdl_F
    {
        public static BaseOdl_VM Create() => new(new BaseOdl_M()) { Attivita = "Nessun ordine di lavoro", Stato = false };
    }
}
