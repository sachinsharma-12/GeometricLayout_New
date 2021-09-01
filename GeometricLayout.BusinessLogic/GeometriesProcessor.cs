using GeometricLayout.BusinessLogic.Interface;
using GeometricLayout.Common;
using GeometricLayout.Data;
using System.Collections.Generic;
using System.Linq;

namespace GeometricLayout.BusinessLogic
{
    /// <summary>
    /// Processor class to hold the functionality of processing the different geometries.
    /// </summary>
    public class GeometriesProcessor : IGeometriesProcessor
    {
        /// <summary>
        /// Method to find the coordinates of triangle formed by using the row and column provided. 
        /// </summary>
        /// <param name="row">row</param>
        /// <param name="column">column</param>
        /// <returns>list of coordinates</returns>
        public IList<Coordinates> GetTriangleCoordinates(string row, int column)
        {
            var listOfCoordinates = new List<Coordinates>();

            if (row == null || !GeometriesDataHandler.RowVsXAxisMap.ContainsKey(row.ToLower()) || 
                column < GeometriesDataHandler.MinSupportedColumn || column > GeometriesDataHandler.MaxSupportedColumn)
            {
                return listOfCoordinates;
            }

            row = row?.ToLower();
            int yAxis = GeometriesDataHandler.RowVsXAxisMap[row];
            var xAxis = column / 2;
            if (column % 2 != 0)
            {
                //we need to traverse further and get exact coordinate of nth column.

                listOfCoordinates.Add(new Coordinates(xAxis, yAxis));
                //Since it is an odd point we will decrease Y value and then increase X Value
                
                listOfCoordinates.Add(new Coordinates(xAxis, ++yAxis));

                //Since it is an odd point we will decrease Y value and then increase X Value
                listOfCoordinates.Add(new Coordinates(++xAxis, --yAxis));
            }
            else
            {
                //we need to traverse further and get exact coordinate of nth column.
                listOfCoordinates.Add(new Coordinates(xAxis, yAxis));

                //Since it is an even point we will increase X value and then decrease Y Value
                yAxis++;
                listOfCoordinates.Add(new Coordinates(xAxis, yAxis));

                xAxis--; 
                listOfCoordinates.Add(new Coordinates(xAxis, yAxis));
            }

            return listOfCoordinates;
        }

        /// <summary>
        /// Method to find the row and column of triangle formed by using the coordinates. 
        /// </summary>
        /// <param name="coordinates">list of coordinates</param>
        /// <returns>Row and Column on which triangle exists</returns>
        public string GetTrianglePosition(List<Coordinates> coordinates)
        {
            var triangle = "";

            if (coordinates != null && coordinates.Count > 0 && coordinates.Count(x => x == null) == 0)
            {
                //Get the X-axis coordinate of the triangle.
                //Among the three valid coordinates, get the xaxis coordinate which is occurred maximum times. This will provide us the adjacent vertices.
                var verticalAxis = coordinates.GroupBy(x => x.X)
                                                  .Where(y => y.Select(z => z).Count() > 1)
                                                  ?.FirstOrDefault()
                                                  ?.Key;

                //Two triangle forms one complete vertex - for example if we traverse from 0,0 to 1,1 -> 2 right angled triangle will form. 
                //Hence if we find the proper Y axis of the triangle then column number of it will be a value multiplied by 2.
                //For example : If our coordinates are (1,2) (1,3) & (2,2) then we have x axis as 1. Hence if we multiply it by 2, we get that the triangle is at column 2 or at higher side.
                var columnNumber = verticalAxis * 2;

                //Now if triangle is an even column triangle column value will be the columnNumber else i is on higher side of columnNumber value. Hence incrementing it by 1.
                if (GeometryInfoProvider.IsOddColumnTriangle(coordinates))
                {
                    columnNumber++;
                }

                //Find out the smallest vertex on Y axis among the provided coordinates.
                //This is the actual row in RowVsXAxisMap.
                var smallestYAxisVertex = coordinates.GroupBy(x => x.Y).Select(z => z.Key).Min();

                var row = GeometriesDataHandler.RowVsXAxisMap.FirstOrDefault(x => x.Value == smallestYAxisVertex).Key.ToUpper();

                triangle = "The triangle formed using the given vertex is " + row + columnNumber;

            }

            return triangle;

        }
    }
}
