using System.Text.Json.Nodes;

namespace Common.Models
{
    public abstract class BusinessEntity
    {
        public abstract string GetRecordId();
        public string RecordType => GetType().Name;
        public JsonObject GetNaturalKey() => new() {
                { "recordType", RecordType },
                { "recordId", GetRecordId() }
        };
    }
}
