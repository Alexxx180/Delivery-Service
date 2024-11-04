using System.Text.Json;
using Serilog;
using DeliveryService.Model.Orders;
using DeliveryService.ViewModel;
using DeliveryService.ViewModel.Files;
using DeliveryService.ViewModel.Parameters;
using DeliveryService.ViewModel.Parameters.Validator;
using static DeliveryService.ViewModel.Parameters.DeliveryHelp;

namespace DeliveryService
{

	internal class Program
	{

		private static IValidator Decide(string arg) => arg switch
		{
			"order" => new ParametersValidator(),
			_ => new ConfigValidator()
		};

		public static void Main(params string[] args)
		{
			Logging.Setup();
			string[] features = { "help", "order", "config" };
			int l = args.Length;

			if (0 == l || l > 3 || !features.Contains(args[0])) {
				Console.WriteLine(GetHelp(HelpTopic.Help));
				return;
			}

			if (ContainsHelp(args)) return;

			FirstOrder first;
			IValidator validator = Decide(args[0]);

			if (validator.Validate(out first, args)) {
				Console.WriteLine(validator.Error);
				return;
			}

			Console.WriteLine(OrdersFlow.FilterOrders(first));
		}

	}

}
