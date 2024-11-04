using System;
using System.Linq;
using System.Collections.Generic;
using Serilog;
using DeliveryService.Model.Orders;
using DeliveryService.ViewModel.Files.Serializing;
using static DeliveryService.Model.Resources;
using static DeliveryService.View.Answer;

namespace DeliveryService.ViewModel
{

	internal class OrdersFlow
	{

		public static string FilterOrders(FirstOrder first)
		{
			List<Order> orders;

			Log.Information("Reading orders.");

			string path = GetPath("input.json");
			Loader loader = new Loader();
			if (!loader.GetEntityFromFile(path, out orders))
				return loader.Error;

			Log.Information("Filtering orders.");
			List<Order> filtered = orders.Where(o => first.Respond(o)).ToList();

			Log.Information("Writing orders.");

			path = GetPath("output.json");
			Saver saver = new Saver();
			if (!saver.SetEntityToFile(path, filtered))
				return saver.Error;

			string result = FilteredCorrectly(path);

			Log.Information(result);
			return result;
		}

	}

}
