using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISE_ODL.Intervallo;

namespace ISE_ODL.Odl
{
    public class BaseOdl_VM: BaseBinding
    {
        private BaseOdl_M Model { get; set; }

        public ObservableCollection<Intervallo_VM> Intervalli { get; set; } = new ObservableCollection<Intervallo_VM>();

        public BaseOdl_VM(BaseOdl_M nessunoOdl_M)
        {
            Model = nessunoOdl_M;
        }

        public string Attivita { get => Model.Attivita; set => Model.Attivita = value; }
        public bool Stato
        {
            get => Model.Stato;
            set
            {
                if (Model.Stato == value)
                    return;

                Model.Stato = value;
                OnPropertyChanged(nameof(Stato));

                if (value)
                    Intervalli.Add(Intertevallo_F.StartNew());
                else
                {
                    Intervallo_M? m = Intervalli.LastOrDefault()?.EndThis();
                    Model.Intervalli.Add(m);
                }
            }
        }

    }
}
