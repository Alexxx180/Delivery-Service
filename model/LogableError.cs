using Serilog;

namespace DeliveryService.Model
{

	public class LogableError
	{

		public LogableError(string error = "")
		{
			_error = error;
		}

		private string _error;
		public string Error => _error;

		private protected void SetError(string message, string logs) {
			_error = message;
			Log.Error(logs);
		}

		private protected void SetError(string message) {
			SetError(message, message);
		}

		private protected void SetError(Exception e, string message) {
			_error = $"{message}\n{e.Message}";
			Log.Error(message, e.ToString());
		}

	}

}


