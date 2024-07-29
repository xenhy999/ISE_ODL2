using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ISE_ODL.Odl
{
    public class OdlItemConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {

            return typeof(BaseOdl_M).IsAssignableFrom(objectType);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            BaseOdl_M item;
            item = new Odl_M();
            serializer.Populate(jo.CreateReader(), item);
            return item;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
