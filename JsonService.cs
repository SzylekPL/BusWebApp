using Newtonsoft.Json;

namespace BusWebApp.Models
{
	internal static class JsonService
	{
		private static readonly HttpClient _client = new();

		public static StopPoint[] StopPoints { get; private set; }
		public static Line[] Lines { get; private set; }
		public static Vehicle[] Vehicles { get; private set; }
		public static Dictionary<StopPoint, (string Symbol, string Name, string Street)> SearchTags { get; private set; }

		public static async Task Initialize()
		{
			HttpResponseMessage response = await _client.GetAsync("https://rozklady.bielsko.pl/getStops.json");
			string content = await response.Content.ReadAsStringAsync();
			StopPoints = JsonConvert.DeserializeObject<StopPointWrapper>(content).Content;

			response = await _client.GetAsync("https://rozklady.bielsko.pl/getVehicles.json");
			content = await response.Content.ReadAsStringAsync();
			Vehicles = JsonConvert.DeserializeObject<VehicleWrapper>(content).Content;

			response = await _client.GetAsync("https://rozklady.bielsko.pl/getLines.json");
			content = await response.Content.ReadAsStringAsync();
			Lines = JsonConvert.DeserializeObject<LineWrapper>(content).Content;

			SearchTags = StopPoints.ToDictionary(x => x, x => ($"Numer: {x.Symbol}", $"Nazwa: {x.Name}", $"Ulica: {x.Street}"));
		}

		public static async Task<StopPointInfo> GetPointInfo(string symbol)
		{
			HttpResponseMessage response = await _client.GetAsync($"https://rozklady.bielsko.pl/getRealtime.json?stopPointSymbol={symbol}");
			string content = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<StopPointInfo>(content);
		}
		public static Vehicle GetVehicleInfo(string id) => Vehicles.First(x => x.SideNumber == id);

		public static async Task<StopPoint[]> GetStopsByCourse(string lineId, bool thereDirection)
		{
			HttpResponseMessage response = await _client.GetAsync($"https://rozklady.bielsko.pl/getDirection.json?lineId={lineId}&thereDirection={thereDirection}");
			string content = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<StopPointWrapper>(content).Content;
		}
	}
}
