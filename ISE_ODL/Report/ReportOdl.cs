using System.IO;
using System.Windows;
using ISE_ODL.Intervallo;
using ISE_ODL.Odl;
using ISE_ODL.Resoconto.Giorno;
using Microsoft.Win32;
namespace ISE_ODL.Report
{
    public class ReportOdl : BaseCommand
    {
        private static readonly string fileName = @$"{AppDomain.CurrentDomain.BaseDirectory}\Report_Commisioni.txt";
        private static readonly string fileNamePdf = @$"{AppDomain.CurrentDomain.BaseDirectory}\Report_Commisioni.pdf";
        public override void Execute(object parameter)
        {
            List<string> ReportFinale = [];
            int cont = 0;
            foreach (Odl_M Odl_M in ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Where(c => c is Odl_VM).Select(cvm => cvm.Model).ToList().Cast<Odl_M>())
            {
                string SingolaOdl = ++cont + ") Odl: " + Odl_M.OdlId + " Attività: " + Odl_M.Attivita + Environment.NewLine;
                foreach (Intervallo_M intervallo_M in Odl_M.Intervalli)
                    SingolaOdl += intervallo_M.Giorno.ToString("d") + " " + intervallo_M.OrarioInizio.ToString("t") + " " + intervallo_M.OrarioFine.ToString("t") + Environment.NewLine;
                ReportFinale.Add(SingolaOdl);
            }
            ObjContainer.Menuprincipale_VM.Resoconto_VM.CreaGiorni();
            foreach (Giorno_VM giorno_VM in ObjContainer.Menuprincipale_VM.Resoconto_VM.ListaDeiGiorni)
            {
                string SingoloGiorno = "Giorno " + giorno_VM.Data + Environment.NewLine;
                foreach (KeyValuePair<Odl_VM, TimeSpan> a in giorno_VM.OdlLavorati)
                {
                    SingoloGiorno += "Odl: " + a.Key.Id + " Durata: " + a.Value.ToString().Remove(5);
                    ReportFinale.Add(SingoloGiorno);
                }
            }



            //PrintDialog pDialog = new PrintDialog();
            //pDialog.PageRangeSelection = PageRangeSelection.AllPages;
            //pDialog.UserPageRangeEnabled = true;
            //pDialog.ShowDialog();

            //XpsDocument xpsDocument = new XpsDocument(fileNamePdf, FileAccess.ReadWrite);
            //FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();
            //pDialog.PrintDocument(fixedDocSeq.DocumentPaginator, "Test print job");
            SaveFileDialog Esplora = new()
            {
                Filter = "Text (*.txt)|*.txt",
                InitialDirectory = @"C:\",
                FilterIndex = 1
            };
            Esplora.ShowDialog();
            string FileName = Esplora.FileName;
            File.WriteAllLines(FileName, ReportFinale);
            //FluentConverter.Load(FileName).ConvertTo(fileNamePdf).Convert();
            MessageBox.Show("Report creato con successo", "Report", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}