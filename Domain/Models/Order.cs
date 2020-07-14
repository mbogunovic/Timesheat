using System;

namespace TimeshEAT.Domain.Models
{
	public class Order : Entity
	{
        public Order()
        {
            
        }

		public Order(int id, int quantity, TimeSpan lunchTime, DateTime orderDate, int userId, int mealId, int portionId, long version, int price = 0, bool applicableDailyDiscount = false,  string comment = null) : base(id, version)
		{
			Quantity = quantity;
			LunchTime = lunchTime;
			OrderDate = orderDate;
			UserId = userId;
			MealId = mealId;
			PortionId = portionId;
			Price = price;
			ApplicableDailyDiscount = applicableDailyDiscount;
			Comment = comment;
		}

		public int Quantity { get; set; }
		public TimeSpan LunchTime { get; set; }
		public DateTime OrderDate { get; set; }
		public int UserId { get; set; }
		public int MealId { get; set; }
		public int PortionId { get; set; }
		public int Price { get; set; }
		public bool ApplicableDailyDiscount { get; set; }
		public string Comment { get; set; }
	}
}
