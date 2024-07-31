using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace ISE_ODL.Lista_Odl
{
    internal class ListaOdl_F
    {
       static public ListaOdl_VM Create() => new( new Odl.CreaOdl(), new Odl.EliminaOdl(), new Odl.ModificaOdl());
    }
}
