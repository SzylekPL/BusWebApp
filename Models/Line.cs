using Newtonsoft.Json;

namespace bus.Models
{

	public class Line
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("nightLine")]
		public bool NightLine { get; set; }
		public bool Expanded { get; set; } = false;
	}
	public class LinesWrapper
	{
		[JsonProperty("lines")]
		public Line[] Lines { get; set; }
	}
}
