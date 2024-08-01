using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISE_ODL.Odl;

namespace ISE_ODL.Resoconto.Giorno
{
    internal class Giorno_VM:BaseBinding
    {
        public Giorno_VM(DateOnly data)
        {
            Data = data;
           
        }

        public DateOnly Data { get; set; }
        
        public Dictionary<Odl_VM, TimeSpan> OdlLavorati { get; set; } = new Dictionary<Odl_VM, TimeSpan>();
    }
}
