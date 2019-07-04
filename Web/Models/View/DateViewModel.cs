using System;
using System.Collections.Generic;
using TimeshEAT.Web.Extensions;

namespace TimeshEAT.Web.Models.View
{
    public class DateViewModel
    {
        private readonly Dictionary<int, string> _months = new Dictionary<int, string>
        {
            {1, "Januar" },
            {2, "Februar" },
            {3, "Mart" },
            {4, "April" },
            {5, "Maj" },
            {6, "Jun" },
            {7, "Jul" },
            {8, "Avgust" },
            {9, "Septembar" },
            {10, "Oktobar" },
            {11, "Novembar" },
            {12, "Decembar" }
        };

        private readonly Dictionary<DayOfWeek, string> _dayOfWeek = new Dictionary<DayOfWeek, string>
        {
            {DayOfWeek.Monday, "Ponedeljak" },
            {DayOfWeek.Tuesday, "Utorak" },
            {DayOfWeek.Wednesday, "Sreda" },
            {DayOfWeek.Thursday, "Cetvrtak" },
            {DayOfWeek.Friday, "Petak" },
            {DayOfWeek.Saturday, "Subota" },
            {DayOfWeek.Sunday, "Nedelja" },
        };
        public DateTime Date { get; set; }
        public string Month => _months[Date.Month];
        public string Day => _dayOfWeek[Date.DayOfWeek];
        public string Week => $"{Date.GetIso8601WeekOfYear()}. nedelja";

    }
}