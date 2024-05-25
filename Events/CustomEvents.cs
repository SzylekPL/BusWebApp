using Microsoft.AspNetCore.Components;

namespace BusWebApp.Events
{
	[EventHandler("ResultSelected",typeof(ResultSelectedEventArgs),true,true)]
	public static class CustomEvents
	{ }
}
