using Newtonsoft.Json;

namespace bus.Models
{
	public class Departure
	{
		[JsonProperty("courseId")]
		public int CourseId { get; set; }
		[JsonProperty("scheduledDepartureSec")]
		public int ScheduledDepartureSec { get; set; }
		[JsonProperty("vehicleId")]
		public string VehicleId { get; set; }
		[JsonProperty("lineName")]
		public string LineName { get; set; }
		[JsonProperty("directionName")]
		public string DirectionName { get; set; }
		public bool IsExpanded { get; set; }
	}
}
