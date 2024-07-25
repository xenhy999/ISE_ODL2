using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_ODL.Odl
{
    public class BaseOdl_VM: BaseBinding
    {
        private BaseOdl_M Model { get; set; }

        private ObservableCollection<DateTime> orariInizio = [];
        private ObservableCollection<DateTime> orariFine = [];
        private ObservableCollection<TimeSpan> durataOrari = [];
        public ObservableCollection<DateTime> OrariInizio { get => Model.OrariInizio; set => Model.OrariInizio = value; }
        public ObservableCollection<DateTime> OrariFine { get => Model.OrariFine; set => Model.OrariFine = value; }
        //public ObservableCollection<TimeSpan> DurataOrari { get => Odl_M.DurataOrari; set => Odl_M.DurataOrari = value; }
        public ObservableCollection<string> DurataOrari { get => Model.DurataOrari; set => Model.DurataOrari = value; }

        public DateTime OrarioUltimoOdlIniziato;

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
                Model.Stato = value;
                if (value)
                {
                    OrariInizio.Add(DateTime.Now);
                    OrarioUltimoOdlIniziato = DateTime.Now;
                    OnPropertyChanged(nameof(Stato));
                }
                else
                {
                    OrariFine.Add(DateTime.Now);
                    DurataOrari.Add(
                        ((DateTime.Now.Subtract(OrarioUltimoOdlIniziato)).Hours).ToString() + " Ore e " +
                        ((DateTime.Now.Subtract(OrarioUltimoOdlIniziato)).Minutes).ToString() + " Minuti ");
                    OnPropertyChanged(nameof(Stato));
                }
            }
        }

    }
}
