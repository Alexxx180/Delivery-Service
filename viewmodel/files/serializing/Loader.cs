using System.Text.Json;
using Serilog;
using DeliveryService.ViewModel.Files;

namespace DeliveryService.ViewModel.Files.Serializing
{

	internal class Loader : Reader
	{

		private bool GetEntityFromString<T>(string json, out T result)
		{
			bool getfrom = true;
			Log.Debug($"Deserializing JSON string");

			result = Activator.CreateInstance<T>();
			try
			{
				result = JsonSerializer.Deserialize<T>(json)!;
			}
			catch (Exception e)
			{
				SetError(e, "Can't deserialize JSON.");
				getfrom = false;
			}

			return getfrom;
		}

		public bool GetEntityFromFile<T>(string path, out T result) {
			string json;
			if (!ReadFile(path, out json)) {
				result = Activator.CreateInstance<T>();
				return false;
			}

			return GetEntityFromString(json, out result);
		}

	}

}
