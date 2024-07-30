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
        public Intervallo_VM(Intervallo_M mode) => model = mode;
        public bool OrarioCompleto => model.OrarioCompleto;
        public DateTime OrarioInizio { get => model.OrarioInizio; set => model.OrarioInizio = value; }
        public DateTime OrarioFine
        {
            get => model.OrarioFine;
            set
            {
                model.OrarioFine = value;
                OnPropertyChanged(nameof(OrarioFine));
            }
        }

        public TimeSpan Durata => OrarioFine - OrarioInizio;
        public DateOnly Giorno { get=>model.Giorno; set=> model.Giorno=value; }
    }
}
