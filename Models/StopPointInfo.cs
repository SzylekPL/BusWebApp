using Newtonsoft.Json;

namespace bus.Models
{
	public class StopPointInfo
	{
		[JsonProperty("stopPointSymbol")]
		public string Symbol { get; set; }
		[JsonProperty("stopPointId")]
		public int Id { get; set; }
		[JsonProperty("stopPointName")]
		public string Name { get; set; }
		[JsonProperty("departures")]
		public Departure[] Departures { get; set; }
	}
}
