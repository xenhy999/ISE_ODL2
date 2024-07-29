using System.Collections.ObjectModel;

namespace ISE_ODL.Odl
{
    /*internal*/
    public class Odl_VM : BaseOdl_VM
    {
        private  Odl_M model;
        public Odl_M Model
        {
            get => model;
            set => model = value;
        }

        private bool mostraAltro;
        private bool filtro;

        public Odl_VM(Odl_M odl_M, AggiungiOdl aggiungiOdl, AggiornaOdl aggiornaOdl,BaseOdl_M nessunoOdl_M) : base(nessunoOdl_M)
        {
            model = odl_M;
            AggiungiOdl = aggiungiOdl;
            AggiornaOdl = aggiornaOdl;
            Filtro = false;
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
        public bool Completata
        {
            get => model.Completata;
            set
            {
                model.Completata = value;
                OnPropertyChanged(nameof(Completata));
                if (!Completata || (Completata&&ObjContainer.MenuPrincipale_VM.MostraCompletati)) Filtro = false;
                else Filtro = true;
                OnPropertyChanged(nameof(Filtro));
            }
        }
        public bool Filtro
        {
            get
            {
                return filtro;
            }

            set
            {
                filtro = value;
                OnPropertyChanged(nameof(Filtro));
            }
        }


        //public Odl_VM(Odl_M odl_M, AggiungiOdl aggiungiOdl, AggiornaOdl aggiornaOdl):
        //{
        //    Odl_M = odl_M;
        //    AggiungiOdl = aggiungiOdl;
        //    AggiornaOdl = aggiornaOdl;
        //}

        //public static explicit operator Odl_VM(Odl_M v) => Odl_F.CreateWithData(v.Id, v.Cliente, v.Note, v.Stato, v.OrariInizio, v.OrariFine, v.DurataOrari);
    }
}
