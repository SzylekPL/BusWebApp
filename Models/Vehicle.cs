using Newtonsoft.Json;

namespace bus.Models
{
	public class Vehicle
	{
		[JsonProperty("sideNumber")]
		public string SideNumber { get; set; }
		[JsonProperty("longVehicle")]
		public bool IsLong { get; set; }
		[JsonProperty("airCondition")]
		public bool HasAirCondition { get; set; }
		[JsonProperty("lowFloor")]
		public bool HasLowFloor { get; set; }
		[JsonProperty("ecoVehicle")]
		public bool IsEco { get; set; }
		[JsonProperty("ticketmachineCashCard")]
		public bool TicketMachineCashCard { get; set; }
		[JsonProperty("ticketmachineCash")]
		public bool TicketMachineCash { get; set; }
		[JsonProperty("ticketmachineCard")]
		public bool TicketMachineCard { get; set; }
		[JsonProperty("overStandard")]
		public bool OverStandard { get; set; }
		[JsonProperty("electric")]
		public bool IsElectric { get; set; }
		[JsonProperty("hybrid")]
		public bool IsHybrid { get; set; }
		[JsonProperty("active")]
		public bool IsActive { get; set; }
	}
	public class VehicleWrapper
	{
		[JsonProperty("vehicles")]
		public Vehicle[] Content { get; set; }
	}
}
