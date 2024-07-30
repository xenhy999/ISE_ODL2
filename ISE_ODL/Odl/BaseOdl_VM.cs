using System.Collections.ObjectModel;
using System.Timers;
using System.Windows;
using ISE_ODL.Intervallo;
using ISE_ODL.Intervallo.Durata;
using Timer = System.Timers.Timer;
namespace ISE_ODL.Odl
{
    public class BaseOdl_VM : BaseBinding
    {
        protected readonly BaseOdl_M model;
        public BaseOdl_M Model => model;
        public OdlTimer OdlTimer { get; set; }
        public BaseOdl_VM(BaseOdl_M nessunoOdl_M)
        {
            OdlTimer = new();
            EliminaIntervallo = new();
            model = nessunoOdl_M;
        }
        public EliminaIntervallo EliminaIntervallo { get; set; }
        public ObservableCollection<Intervallo_VM> Intervalli
        {
            get
            {
                // La lista viene ricreata ogi volta a partire da quella del model
                ObservableCollection<Intervallo_VM> Out = [];
                foreach (Intervallo_M i in Model.Intervalli)
                    Out.Add(Intertevallo_F.Create(i, this));
                OrarioVisibile = Out.Count!=0;
                OnPropertyChanged(nameof(OrarioVisibile));
                return Out;
            }
        }
        public ObservableCollection<Durata_VM> Durate
        {
            get
            {
                ObservableCollection<Durata_VM> Out = [];
                foreach (DateOnly g in Intervalli.Select(i => i.Giorno).Distinct())
                {
                    Out.Add(Durata_F.Create(g, new TimeSpan(Intervalli.Where(c => c.Giorno == g).Select(b => b.Durata).Sum(r => r.Ticks))));
                }
                return Out;
            }
        }
        public bool OrarioVisibile { get; set; }
        public string Attivita { get => model.Attivita; set => model.Attivita = value; }
        public bool Stato
        {
            get => model.Stato;
            set
            {
                if ( value)
                {
                    OdlTimer.timer.Start();
                    OdlTimer.timer.Elapsed += OdlTimer.Time_Elapsed;
                }
                else OdlTimer.timer.Stop();
                if (model.Stato == value) return;
                model.Stato = value;
                OrarioVisibile=true;
                OnPropertyChanged(nameof(Stato));
                OnPropertyChanged(nameof(Intervalli));
                OnPropertyChanged(nameof(Durate));
                OnPropertyChanged(nameof(OrarioVisibile));
            }
        }
    }
}
