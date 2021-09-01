using GeometricLayout.Common;
using System.Collections.Generic;
using System.Web.Http.ModelBinding;

namespace GeometricLayout.BusinessLogic.Interface
{
    /// <summary>
    /// Interface for GeometriesValidator
    /// </summary>
    public interface IGeometriesValidator
    {
        /// <summary>
        /// Method to validate the row and column for which the coordinates of triangle to be found.
        /// </summary>
        /// <param name="row">row</param>
        /// <param name="column">column</param>
        /// <param name="validationMessages">validationMessages</param>
        /// <returns>true if row and column provided are valid.</returns>
        bool IsValidInput(string row, int column, ModelStateDictionary validationMessages);
        
        /// <summary>
        /// Method to validate the coordinate for which the triangle location is to be found.
        /// </summary>
        /// <param name="coordinates">coordinates</param>
        /// <param name="validationMessages">validationMessages</param>
        /// <returns>true if coordinate can form a triangle. false otherwise.</returns>
        bool AreCoordinatesValidToFormTriangle(List<Coordinates> coordinates, ModelStateDictionary validationMessages);
    }
}
