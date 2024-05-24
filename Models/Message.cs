using Newtonsoft.Json;
namespace BusWebApp.Models
{
	public class Message
	{
		[JsonProperty("loid")]
		public string Id { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("intro")]
		public string Intro { get; set; }
		[JsonProperty("stopSymbols")]
		public string[] StopSymbols { get; set; }
		[JsonProperty("lineNames")]
		public string[] LineNames { get; set; }
	}
}
