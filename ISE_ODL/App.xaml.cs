using System.Windows;
using ISE_ODL.Odl;
using MongoDB.Bson;
using MongoDB.Driver;
namespace ISE_ODL
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ObjContainer.Init();
            LoadFromDataBase();
            MenuPrincipale_V menuPrincipale_V = new MenuPrincipale_V { DataContext = ObjContainer.Menuprincipale_VM };
            menuPrincipale_V.Show();
        }
        private void LoadFromDataBase()
        {
            List<Odl_M> ListaOdlDaDataBase = new MongoClient(ObjContainer.connectionUri).GetDatabase("Odl").GetCollection<Odl_M>("odl").Find(new BsonDocument()).ToList();
            foreach (Odl_M OdlDaDataBase in ListaOdlDaDataBase)
                ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Add(Odl_F.Create(OdlDaDataBase));
        }
    }
}
