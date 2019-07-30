using System;
using System.Collections.Generic;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.EqualityComparers
{
    public class MealPortionEqualityComparer : IEqualityComparer<MealPortionModel>
    {
        public bool Equals(MealPortionModel x, MealPortionModel y)
        {
            if(x == null) throw new ArgumentNullException(nameof(x), "First MealPortion model cannot be null!");
            if(y == null) throw new ArgumentNullException(nameof(y), "Second MealPortion model cannot be null!");

            return x.Portion.Id == y.Portion.Id;
        }

        public int GetHashCode(MealPortionModel obj) => obj.Portion.Id;
    }
}
