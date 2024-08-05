using System.IO;
using System.Text.Json;
using System.Windows;
using ISE_ODL.Odl;
using MongoDB.Bson;
using MongoDB.Driver;
using Windows.System;
namespace ISE_ODL
{
    public partial class App : Application
    {
        private const string connectionUri = "mongodb+srv://veronesimatteo2007:6CoPE4CbN6sOgVC0@iseodl.bbf2tvm.mongodb.net/?retryWrites=true&w=majority&appName=IseODL";
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ObjContainer.Init();
            if (File.Exists(MenuPrincipale_V.fileName)) LoadFromFile();
            MenuPrincipale_V menuPrincipale_V = new MenuPrincipale_V { DataContext = ObjContainer.Menuprincipale_VM };
            menuPrincipale_V.Show();
        }
        private void LoadFromFile()
        {
            MongoClient client = new MongoClient(connectionUri);
            IMongoCollection<Odl_M> collection = client.GetDatabase("Odl").GetCollection<Odl_M>("odl");
            List<Odl_M> odl_Ms = collection.Find(new BsonDocument()).ToList();
            foreach (Odl_M odl_M in odl_Ms)
                ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Add(Odl_F.Create(odl_M));
        }
    }
}
