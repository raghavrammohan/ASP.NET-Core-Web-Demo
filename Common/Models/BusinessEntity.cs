using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Common.Models
{
    public abstract class BusinessEntity
    {
        public abstract string GetRecordId();
        public string GetRecordType()
        {
            return this.GetType().Name;
        }
        public JsonObject GetNaturalKey()
        {
            var json = new JsonObject();
            json.Add("recordType", this.GetRecordType());
            json.Add("recordId", this.GetRecordId());
            return json;
        }
    }
}
