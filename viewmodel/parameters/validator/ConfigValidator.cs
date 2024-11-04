using System;
using Serilog;
using DeliveryService.Model;
using DeliveryService.Model.Orders;
using DeliveryService.ViewModel.Files.Serializing;
using DeliveryService.ViewModel.Parameters;
using static DeliveryService.Model.Resources;
using static DeliveryService.View.Answer;

namespace DeliveryService.ViewModel.Parameters.Validator
{

	internal class ConfigValidator : IValidator
	{

		private static string GetHelp()
		{
			return DeliveryHelp.GetHelp(DeliveryHelp.HelpTopic.Config);
		}

		public ConfigValidator()
		{
			Error = $"{WrongCount()}\n{GetHelp()}";
		}

		public bool Validate(out FirstOrder first, params string[] args)
		{
			bool needHelp = true;
			Log.Information("Config: validating parameters.");

			if (args.Length > 2) {
				first = new FirstOrder();
				return needHelp;
			}

			string path = args.Length == 2 ?
				args[1] : GetPath("config.json");

			Log.Debug($"Set config path: '{path}'");

			Loader loader = new Loader();
			needHelp = !loader.GetEntityFromFile(path, out first);
			if (needHelp)
				Error = ConfigError(loader.Error);

			Log.Debug($"Needs help = {needHelp}");

			return needHelp;
		}

		public string Error { get; private set; }

	}

}
