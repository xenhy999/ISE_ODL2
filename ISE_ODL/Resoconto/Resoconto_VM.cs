using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISE_ODL.Intervallo.Durata;
using ISE_ODL.Odl;
using ISE_ODL.Resoconto.Giorno;

namespace ISE_ODL.Resoconto
{
    class Resoconto_VM : BaseBinding
    {
        public ObservableCollection<Giorno_VM> ListaDeiGiorni { get; set; } = new ObservableCollection<Giorno_VM>();
        private bool mostraCompletate;
        public bool MostraCompletate
        {
            get => mostraCompletate;
            set
            {
                mostraCompletate = value;
                CreaGiorni();
            }
        }
        public void CreaGiorni()
        {
            ListaDeiGiorni.Clear();
            IEnumerable<Odl_VM> odlAttivi;
            if (ObjContainer.Menuprincipale_VM != null)
            {
                if (MostraCompletate) odlAttivi = ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Where(odl => odl is Odl_VM).Cast<Odl_VM>();
                else odlAttivi = ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Where(odl => odl.Completata == false && odl is Odl_VM).Cast<Odl_VM>();
                List<DateOnly> tuttiGiorni = odlAttivi.Select(o => o.Durate).SelectMany(x => x).Select(d => d.Data).Distinct().ToList();
                foreach (DateOnly g in tuttiGiorni)
                {
                    Giorno_VM giorno = Giorno_F.Create(g);
                    foreach (Odl_VM odl_VM in odlAttivi)
                    {
                        if (odl_VM.AttivatoIl(g, out TimeSpan durata))
                            giorno.OdlLavorati.Add(odl_VM, durata);
                    }
                    ListaDeiGiorni.Add(giorno);
                }
            }
        }
    }
}
