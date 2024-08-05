using System.ComponentModel;
using System.IO;
using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Windows;
using ISE_ODL.Odl;
using Windows.Media.Protection.PlayReady;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;
namespace ISE_ODL
{
    public partial class MenuPrincipale_V : Window
    {
        public static readonly string fileName = @$"{AppDomain.CurrentDomain.BaseDirectory}\Commisioni.json";
        const string connectionUri = "mongodb+srv://veronesimatteo2007:6CoPE4CbN6sOgVC0@iseodl.bbf2tvm.mongodb.net/?retryWrites=true&w=majority&appName=IseODL";
        public MenuPrincipale_V() => InitializeComponent();
        private void Button_Click(object sender, RoutedEventArgs e) => Close();
        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            foreach (BaseOdl_VM a in ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni)
            {
                a.Stato = false;
            }
            //File.WriteAllText(fileName, OdlSerializzate);
            List<BaseOdl_M> OdlDaSerializzare = ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Where(c => c is Odl_VM).Select(cvm => cvm.Model).ToList();
            JsonSerializerOptions? option = new JsonSerializerOptions { WriteIndented = true };
            string OdlSerializzate = JsonSerializer.Serialize(OdlDaSerializzare, option);
            MongoClient client = new MongoClient(connectionUri);
            IMongoCollection<BsonDocument> collection = client.GetDatabase("Odl").GetCollection<BsonDocument>("odl");
            collection.Database.DropCollection("odl");
            foreach (BaseOdl_M odl in OdlDaSerializzare)
            {
                string OdlSerializzata = JsonSerializer.Serialize(odl, option);
                BsonDocument OdlSerializzataBson = BsonDocument.Parse(OdlSerializzata);
                collection.InsertOne(OdlSerializzataBson);
            }
        }
    }
}