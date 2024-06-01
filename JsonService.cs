using BusWebApp.Interfaces;
using Newtonsoft.Json;

namespace BusWebApp.Models
{
	internal static class JsonService
	{
		private static readonly HttpClient _client = new();
		private static readonly List<IVehicleSubscriber> Subscribers = new();

		private static Timer ApiRequestTimer;
		private static RunningVehicle[] runningVehicles = Array.Empty<RunningVehicle>();

		public static RunningVehicle[] RunningVehicles => runningVehicles;

		public static StopPoint[] StopPoints { get; private set; }
		public static Line[] Lines { get; private set; }
		public static Vehicle[] Vehicles { get; private set; }
		public static Dictionary<StopPoint, (string Symbol, string Name, string Street)> SearchTags { get; private set; }

		public static void Subscribe(IVehicleSubscriber subscriber) => Subscribers.Add(subscriber);
		public static void Unsubscribe(IVehicleSubscriber subscriber) => Subscribers.Remove(subscriber);

		public static async Task Initialize()
		{
			HttpResponseMessage response;
			string content;

			response = await _client.GetAsync("https://rozklady.bielsko.pl/getStops.json");
			content = await response.Content.ReadAsStringAsync();
			StopPoints = JsonConvert.DeserializeObject<StopPointWrapper>(content).Content;

			response = await _client.GetAsync("https://rozklady.bielsko.pl/getVehicles.json");
			content = await response.Content.ReadAsStringAsync();
			Vehicles = JsonConvert.DeserializeObject<VehicleWrapper>(content).Content;

			response = await _client.GetAsync("https://rozklady.bielsko.pl/getLines.json");
			content = await response.Content.ReadAsStringAsync();
			Lines = JsonConvert.DeserializeObject<LineWrapper>(content).Content;

			SearchTags = StopPoints.ToDictionary(x => x, x => ($"Numer: {x.Symbol}", $"Nazwa: {x.Name}", $"Ulica: {x.Street}"));

			async Task CallApi()
			{
				response = await _client.GetAsync("https://rozklady.bielsko.pl/getRunningVehicles.json");
				if (response.IsSuccessStatusCode)
				{
					content = await response.Content.ReadAsStringAsync();
					runningVehicles = JsonConvert.DeserializeObject<RunningVehicleWrapper>(content).Content;
					foreach (IVehicleSubscriber s in Subscribers)
						s.OnUpdate();
				}
			}
			ApiRequestTimer = new(async _ => await CallApi(), null, 0, 10000);
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
