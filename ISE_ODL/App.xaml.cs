using System.Configuration;
using System.Data;
using System.Windows;

namespace ISE_ODL
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MenuPrincipale_V menuPrincipale_V = new MenuPrincipale_V { DataContext = BaseClasse.MenuPrincipale_VM };
            menuPrincipale_V.Show();
        }
    }

}
