using GeometricLayout.BusinessLogic.Interface;
using GeometricLayout.Common;
using GeometricLayout.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.ModelBinding;

namespace GeometricLayout.BusinessLogic
{
    /// <summary>
    /// Validator class to hold the validation logic for GeometricLayout.
    /// </summary>
    public class GeometriesValidator : IGeometriesValidator
    {
        /// <summary>
        /// Method to validate the row and column for which the coordinates of triangle to be found.
        /// </summary>
        /// <param name="row">row</param>
        /// <param name="column">column</param>
        /// <param name="validationMessages">validationMessages</param>
        /// <returns>true if row and column provided are valid.</returns>
        public bool IsValidInput(string row, int column, ModelStateDictionary validationMessages)
        {
            //Do other input validations here.
            if (!IsValidRow(row))
            {
                validationMessages.AddModelError("InValidRow", "Row number can be in range from A to F");
            }
            if (!IsValidColumn(column))
            {
                validationMessages.AddModelError("InValidColumn", "Column number can be in range from 1 to 12");
            }

            return validationMessages.Count == 0;
        }

        /// <summary>
        /// Method to validate the coordinate for which the triangle location is to be found.
        /// </summary>
        /// <param name="coordinates">coordinates</param>
        /// <param name="validationMessages">validationMessages</param>
        /// <returns>true if coordinate can form a triangle. false otherwise.</returns>
        public bool AreCoordinatesValidToFormTriangle(List<Coordinates> coordinates, ModelStateDictionary validationMessages)
        {
            bool areCoordinateValid = false;
            if (coordinates != null && coordinates.Count(x => x == null) == 0)
            {
                //There are 2 type of triangles. 1 in odd numbered columns - 1,3,5,7,9,11 and 1 in even numbered columns 2,4,6,8,10,12
                if (GeometryInfoProvider.IsOddColumnTriangle(coordinates) || GeometryInfoProvider.IsEvenColumnTriangle(coordinates))
                {
                    areCoordinateValid = true;
                }
                else
                {
                    validationMessages.AddModelError("InvalidCoordinates", "Coordinates provided do not be form a triangle.");
                }
            }

            return areCoordinateValid;
        }


        private bool IsValidRow(string row)
        {
            return row != null && GeometriesDataHandler.RowVsXAxisMap.ContainsKey(row);
        }

        private bool IsValidColumn(int column)
        {
            return column != null && column > 0 && column <= GeometriesDataHandler.MaxSupportedColumn;
        }
    }
}
