using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ISE_ODL.Odl
{
    /// <summary>
    /// Classe parziale per la vista Odl_V, che eredita da UserControl.
    /// Rappresenta la vista per Odl_VM.
    /// </summary>
    public partial class Odl_V : Window
    {
        /// <summary>
        /// Costruttore della classe Odl_V.
        /// Inizializza i componenti della vista.
        /// </summary>
        public Odl_V() => InitializeComponent();
        /// <summary>
        /// Gestisce il click del bottone per chiudere la finestra.
        /// </summary>
        /// <param name="sender">L'oggetto che ha generato l'evento.</param>
        /// <param name="e">Gli argomenti dell'evento di click.</param>
        private void Button_Click(object sender, RoutedEventArgs e) => Close();
    }
}
