using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace ISE_ODL.Odl
{
    public class Odl_M : BaseOdl_M
    {
        public string Id { get; set; }
        public string Cliente { get; set; }
        public bool Completata { get; set; }
    }
}
