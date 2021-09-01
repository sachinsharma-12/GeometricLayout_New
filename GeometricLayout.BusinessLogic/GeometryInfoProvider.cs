using GeometricLayout.BusinessLogic.ExtensionMethods;
using GeometricLayout.Common;
using System.Collections.Generic;
using System.Linq;

namespace GeometricLayout.BusinessLogic
{
    /// <summary>
    /// Class to hold the methods providing Geometry Information. 
    /// </summary>
    public static class GeometryInfoProvider
    {
        /// <summary>
        /// Method to check if the coordinate belongs to a triangle exist in even column.
        /// </summary>
        /// <param name="coordinates">coordinates</param>
        /// <returns>true if triangle exist in even column, false other wise.</returns>
        public static bool IsEvenColumnTriangle(List<Coordinates> coordinates)
        {
            if (coordinates == null)
            {
                return false;
            }
            coordinates = coordinates.SortCoordinates().ToList();
            var firstCoordinate = coordinates.FirstOrDefault();

            //Example for even numbered column - if first coordinate is (5,1), then to form triangle the other coordinate must be (4,2) and (5,2)
            //or if first coordinate is (1,1) the the other coordinates must be (0,2) or (1,2) 
            return (coordinates.Any(x => x.X == firstCoordinate.X + 1 && x.Y == firstCoordinate.Y - 1)
                    &&
                    coordinates.Any(x => x.X == firstCoordinate.X + 1 && x.Y == firstCoordinate.Y))
                   ||
                   (coordinates.Any(x => x.X == firstCoordinate.X - 1 && x.Y == firstCoordinate.Y + 1)
                    &&
                    coordinates.Any(x => x.X == firstCoordinate.X && x.Y == firstCoordinate.Y));
        }

        /// <summary>
        /// Method to check if the coordinate belongs to a triangle exist in odd column.
        /// </summary>
        /// <param name="coordinates">coordinates</param>
        /// <returns>true if triangle exist in odd column, false other wise.</returns>
        public static bool IsOddColumnTriangle(List<Coordinates> coordinates)
        {
            if (coordinates == null)
            {
                return false;
            }

            coordinates = coordinates.SortCoordinates().ToList();
            var firstCoordinate = coordinates.FirstOrDefault();
            //Example For Odd numbered column - if first coordinate is (5,1), then to form triangle the other coordinate must be (6,1) and (5,2)
            return coordinates.Any(x => x.X == firstCoordinate.X && x.Y == firstCoordinate.Y + 1)
                   &&
                   coordinates.Any(x => x.X == firstCoordinate.X + 1 && x.Y == firstCoordinate.Y);
        }
    }
}
