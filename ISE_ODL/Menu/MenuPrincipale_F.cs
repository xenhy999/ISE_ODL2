using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISE_ODL.Lista_Odl;
using ISE_ODL.Settings;

namespace ISE_ODL.Menu
{
    internal class MenuPrincipale_F
    {
        static public Menuprincipale_VM Create() => new Menuprincipale_VM(ListaOdl_F.Create(), Setting_F.Create());
    }
}
