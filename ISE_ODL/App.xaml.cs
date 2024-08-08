using System.Windows;
using ISE_ODL.Odl;
using MongoDB.Bson;
using MongoDB.Driver;
namespace ISE_ODL
{
    public partial class App : Application
    {
        /// <summary>
        /// Gestisce l'evento di avvio dell'applicazione.
        /// Inizializza l'oggetto ObjContainer, carica i dati dal database,
        /// e visualizza la finestra principale dell'applicazione.
        /// </summary>
        /// <param name="sender">L'oggetto che ha generato l'evento.</param>
        /// <param name="e">Gli argomenti dell'evento di avvio.</param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ObjContainer.Init();
            LoadFromDataBase();
            MenuPrincipale_V menuPrincipale_V = new MenuPrincipale_V { DataContext = ObjContainer.Menuprincipale_VM };
            menuPrincipale_V.Show();
        }
        /// <summary>
        /// Carica i dati dal database MongoDB e popola la lista delle commisioni
        /// nell'oggetto Menuprincipale_VM.
        /// </summary>
        private void LoadFromDataBase()
        {
            List<Odl_M> ListaOdlDaDataBase = new MongoClient(ObjContainer.Menuprincipale_VM.Settings_VM.UriDatabase).GetDatabase("Odl").GetCollection<Odl_M>("odl").Find(new BsonDocument()).ToList();
            foreach (Odl_M OdlDaDataBase in ListaOdlDaDataBase)
                ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Add(Odl_F.Create(OdlDaDataBase));
        }
    }
}
