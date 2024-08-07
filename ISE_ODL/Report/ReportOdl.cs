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
        private static readonly string fileName = @$"{AppDomain.CurrentDomain.BaseDirectory}\Report_Commisioni.txt";
        private static readonly string fileNamePdf = @$"{AppDomain.CurrentDomain.BaseDirectory}\Report_Commisioni.pdf";
        /// <summary>
        /// Esegue il comando per generare e salvare il report.
        /// </summary>
        /// <param name="parameter">Il parametro del comando.</param>
        public override void Execute(object parameter)
        {
            // Lista per memorizzare le righe del report finale
            List<string> ReportFinale = [];
            int cont = 0;
            // Itera attraverso la lista degli oggetti Odl_M, filtrando e castando come necessario
            foreach (Odl_M Odl_M in ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Where(c => c is Odl_VM).Select(cvm => cvm.Model).ToList().Cast<Odl_M>())
            {
                // Costruisce una stringa per ogni oggetto Odl_M, includendo i dettagli e gli intervalli
                string SingolaOdl = ++cont + ") Odl: " + Odl_M.OdlId + " Attività: " + Odl_M.Attivita + Environment.NewLine;
                foreach (Intervallo_M intervallo_M in Odl_M.Intervalli)
                    SingolaOdl += intervallo_M.Giorno.ToString("d") + " " + intervallo_M.OrarioInizio.ToString("t") + " " + intervallo_M.OrarioFine.ToString("t") + Environment.NewLine;
                ReportFinale.Add(SingolaOdl);
            }
            // Crea la lista dei giorni usando il metodo del ViewModel Resoconto
            ObjContainer.Menuprincipale_VM.Resoconto_VM.CreaGiorni();
            // Itera attraverso la lista degli oggetti Giorno_VM
            foreach (Giorno_VM giorno_VM in ObjContainer.Menuprincipale_VM.Resoconto_VM.ListaDeiGiorni)
            {
                // Costruisce una stringa per ogni oggetto Giorno_VM, includendo i dettagli degli OdlLavorati
                string SingoloGiorno = "Giorno " + giorno_VM.Data + Environment.NewLine;
                foreach (KeyValuePair<Odl_VM, TimeSpan> a in giorno_VM.OdlLavorati)
                {
                    SingoloGiorno += "Odl: " + a.Key.Id + " Durata: " + a.Value.ToString().Remove(5);
                    ReportFinale.Add(SingoloGiorno);
                }
            }
            // Configura il SaveFileDialog per salvare il report
            SaveFileDialog Esplora = new()
            {
                Filter = "Text (*.txt)|*.txt",
                InitialDirectory = @"C:\",
                FilterIndex = 1
            };
            try
            {
                // Mostra la finestra di dialogo per il salvataggio del file e ottiene il nome del file selezionato
                Esplora.ShowDialog();
                string FileName = Esplora.FileName;
                File.WriteAllLines(FileName, ReportFinale);
                MessageBox.Show("Report creato con successo", "Report", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (System.ArgumentException)
            {
                // Gestisce l'eccezione se non è stato selezionato un file
                MessageBox.Show("Errore nella creazione del report: non hai selezionato un file", "Report", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}