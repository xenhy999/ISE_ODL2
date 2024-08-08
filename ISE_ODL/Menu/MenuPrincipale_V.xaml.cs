using System.Text.Json;
using System.Windows;
using ISE_ODL.Odl;
using MongoDB.Bson;
using MongoDB.Driver;
namespace ISE_ODL
{
    /// <summary>
    /// Classe parziale per la vista MenuPrincipale_V, che eredita da UserControl.
    /// Rappresenta la vista per MenuPrincipale_VM.
    /// </summary>
    public partial class MenuPrincipale_V : Window
    {
        /// <summary>
        /// Costruttore della classe MenuPrincipale_V.
        /// Inizializza i componenti della vista.
        /// </summary>
        public MenuPrincipale_V() => InitializeComponent();
        /// <summary>
        /// Gestisce il click del bottone per chiudere la finestra.
        /// </summary>
        /// <param name="sender">L'oggetto che ha generato l'evento.</param>
        /// <param name="e">Gli argomenti dell'evento di click.</param>
        private void Button_Click(object sender, RoutedEventArgs e) => Close();
        /// <summary>
        /// Gestisce la chiusura della finestra.
        /// Salva le impostazioni dell'applicazione, imposta lo stato di tutti gli ODL a false,
        /// serializza gli ODL e li salva nel database MongoDB.
        /// </summary>
        /// <param name="sender">L'oggetto che ha generato l'evento.</param>
        /// <param name="e">Gli argomenti dell'evento di chiusura.</param>
        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            foreach (BaseOdl_VM a in ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni)
                a.Stato = false;
            List<BaseOdl_M> OdlDaSerializzare = ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Where(c => c is Odl_VM).Select(cvm => cvm.Model).ToList();
            IMongoCollection<BsonDocument> collection = new MongoClient(ObjContainer.Menuprincipale_VM.Settings_VM.UriDatabase).GetDatabase("Odl").GetCollection<BsonDocument>("odl");
            collection.Database.DropCollection("odl");
            foreach (BaseOdl_M odl in OdlDaSerializzare)
            {
                BsonDocument OdlSerializzataBson = BsonDocument.Parse(JsonSerializer.Serialize(odl, new JsonSerializerOptions { WriteIndented = true }));
                collection.InsertOne(OdlSerializzataBson);
            }
        }
    }
}