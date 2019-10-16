using System;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Business.Models
{
    public class ReportModel
    {
        public ReportModel() { }
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

        #region [Implicit Operators]

        public static implicit operator Report(ReportModel reportModel)
        {
            if (reportModel == null)
            {
                throw new NullReferenceException("Report cannot be null!");
            }

            return new Report
            {
                UserId = reportModel.UserId,
                UserName = reportModel.UserName,
                CompanyId = reportModel.CompanyId,
                CompanyName = reportModel.CompanyName,
                MealId = reportModel.MealId,
                MealName = reportModel.MealName,
                DailyDiscount = reportModel.DailyDiscount,
                Price = reportModel.Price,
                DiscountedPrice = reportModel.DiscountedPrice,
                PortionId = reportModel.PortionId,
                PortionName = reportModel.PortionName,
                Quantity = reportModel.Quantity,
                LunchTime = reportModel.LunchTime,
                OrderDate = reportModel.OrderDate
            };
        }

        public static implicit operator ReportModel(Report dbReport)
        {
            if (dbReport == null)
            {
                throw new NullReferenceException("Report cannot be null!");
            }

            return new ReportModel
            {
                UserId = dbReport.UserId,
                UserName = dbReport.UserName,
                CompanyId = dbReport.CompanyId,
                CompanyName = dbReport.CompanyName,
                MealId = dbReport.MealId,
                MealName = dbReport.MealName,
                DailyDiscount = dbReport.DailyDiscount,
                Price = dbReport.Price,
                DiscountedPrice = dbReport.DiscountedPrice,
                PortionId = dbReport.PortionId,
                PortionName = dbReport.PortionName,
                Quantity = dbReport.Quantity,
                OrderDate = dbReport.OrderDate,
                LunchTime = dbReport.LunchTime
            };
        }

        #endregion
    }
}
