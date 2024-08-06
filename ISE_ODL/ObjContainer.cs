using ISE_ODL.Menu;
using ISE_ODL.Odl;
namespace ISE_ODL
{
    internal static class ObjContainer
    {
        public static Menuprincipale_VM Menuprincipale_VM { get; set; }
        public static OdlTimer OdlTimer { get; set; }
        public const string connectionUri = "mongodb+srv://veronesimatteo2007:6CoPE4CbN6sOgVC0@iseodl.bbf2tvm.mongodb.net/?retryWrites=true&w=majority&appName=IseODL";
        public static void Init()
        {
            Menuprincipale_VM = MenuPrincipale_F.Create();
            OdlTimer = new();
        }
    }
}
