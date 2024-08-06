using System.IO;
using System.Windows;
using ISE_ODL.Intervallo;
using ISE_ODL.Odl;
using Document = Aspose.Words.Document;
namespace ISE_ODL.Report
{
    public class ReportOdl : BaseCommand
    {

        private static readonly string fileName = @$"{AppDomain.CurrentDomain.BaseDirectory}\Report_Commisioni.txt";
        private static readonly string fileNamePdf = @$"{AppDomain.CurrentDomain.BaseDirectory}\Report_Commisioni.pdf";
        public override void Execute(object parameter)
        {
            List<string> ListaOdl = [];
            int cont = 0;
            foreach (Odl_M Odl_M in ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Where(c => c is Odl_VM).Select(cvm => cvm.Model).ToList().Cast<Odl_M>())
            {
                string SingolaOdl = ++cont + ") Odl: " + Odl_M.OdlId + " Attività: " + Odl_M.Attivita + Environment.NewLine;
                foreach (Intervallo_M intervallo_M in Odl_M.Intervalli)
                    SingolaOdl += intervallo_M.Giorno.ToString("d") + " " + intervallo_M.OrarioInizio.ToString("t") + " " + intervallo_M.OrarioFine.ToString("t") + Environment.NewLine;
                ListaOdl.Add(SingolaOdl);
            }
            File.WriteAllLines(fileName, ListaOdl);
            Document doc = new(fileName);
            doc.Save(fileNamePdf);
            MessageBox.Show("Report creato con successo", "Report", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
