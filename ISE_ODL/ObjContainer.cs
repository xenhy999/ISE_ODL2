using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISE_ODL.Menu;

namespace ISE_ODL
{
    internal static class ObjContainer
    {
        public static MenuPrincipale_VM MenuPrincipale_VM { get; set; }
        public static void Init() => MenuPrincipale_VM = new MenuPrincipale_VM(new Odl.CreaOdl(), new Odl.EliminaOdl(), new Odl.ModificaOdl(), new Esci());
    }
}
