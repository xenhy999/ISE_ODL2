using System.Text.Json;
using System.Windows;
using ISE_ODL.Odl;
using MongoDB.Bson;
using MongoDB.Driver;
namespace ISE_ODL
{
    public partial class MenuPrincipale_V : Window
    {
        public MenuPrincipale_V() => InitializeComponent();
        private void Button_Click(object sender, RoutedEventArgs e) => Close();
        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            foreach (BaseOdl_VM a in ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni)
                a.Stato = false;
            List<BaseOdl_M> OdlDaSerializzare = ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Where(c => c is Odl_VM).Select(cvm => cvm.Model).ToList();
            IMongoCollection<BsonDocument> collection = new MongoClient(ObjContainer.connectionUri).GetDatabase("Odl").GetCollection<BsonDocument>("odl");
            collection.Database.DropCollection("odl");
            foreach (BaseOdl_M odl in OdlDaSerializzare)
            {
                BsonDocument OdlSerializzataBson = BsonDocument.Parse(JsonSerializer.Serialize(odl, new JsonSerializerOptions { WriteIndented = true }));
                collection.InsertOne(OdlSerializzataBson);
            }
        }
    }
}