using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Serilog.Ex.Models
{

	public class Serilogs
    {
        public ObjectId Id { get; set; }
        public DateTime Timestamp { get; set; }

        public string Level { get; set; }
        public string MessageTemplate { get; set; }
		public string RenderedMessage { get; set; }
		public string Properties { get; set; }
		public string UtcTimestamp { get; set; }
		public string Exception { get; set; }
	}
}
