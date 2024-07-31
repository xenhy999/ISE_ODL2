using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISE_ODL.Lista_Odl;
using ISE_ODL.Menu;
using ISE_ODL.Odl;

namespace ISE_ODL
{
    internal static class ObjContainer
    {
        //public static ListaOdl_VM ListaOdl_VM { get; set; }
        //public static void Init() => ListaOdl_VM = new ListaOdl_VM(new Odl.CreaOdl(), new Odl.EliminaOdl(), new Odl.ModificaOdl() );
        public static Menuprincipale_VM Menuprincipale_VM { get; set; }
        public static OdlTimer OdlTimer { get; set; }
        public static void Init() => Menuprincipale_VM=MenuPrincipale_F.Create();

    }
}
