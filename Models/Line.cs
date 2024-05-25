using Newtonsoft.Json;

namespace BusWebApp.Models
{

	public class Line
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("nightLine")]
		public bool NightLine { get; set; }
	}
	public class LinesWrapper
	{
		[JsonProperty("lines")]
		public Line[] Lines { get; set; }
	}
}
