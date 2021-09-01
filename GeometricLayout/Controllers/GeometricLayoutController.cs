using GeometricLayout.BusinessLogic;
using GeometricLayout.BusinessLogic.Interface;
using GeometricLayout.Common;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace GeometricLayout.Controllers
{
    /// <summary>
    /// Controller class to handle executions of GeometricLayout WebApis
    /// </summary>
    public class GeometricLayoutController : ApiController
    {
        private IGeometriesValidator _geometriesValidator;
        private IGeometriesProcessor _geometriesProcessor;

        /// <summary>
        /// Property to hold Validator which will handle validation logic.
        /// </summary>
        public IGeometriesValidator GeometriesValidator 
        {
            get => _geometriesValidator ?? (_geometriesValidator = new GeometriesValidator());
            set => _geometriesValidator = value;
        }

        /// <summary>
        /// Property to hold Processor which will handle processing logic.
        /// </summary>
        public IGeometriesProcessor GeometriesProcessor
        {
            get => _geometriesProcessor ?? (_geometriesProcessor = new GeometriesProcessor());
            set => _geometriesProcessor = value;
        }
        
        /// <summary>
        /// Dictionary to hold the validation failure details
        /// </summary>
        public ModelStateDictionary ModelStateDictionary { get; set; } = new ModelStateDictionary();

        /// <summary>
        /// Wep Api to get the coordinates for the provided row and column.
        /// </summary>
        /// <param name="row">row</param>
        /// <param name="column">column</param>
        /// <returns>IHttpActionResult consisting the data</returns>
        [HttpGet()]
        public IHttpActionResult GetCoordinates([FromUri] string row, [FromUri] int column)
        {
            IHttpActionResult result = null;
            try
            {
                row = row?.ToLower();
                if (!GeometriesValidator.IsValidInput(row, column, ModelStateDictionary))
                {
                    result = BadRequest(ModelStateDictionary);
                }
                else
                {
                    var list = GeometriesProcessor.GetTriangleCoordinates(row, column);

                    result = Ok(list);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while Getting coordinates. More details : " + ex.Message);
                result = InternalServerError(ex);
            }

            return result;
        }

        /// <summary>
        /// Wep Api to get the triangle location, row and column info of the triangle for the provided list of coordinates.
        /// </summary>
        /// <param name="coordinates">list of coordinates</param>
        /// <returns>IHttpActionResult consisting of data or error messages</returns>
        [HttpPost()]
        public IHttpActionResult GetTriangleLocation(List<Coordinates> coordinates)
        {
            IHttpActionResult result = null;

            try
            {
                if (!GeometriesValidator.AreCoordinatesValidToFormTriangle(coordinates, ModelStateDictionary))
                {
                    result = BadRequest(ModelStateDictionary);
                }
                else
                {
                    var list = GeometriesProcessor.GetTrianglePosition(coordinates);

                    result = Ok(list);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while Getting triangle location. More details : " + ex.Message);
                result = InternalServerError(ex);
            }

            return result;
        }
    }
}
