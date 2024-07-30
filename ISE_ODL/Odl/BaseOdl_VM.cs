using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using ISE_ODL.Intervallo;
using ISE_ODL.Intervallo.Durata;

namespace ISE_ODL.Odl
{
    public class BaseOdl_VM : BaseBinding
    {
        protected readonly BaseOdl_M _model;
        private readonly List<Durata_VM> durate;

        public BaseOdl_M Model => _model;
        public BaseOdl_VM(BaseOdl_M nessunoOdl_M)
        {
            _model = nessunoOdl_M;
            OrarioVisibile = false;
        }

        public List<Intervallo_VM> Intervalli
        {
            get
            {
                // La lista viene ricreata ogi volta a partire da quella del model
                List<Intervallo_VM> Out = [];
                foreach (Intervallo_M i in Model.Intervalli)
                    Out.Add(Intertevallo_F.Create(i));
                if (Out.Count!=0) OrarioVisibile = true;
                OnPropertyChanged(nameof(OrarioVisibile));
                return Out;
            }
        }
        public ObservableCollection<Durata_VM> Durate
        {
            get
            {
                IEnumerable<DateOnly> GiorniAttivita = Intervalli.Select(i => i.Giorno).Distinct();
                ObservableCollection<Durata_VM> Out = [];
                foreach (DateOnly g in GiorniAttivita)
                {
                    IEnumerable<TimeSpan> OreGiornaliere = Intervalli.Where(c => c.Giorno == g).Select(b=> b.Durata);
                    TimeSpan totalSpan = new TimeSpan(OreGiornaliere.Sum(r => r.Ticks));
                    Out.Add(Durata_F.Create(g, totalSpan));
                }
                return Out;
            }
        }

        public string Attivita { get => _model.Attivita; set => _model.Attivita = value; }
        public bool Stato
        {
            get => _model.Stato;
            set
            {
                if (_model.Stato == value) 
                    return;

                _model.Stato = value;
                OrarioVisibile=true;
                OnPropertyChanged(nameof(Stato));
                OnPropertyChanged(nameof(Intervalli));
                OnPropertyChanged(nameof(OrarioVisibile));
            }
        }
        public bool OrarioVisibile { get; set; }

    }
}
