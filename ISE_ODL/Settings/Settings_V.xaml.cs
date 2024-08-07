using System.Windows;
using System.Windows.Controls;

namespace ISE_ODL.Settings
{
    /// <summary>
    /// Classe parziale per la vista Settings_V, che eredita da UserControl.
    /// Rappresenta la vista per Settings_VM.
    /// </summary>
    public partial class Settings_V : UserControl
    {
        /// <summary>
        /// Costruttore della classe ListaOdl_V.
        /// Inizializza i componenti della vista.
        /// </summary>
        public Settings_V()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Gestisce il click del bottone per impostare la durata minima dell'ODL.
        /// </summary>
        /// <param name="sender">L'oggetto che ha generato l'evento.</param>
        /// <param name="e">Gli argomenti dell'evento di click.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ObjContainer.Menuprincipale_VM.Settings_VM.DurataMinimaOdl = new TimeSpan(0, 5, 0);
        }
        /// <summary>
        /// Gestisce il click del bottone per impostare la durata del timer.
        /// </summary>
        /// <param name="sender">L'oggetto che ha generato l'evento.</param>
        /// <param name="e">Gli argomenti dell'evento di click.</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ObjContainer.Menuprincipale_VM.Settings_VM.DurataDelTimer = new TimeSpan(1, 0, 0);
        }
        /// <summary>
        /// Gestisce il click del bottone per impostare l'intervallo in modifica.
        /// </summary>
        /// <param name="sender">L'oggetto che ha generato l'evento.</param>
        /// <param name="e">Gli argomenti dell'evento di click.</param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ObjContainer.Menuprincipale_VM.Settings_VM.IntervalloInModifica = new TimeSpan(0, 10, 0);
        }
    }
}
