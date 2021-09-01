using GeometricLayout.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeometricLayout.BusinessLogic.ExtensionMethods
{
    /// <summary>
    /// Extension class to hold extension method of Coordinates.
    /// </summary>
    public static class CoordinateListExtension
    {
        /// <summary>
        /// Method to sort the incoming coordinate list into an order in which the coordinate closer to (0,0) will come first.
        /// </summary>
        /// <param name="listOfCoOrdinates">listOfCoOrdinates</param>
        /// <returns>sorted list Of CoOrdinates</returns>
        public static IEnumerable<Coordinates> SortCoordinates(this List<Coordinates> listOfCoOrdinates)
        {
            return listOfCoOrdinates.GroupBy(x => Math.Pow((0 - x.X), 2) + Math.Pow((0 - x.Y), 2))
                .OrderBy(x => x.Key).SelectMany(y => y.Select(c => c));
        }
    }
}
