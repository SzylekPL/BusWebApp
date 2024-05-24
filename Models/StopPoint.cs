using Newtonsoft.Json;
namespace bus.Models
{
	public class StopPoint
	{
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("longitude")]
		public double Longitude { get; set; }
		[JsonProperty("latitude")]
		public double Latitude { get; set; }
		[JsonProperty("symbol")]
		public string Symbol { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("street")]
		public string Street { get; set; }
		[JsonProperty("gettingOut")]
		public bool IsStarting { get; set; }
	}
	public class StopPointWrapper
	{
		[JsonProperty("stopPoints")]
		public StopPoint[] Content { get; set; }
	}
}
