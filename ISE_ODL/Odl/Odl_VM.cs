using System.Collections.ObjectModel;

namespace ISE_ODL.Odl
{
    /*internal*/
    public class Odl_VM : NessunoOdl
    {
        public Odl_M Odl_M { get; private set; }

        private ObservableCollection<DateTime> orariInizio = [];
        private ObservableCollection<DateTime> orariFine = [];
        private ObservableCollection<TimeSpan> durataOrari = [];
        public ObservableCollection<DateTime> OrariInizio { get => Odl_M.OrariInizio; set => Odl_M.OrariInizio = value; }
        public ObservableCollection<DateTime> OrariFine { get => Odl_M.OrariFine; set => Odl_M.OrariFine = value; }
        //public ObservableCollection<TimeSpan> DurataOrari { get => Odl_M.DurataOrari; set => Odl_M.DurataOrari = value; }
        public ObservableCollection<string> DurataOrari { get => Odl_M.DurataOrari; set => Odl_M.DurataOrari = value; }

        public DateTime OrarioUltimoOdlIniziato;
        private bool mostraAltro;

        public bool OdlInModifica { get; set; }
        public bool MostraAltro
        {
            get => mostraAltro;
            set
            {
                mostraAltro = value;
                OnPropertyChanged(nameof(MostraAltro));
            }
        }
        public AggiungiOdl AggiungiOdl { get; set; }
        public AggiornaOdl AggiornaOdl { get; set; }
        public string Id { get => Odl_M.Id; set => Odl_M.Id = value; }
        public string Cliente
        {
            get => Odl_M.Cliente;
            set
            {
                Odl_M.Cliente = value;
                AggiungiOdl.OnRaiseCanExecuteChanged();
                AggiornaOdl.OnRaiseCanExecuteChanged();
            }
        }
        public string Attività { get => Odl_M.Attività; set => Odl_M.Attività = value; }
        public bool Completata { get => Odl_M.Completata; set => Odl_M.Completata = value; }
        public bool Stato
        {
            get => Odl_M.Stato;
            set
            {
                Odl_M.Stato = value;
                if (value)
                {
                    OrariInizio.Add(DateTime.Now);
                    OrarioUltimoOdlIniziato = DateTime.Now;
                    ObjContainer.MenuPrincipale_VM.OdlInEsecuzione = true;
                    OnPropertyChanged(nameof(Stato));
                }
                else
                {
                    OrariFine.Add(DateTime.Now);
                    DurataOrari.Add(
                        ((DateTime.Now.Subtract(OrarioUltimoOdlIniziato)).Hours).ToString()+" Ore e "+
                        ((DateTime.Now.Subtract(OrarioUltimoOdlIniziato)).Minutes).ToString()+" Minuti ");
                    ObjContainer.MenuPrincipale_VM.OdlInEsecuzione = false;
                    OnPropertyChanged(nameof(Stato));
                }
            }
        }
        public Odl_VM(Odl_M odl_M, AggiungiOdl aggiungiOdl, AggiornaOdl aggiornaOdl)
        {
            Odl_M = odl_M;
            AggiungiOdl = aggiungiOdl;
            AggiornaOdl = aggiornaOdl;
        }

        //public static explicit operator Odl_VM(Odl_M v) => Odl_F.CreateWithData(v.Id, v.Cliente, v.Note, v.Stato, v.OrariInizio, v.OrariFine, v.DurataOrari);
    }
}
