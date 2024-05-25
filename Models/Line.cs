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
	public class LineWrapper
	{
		[JsonProperty("lines")]
		public Line[] Content { get; set; }
	}
}
