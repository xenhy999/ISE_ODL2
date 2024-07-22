using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_ODL.Odl
{
    internal class Odl_F
    {
        public static Odl_VM Create()
        {
            Odl_M odl_M = new Odl_M();
            AggiungiOdl aggiungiOdl = new AggiungiOdl ();
            Odl_VM odl_VM = new Odl_VM(odl_M, aggiungiOdl);
            aggiungiOdl.OdlDaAggiungere = odl_VM;
            return odl_VM;
        }
    }
}
