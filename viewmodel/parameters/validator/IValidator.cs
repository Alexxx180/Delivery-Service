using System;
using DeliveryService.Model.Orders;

namespace DeliveryService.ViewModel.Parameters.Validator
{

	internal interface IValidator
	{

		public bool Validate(out FirstOrder first, params string[] args);

		public string Error { get; }

	}

}
