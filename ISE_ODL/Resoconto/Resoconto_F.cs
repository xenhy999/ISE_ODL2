using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISE_ODL.Intervallo;
using ISE_ODL.Intervallo.Durata;
using ISE_ODL.Resoconto.Giorno;
using Windows.Security.ExchangeActiveSyncProvisioning;

namespace ISE_ODL.Resoconto
{
    internal static class Resoconto_F
    {
        public static Resoconto_VM Create() => new();
    }
}
