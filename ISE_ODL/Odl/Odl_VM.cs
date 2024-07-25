using System.Collections.ObjectModel;

namespace ISE_ODL.Odl
{
    /*internal*/
    public class Odl_VM : BaseOdl_VM
    {
        private readonly Odl_M model;
        public Odl_M Model => model;
        
        private bool mostraAltro;

        public Odl_VM(Odl_M odl_M, AggiungiOdl aggiungiOdl, AggiornaOdl aggiornaOdl,BaseOdl_M nessunoOdl_M) : base(nessunoOdl_M)
        {
            model = odl_M;
            AggiungiOdl = aggiungiOdl;
            AggiornaOdl = aggiornaOdl;
        }

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
        public string Id { get => model.Id; set => model.Id = value; }
        public string Cliente
        {
            get => model.Cliente;
            set
            {
                model.Cliente = value;
                AggiungiOdl.OnRaiseCanExecuteChanged();
                AggiornaOdl.OnRaiseCanExecuteChanged();
            }
        }
        //public string Attività { get => Odl_M.Attività; set => Odl_M.Attività = value; }
        public bool Completata { get => model.Completata; set => model.Completata = value; }
        
        //public Odl_VM(Odl_M odl_M, AggiungiOdl aggiungiOdl, AggiornaOdl aggiornaOdl):
        //{
        //    Odl_M = odl_M;
        //    AggiungiOdl = aggiungiOdl;
        //    AggiornaOdl = aggiornaOdl;
        //}

        //public static explicit operator Odl_VM(Odl_M v) => Odl_F.CreateWithData(v.Id, v.Cliente, v.Note, v.Stato, v.OrariInizio, v.OrariFine, v.DurataOrari);
    }
}
