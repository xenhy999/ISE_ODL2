using System.IO;
using System.Windows;
using ISE_ODL.Intervallo;
using ISE_ODL.Odl;
using ISE_ODL.Resoconto.Giorno;
using Microsoft.Win32;
namespace ISE_ODL.Report
{
    /// <summary>
    /// La classe ReportOdl è responsabile della generazione e salvataggio di un report
    /// basato sui dati Odl e Giorno dal ViewModel dell'applicazione.
    /// Deriva da BaseCommand.
    /// </summary>
    public class ReportOdl : BaseCommand
    {
        /// <summary>
        /// Esegue il comando per generare e salvare il report in .csv o .txt.
        /// </summary>
        /// <param name="parameter">Il parametro del comando.</param>
        public override void Execute(object parameter)
        {
            List<string> CreaFileTxt()
            {
                List<string> ReportFinale = [];
                foreach (Odl_M Odl_M in ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Where(c => c is Odl_VM).Select(cvm => cvm.Model).ToList().Cast<Odl_M>())
                {
                    ReportFinale.Add( "Odl: " + Odl_M.OdlId + " Attività: " + Odl_M.Attivita+Environment.NewLine);
                    foreach (Intervallo_M intervallo_M in Odl_M.Intervalli)
                    {
                        ReportFinale.Add(intervallo_M.Giorno.ToString("d") + " " + intervallo_M.OrarioInizio.ToString("t") + " " + intervallo_M.OrarioFine.ToString("t"));
                    }
                    ReportFinale.Add(Environment.NewLine);
                }
                ObjContainer.Menuprincipale_VM.Resoconto_VM.CreaGiorni();
                foreach (Giorno_VM giorno_VM in ObjContainer.Menuprincipale_VM.Resoconto_VM.ListaDeiGiorni)
                {
                    ReportFinale.Add("Giorno " + giorno_VM.Data);
                    foreach (KeyValuePair<Odl_VM, TimeSpan> a in giorno_VM.OdlLavorati)
                    {
                        ReportFinale.Add("Odl: " + a.Key.Id + " Durata: " + a.Value.ToString().Remove(5));
                    }
                    ReportFinale.Add(Environment.NewLine);
                }
                return ReportFinale;
            }
            List<string> CreaFileCsv()
            {
                List<string> ReportFinale = [];
                foreach (Odl_M Odl_M in ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Where(c => c is Odl_VM).Select(cvm => cvm.Model).ToList().Cast<Odl_M>())
                {
                    ReportFinale.Add("Lista ODL" + Environment.NewLine);
                    ReportFinale.Add("ODL;Attività");
                    ReportFinale.Add(Odl_M.OdlId + ";" + Odl_M.Attivita + Environment.NewLine);
                    ReportFinale.Add("Giorno;Inizio;Fine");
                    foreach (Intervallo_M intervallo_M in Odl_M.Intervalli)
                    {
                        ReportFinale.Add(intervallo_M.Giorno.ToString("d") + ";" + intervallo_M.OrarioInizio.ToString("t") + ";" + intervallo_M.OrarioFine.ToString("t"));
                    }

                    ReportFinale.Add(Environment.NewLine);
                }
                ReportFinale.Add("Lista giorni" + Environment.NewLine);
                ObjContainer.Menuprincipale_VM.Resoconto_VM.CreaGiorni();
                foreach (Giorno_VM giorno_VM in ObjContainer.Menuprincipale_VM.Resoconto_VM.ListaDeiGiorni)
                {
                    ReportFinale.Add("Giorno");
                    ReportFinale.Add(giorno_VM.Data.ToString() + Environment.NewLine);
                    ReportFinale.Add("ODL;Durata");
                    foreach (KeyValuePair<Odl_VM, TimeSpan> keyValuePair in giorno_VM.OdlLavorati)
                    {
                        ReportFinale.Add(keyValuePair.Key.Id + ";" + keyValuePair.Value.ToString().Remove(5));
                    }
                }
                return ReportFinale;
            }
            SaveFileDialog Esplora = new()
            {
                Filter = "Text (*.txt)|*.txt|Csv (*.csv)|*.csv",
                InitialDirectory = @"C:\",
                FilterIndex = 1
            };
            try
            {
                Esplora.ShowDialog();
                File.WriteAllLines(Esplora.FileName, Esplora.FileName.Last() == 't' ? CreaFileTxt() : CreaFileCsv());
                MessageBox.Show("Report creato con successo", "Report", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Errore nella creazione del report: non hai selezionato un file", "Report", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}