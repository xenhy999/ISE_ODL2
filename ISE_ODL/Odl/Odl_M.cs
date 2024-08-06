using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ISE_ODL.Odl
{
    public class Odl_M : BaseOdl_M
    {
        public Object _id { get; set; } = ObjectId.GenerateNewId();
        public string OdlId { get; set; }
        public string Cliente { get; set; }
        public bool Completata { get; set; }
        public DateTime DataCompletamento { get; set; }
    }
}
