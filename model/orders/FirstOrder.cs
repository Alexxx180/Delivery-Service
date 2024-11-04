namespace DeliveryService.Model.Orders
{

	internal class FirstOrder
	{

		private enum Dates : sbyte
		{
			Earlier = -1, Later = 1, TheSame = 0
		};

		public FirstOrder() {}

		public FirstOrder(int district, DateTime firstDelivery)
		{
			CityDistrict = district;
			DeliveryTime = firstDelivery;
		}

		private bool RespondMinutes(DateTime order, int minutes)
		{
			DateTime nearest = DeliveryTime.AddMinutes(minutes);
			return nearest.CompareTo(order) == (sbyte) Dates.Later &&
				DeliveryTime.CompareTo(order) <= (sbyte) Dates.TheSame;
		}

		public bool Respond(Order order)
		{
			return (RespondMinutes(order.DeliveryTime, 30)
				&& CityDistrict == order.CityDistrict);
		}

		public bool TrySetCityDistrict(string district)
		{
			return int.TryParse(district, out _cityDistrict);
		}

		public bool TrySetDeliveryTime(string delivery)
		{
			return DateTime.TryParse(delivery, out _deliveryTime);
		}

		private int _cityDistrict;
		public int CityDistrict
		{
			get => _cityDistrict;
			set => _cityDistrict = value;
		}

		private DateTime _deliveryTime;
		public DateTime DeliveryTime
		{
			get => _deliveryTime;
			set => _deliveryTime = value;
		}

	}

}
