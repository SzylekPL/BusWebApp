using BusWebApp.Models;

namespace BusWebApp.Interfaces
{
	public interface IVehicleSubscriber
	{
		public void OnUpdate(RunningVehicle[] updateContent);
	}
}
