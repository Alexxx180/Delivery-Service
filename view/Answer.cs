using static DeliveryService.ViewModel.Parameters.DeliveryHelp;

namespace DeliveryService.View
{

	internal static class Answer
	{

		public static string WrongCount()
		{
			return $"Wrong arguments count.\n";
		}

		public static string ConfigError(string error)
		{
			return $"{error}\n{GetHelp(HelpTopic.Config)}";
		}

		public static string FilteredCorrectly(string path)
		{
			return $"OK: Filtered in the output file: '{path}'";
		}

		public static string CorruptedReadme()
		{
			return "Corrupted README file";
		}

		public static string NoSuchReadmeTopics(string delimiter)
		{
			return $"No README topics with delimiter '{delimiter}'";
		}

		public static string NoEnoughReadmeTopics(string delimiter)
		{
			return $"No enough topics in README ('{delimiter}', 3)";
		}

	}

}
