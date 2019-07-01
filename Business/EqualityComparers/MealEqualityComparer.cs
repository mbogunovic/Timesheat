using System;
using System.Collections.Generic;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.EqualityComparers
{
    public class MealEqualityComparer : IEqualityComparer<MealModel>
    {
        public bool Equals(MealModel x, MealModel y)
        {
            if(x == null) throw new ArgumentNullException(nameof(x), "First meal cannot be null!");
            if(y == null) throw new ArgumentNullException(nameof(y), "Second meal cannot be null!");

            return x.Id == y.Id;
        }

        public int GetHashCode(MealModel obj) => obj.GetHashCode();
    }
}
