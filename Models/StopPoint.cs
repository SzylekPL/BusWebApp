using Newtonsoft.Json;
namespace BusWebApp.Models
{
	public class StopPoint
	{
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("longitude")]
		public string Longitude { get; set; }
		[JsonProperty("latitude")]
		public string Latitude { get; set; }
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
