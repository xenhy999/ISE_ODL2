using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISE_ODL.Intervallo;
using ISE_ODL.Odl;

namespace ISE_ODL.Report
{
    public class ReportOdl : BaseCommand
    { 

        private static readonly string fileName = @$"{AppDomain.CurrentDomain.BaseDirectory}\Report_Commisioni.txt";
        public override void Execute(object parameter)
        {
             List<string> ListaOdl=new();
             int cont = 0;
            foreach (Odl_M Odl_M in ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Where(c => c is Odl_VM).Select(cvm => cvm.Model).ToList())
            {
                cont++;
                string SingolaOdl = cont + ") Odl: " + Odl_M.OdlId + " Attività: " + Odl_M.Attivita + Environment.NewLine;
                foreach (Intervallo_M  intervallo_M in Odl_M.Intervalli)
                {
                    SingolaOdl += intervallo_M.Giorno.ToString("d") + " " + intervallo_M.OrarioInizio.ToString("t") + " " + intervallo_M.OrarioFine.ToString("t") + Environment.NewLine;
                }
                ListaOdl.Add(SingolaOdl);
            }
            File.WriteAllLines (fileName, ListaOdl);
        }
    }
}
