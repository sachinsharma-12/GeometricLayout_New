using GeometricLayout.Common;
using System.Collections.Generic;

namespace GeometricLayout.BusinessLogic.Interface
{
    /// <summary>
    /// Interface for GeometriesProcessor
    /// </summary>
    public interface IGeometriesProcessor
    {
        /// <summary>
        /// Method to find the coordinates of triangle formed by using the row and column provided. 
        /// </summary>
        /// <param name="row">row</param>
        /// <param name="column">column</param>
        /// <returns>list of coordinates</returns>
        IList<Coordinates> GetTriangleCoordinates(string row, int column);

        /// <summary>
        /// Method to find the row and column of triangle formed by using the coordinates. 
        /// </summary>
        /// <param name="coordinates">list of coordinates</param>
        /// <returns>Row and Column on which triangle exists</returns>
        string GetTrianglePosition(List<Coordinates> coordinates);
    }
}
