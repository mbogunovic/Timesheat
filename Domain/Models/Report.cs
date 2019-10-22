using System;

namespace TimeshEAT.Domain.Models
{
    public class Report
    {
        public int MealId { get; set; }
        public string MealName { get; set; }
        public int PortionId { get; set; }
        public string PortionName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int DiscountedPrice { get; set; }
        public int DailyDiscount { get; set; }
        public DateTime OrderDate { get; set; }
        public TimeSpan LunchTime { get; set; }
    }
}
