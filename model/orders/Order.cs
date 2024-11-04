using System;

namespace DeliveryService.Model.Orders
{

	public struct Order
	{

		public Order() {}

		public Order(int orderId, int district, int weight, DateTime delivery)
		{
			OrderId = orderId;
			CityDistrict = district;
			Weight = weight;
			DeliveryTime = delivery;
		}

		public int OrderId { get; set; }

		public float Weight { get; set; }

		public int CityDistrict { get; set; }

		public DateTime DeliveryTime { get; set; }

	}

}
