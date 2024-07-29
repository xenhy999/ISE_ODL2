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
        private readonly Intervallo_M model;

        public Intervallo_VM(Intervallo_M model)
        {
            this.model = model;
        }

        public bool OrarioCompleto { get; private set; } = false;
        public DateTime OrarioInizio
        {
            get => model.OrarioInizio;
            set => model.OrarioInizio = value;
        }

        public DateTime OrarioFine
        {
            get => model.OrarioFine;
            set
            {
                model.OrarioFine = value;
                OnPropertyChanged(nameof(OrarioFine));
            }
        }

        public Intervallo_M EndThis()
        {
            OrarioFine = DateTime.Now;
            OrarioCompleto = true;
            OnPropertyChanged(nameof(OrarioCompleto));
            return model;
        }
    }
}
