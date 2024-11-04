using System;
using System.IO;
using Serilog;
using DeliveryService.Model;

namespace DeliveryService.ViewModel.Files
{

	internal class Writer : LogableError
	{

		public bool WriteFile(string path, in string text)
		{
			bool wrote = true;
			Log.Debug($"Writing to file: {path}");

			try
			{
				File.WriteAllText(path, text);
			}
			catch (Exception e)
			{
				SetError(e, $"Can't write file '{path}'.");
				wrote = false;
			}

			return wrote;
		}

	}

}
