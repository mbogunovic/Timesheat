using System;
using System.Collections.Generic;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.EqualityComparers
{
    public class PortionEqualityComparer : IEqualityComparer<PortionModel>
    {
        public bool Equals(PortionModel x, PortionModel y)
        {
            if(x == null) throw new ArgumentNullException(nameof(x), "First portion cannot be null!");
            if(y == null) throw new ArgumentNullException(nameof(y), "Second portion cannot be null!");

            return x.Id == y.Id;
        }

        public int GetHashCode(PortionModel obj) => obj.Id;
    }
}
