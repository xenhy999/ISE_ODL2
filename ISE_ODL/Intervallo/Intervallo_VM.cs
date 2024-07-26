using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ISE_ODL.Intervallo
{
    public  class Intervallo_VM : BaseBinding
    {
        private readonly Intervallo_M _model;

        public Intervallo_VM(Intervallo_M model)
        {
            _model = model;
        }

        public bool OrarioCompleto { get; private set; } = false;
        public DateTime OrarioInizio => _model.OrarioInizio;
        public DateTime OrarioFine
        {
            get => _model.OrarioFine;
            private set
            {
                _model.OrarioFine = value;
                OnPropertyChanged(nameof(OrarioFine));
            }
        }

        public Intervallo_M EndThis()
        {
            OrarioFine = DateTime.Now;
            OrarioCompleto = true;
            OnPropertyChanged(nameof(OrarioCompleto));
            return _model;
        }
    }
}
