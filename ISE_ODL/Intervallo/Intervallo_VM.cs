using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_ODL.Intervallo
{
    public  class Intervallo_VM:BaseBinding
    {
        private Intervallo_M _model;

        public Intervallo_VM(Intervallo_M model)
        {
            _model = model;
        }

        public DateTime OrarioInizio { get => _model.OrarioInizio; set => _model.OrarioInizio = value; }
        public DateTime OrarioFine { get => _model.OrarioFine; set => _model.OrarioFine = value; }

        public Intervallo_M EndThis()
        {
            OrarioFine = DateTime.Now;
            return _model;
        }
    }
}
