using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISE_ODL.Intervallo;

namespace ISE_ODL.Odl
{
    public class BaseOdl_VM : BaseBinding
    {
        protected readonly BaseOdl_M _model;

        public BaseOdl_M Model => _model;

        public BaseOdl_VM(BaseOdl_M nessunoOdl_M) => _model = nessunoOdl_M;

        public List<Intervallo_VM> Intervalli
        {
            get
            {
                // La lista viene ricreata ogi volta a partire da quella del model
                List<Intervallo_VM> Out = [];
                foreach (Intervallo_M i in Model.Intervalli)
                    Out.Add(Intertevallo_F.Create(i));
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
                OnPropertyChanged(nameof(Stato));
                OnPropertyChanged(nameof(Intervalli));
            }
        }
    }
}
