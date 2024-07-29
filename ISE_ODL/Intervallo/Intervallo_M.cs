using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_ODL.Intervallo
{
    public class Intervallo_M
    {
        public bool OrarioCompleto { get; set; }
        public DateTime OrarioInizio { get; set; }
        public DateTime OrarioFine { get; set; }
        public void EndThis()
        {
            OrarioFine = DateTime.Now;
            OrarioCompleto = true;
        }
    }
}
