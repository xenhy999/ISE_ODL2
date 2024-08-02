using ISE_ODL.Menu;
using ISE_ODL.Odl;
namespace ISE_ODL
{
    internal static class ObjContainer
    {
        public static Menuprincipale_VM Menuprincipale_VM { get; set; }
        public static OdlTimer OdlTimer { get; set; }
        public static void Init()
        {
            Menuprincipale_VM = MenuPrincipale_F.Create();
            OdlTimer = new();
        }
    }
}
