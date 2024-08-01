using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISE_ODL.Odl;
using Windows.UI.WebUI;

namespace ISE_ODL.Resoconto.Giorno
{
    internal class Giorno_F
    {
        public static Giorno_VM Create(DateOnly date) => new Giorno_VM(date);

    }
}
