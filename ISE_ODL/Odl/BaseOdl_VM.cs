using System.Collections.ObjectModel;
using ISE_ODL.Intervallo;
using ISE_ODL.Intervallo.Durata;
namespace ISE_ODL.Odl
{
    public class BaseOdl_VM : BaseBinding
    {
        protected readonly BaseOdl_M model;
        public BaseOdl_M Model => model;
        public string Attivita { get => model.Attivita; set => model.Attivita = value; }
        public BaseOdl_VM(BaseOdl_M nessunoOdl_M)
        {
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
        public bool Stato
        {
            get => model.Stato;
            set
            {
                ObjContainer.OdlTimer?.ResetTimer();
                if (model.Stato == value) return;
                model.Stato = value;
                OrarioVisibile=true;
                if (!value)
                {
                    // Quando spengo un odl controllo la sua durata minima
                    Intervallo_VM? UltimoIntervallo = Intervalli.LastOrDefault();
                    if (UltimoIntervallo.Durata < ObjContainer.Menuprincipale_VM.Settings_VM.DurataMinimaOdl)
                        EliminaIntervallo.Elimina(this, UltimoIntervallo.Model);
                }

                OnPropertyChanged(nameof(Stato));
                OnPropertyChanged(nameof(Intervalli));
                OnPropertyChanged(nameof(Durate));
                OnPropertyChanged(nameof(OrarioVisibile));
            }
        }
    }
}
