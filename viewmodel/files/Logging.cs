using System;
using Serilog;
using static DeliveryService.Model.Resources;

namespace DeliveryService.ViewModel.Files
{

	public static class Logging
	{

		public static void Setup()
		{
			string _deliveryLog = GetLogs("launch-.log");

			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.File(_deliveryLog, rollingInterval: RollingInterval.Day).CreateLogger();

			Log.Information("Initializing Delivery-Service");
		}

	}

}
