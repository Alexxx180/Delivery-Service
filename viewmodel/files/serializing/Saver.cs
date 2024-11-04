using System.Text.Json;
using Serilog;
using DeliveryService.ViewModel.Files;

namespace DeliveryService.ViewModel.Files.Serializing
{

	internal class Saver : Writer
	{

		private bool SetEntityToString<T>(in T entity, out string result)
		{
			bool setto = true;
			Log.Debug($"Serializing entity to json string");

			result = "";
			try
			{
				result = JsonSerializer.Serialize<T>(entity, 
					new JsonSerializerOptions { WriteIndented = true });
			}
			catch (Exception e)
			{
				SetError(e, "Can't serialize JSON.");
				setto = false;
			}

			return setto;
		}

		public bool SetEntityToFile<T>(string path, in T entity) {
			string json;
			if (!SetEntityToString(entity, out json)) return false;

			return WriteFile(path, json);
		}

	}

}
