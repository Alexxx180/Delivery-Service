using System;
using Serilog;
using DeliveryService.Model;
using DeliveryService.Model.Orders;
using DeliveryService.ViewModel.Parameters;
using static DeliveryService.View.Answer;

namespace DeliveryService.ViewModel.Parameters.Validator
{

	internal class ParametersValidator : LogableError, IValidator
	{

		private static string GetHelp() {
			return DeliveryHelp.GetHelp(DeliveryHelp.HelpTopic.Order);
		}

		public ParametersValidator() :
			base($"{WrongCount()}\n{GetHelp()}") {}

		private bool Describe(string parsing)
		{
			SetError($"{parsing}.\n{GetHelp()}", parsing);
			return true;
		}

		public bool Validate(out FirstOrder first, params string[] args)
		{
			Log.Information("Order: validating parameters.");

			first = new FirstOrder();

			if (args.Length != 3) return true;

			string delivery = args[2].Replace("_", " ");
			string parsing = "Can't parse parameter: ";

			Log.Debug("Parsing parameters");

			if (!first.TrySetCityDistrict(args[1]))
				return Describe(parsing + "'City District'");

			if (!first.TrySetDeliveryTime(delivery))
				return Describe(parsing + "'Delivery Time'");

			return false;
		}

	}

}
