using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using ISE_ODL.Intervallo;

namespace ISE_ODL.Odl
{
    //[JsonDerivedType(typeof(BaseOdl_M), typeDiscriminator: "Base")]
    //[JsonDerivedType(typeof(Odl_M), typeDiscriminator: "Odl_M")]
    public class BaseOdl_M
    {
        public BaseOdl_M()
        {
            Intervalli = new List<Intervallo_M>();
        }

        public string Attivita { get; set; }
        public bool Stato { get; set; }
        public List<Intervallo_M> Intervalli { get; set; }
    }
}
