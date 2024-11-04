namespace DeliveryService.Model
{

	internal static class Resources
	{

		public static string GetPath(string file)
		{
			return $"{Environment.CurrentDirectory}/resources/{file}";
		}

		public static string GetLogs(string file)
		{
			return $"{Environment.CurrentDirectory}/logs/{file}";
		}

		public static string GetReadme() {
			return $"{Environment.CurrentDirectory}/README.md";
		}

	}

}
