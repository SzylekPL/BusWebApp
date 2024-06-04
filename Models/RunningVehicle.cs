using Newtonsoft.Json;

namespace BusWebApp.Models
{
	public class RunningVehicle
	{
		[JsonProperty("lineName")]
		public string LineName { get; set; }
		[JsonProperty("courseLoid")]
		public string Id { get; set; }
		[JsonProperty("vehicleId")]
		public string VehicleId { get; set; }
		[JsonProperty("nearestSymbol")]
		public string NearestSymbol { get; set; }
		[JsonProperty("onStopPoint")]
		public string OnStopPoint { get; set; }
		[JsonProperty("optionalDirection")]
		public string Direction { get; set; }
	}
	public class RunningVehicleWrapper
	{
		[JsonProperty("vehicles")]
		public RunningVehicle[] Content { get; set; }
	}
}
