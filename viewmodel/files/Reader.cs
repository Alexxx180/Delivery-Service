using System;
using System.IO;
using Serilog;
using DeliveryService.Model;

namespace DeliveryService.ViewModel.Files
{

	internal class Reader : LogableError
	{

		public bool ReadFile(string path, out string result)
		{
			bool read = true;
			Log.Debug($"Reading file: {path}");

			result = "";
			try
			{
				result = File.ReadAllText(path);
			}
			catch (Exception e)
			{
				SetError(e, $"Can't read file '{path}'.");
				read = false;
			}

			return read;
		}

	}

}
