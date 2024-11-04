using Serilog;
using DeliveryService.ViewModel.Files;
using static DeliveryService.Model.Resources;
using static DeliveryService.View.Answer;

namespace DeliveryService.ViewModel.Parameters
{

	internal static class DeliveryHelp
	{

		internal enum HelpTopic : byte
		{
			Help = 0, Order = 1, Config = 2
		};

		public static string GetHelpFull() {
			Log.Information("Showed full help.");
			string help;

			Reader reader = new Reader();
			if (reader.ReadFile(GetReadme(), out help))
				return help.Replace("#", "-");

			return CorruptedReadme();
		}

		public static string GetHelp(HelpTopic topic)
		{
			Log.Information($"Showed help for topic '{topic}'.");
			string help;

			Reader reader = new Reader();
			if (!reader.ReadFile(GetReadme(), out help))
				return CorruptedReadme();

			string delimiter = "##";

			int i = help.IndexOf(delimiter);
			if (i == -1)
				return NoSuchReadmeTopics(delimiter);

			string[] topics = help.Substring(i + 2).Split(delimiter);
			if (topics.Length != 3)
				return NoEnoughReadmeTopics(delimiter);

			return "-" + topics[(byte) topic];
		}

		private static HelpTopic GetTopic(string topic) => topic switch
		{
			"config" => HelpTopic.Config,
			"order" => HelpTopic.Order,
			_ => HelpTopic.Help
		};

		public static bool ContainsHelp(params string[] args)
		{
			if (!args[0].Equals("help"))
				return false;

			if (args.Length != 2) {
				Console.WriteLine(GetHelp(HelpTopic.Help));
				return true;
			}

			if (args[1].Equals("full")) {
				Console.WriteLine(GetHelpFull());
				return true;
			}

			Console.WriteLine(GetHelp(GetTopic(args[1])));
			return true;
		}

	}
}
