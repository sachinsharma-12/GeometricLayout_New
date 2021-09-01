using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Http.ModelBinding;
using GeometricLayout.Common;
using GeometricLayout.Tests.Controllers;

namespace GeometricLayout.BusinessLogic.Test
{
    [TestClass]
    public class GeometriesValidatorTest
    {
        #region IsValidInput tests
        [TestMethod]
        public void IsValidInput_AllValidRowColumnCombinations_ReturnsTrue()
        {
            var geometryValidator = new GeometriesValidator();

            foreach (var geometry in GeometricLayoutControllerTestHelper.Geometries)
            {
                string row = geometry.Key;
                foreach (var columnVsCoordinates in geometry.Value)
                {
                    //Act
                    var isValid = geometryValidator.IsValidInput(row, columnVsCoordinates.Key, new ModelStateDictionary());

                    // Assert
                    Assert.IsTrue(isValid);
                }
            }
        }

        [TestMethod]
        public void IsValidInput_NonSupportedRow_ReturnsFalse()
        {
            //Arrange
            var geometryValidator = new GeometriesValidator();

            //Act
            var isValid = geometryValidator.IsValidInput("j", 1, new ModelStateDictionary());

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsValidInput_NonSupportedColumn_ReturnsFalse()
        {
            //Arrange
            var geometryValidator = new GeometriesValidator();

            //Act
            var isValid = geometryValidator.IsValidInput("a", 18, new ModelStateDictionary());

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsValidInput_NonSupportedRowAndColumn_ReturnsFalse()
        {
            //Arrange
            var geometryValidator = new GeometriesValidator();

            //Act
            var isValid = geometryValidator.IsValidInput("j", 17, new ModelStateDictionary());

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsValidInput_NullRow_ReturnsFalse()
        {
            //Arrange
            var geometryValidator = new GeometriesValidator();

            //Act
            var isValid = geometryValidator.IsValidInput(null, 17, new ModelStateDictionary());

            // Assert
            Assert.IsFalse(isValid);
        }
        #endregion


        [TestMethod]
        public void AreCoordinatesValidToFormTriangle_AllValidRowColumnCombinations_ReturnsTrue()
        {

            foreach (var geometry in GeometricLayoutControllerTestHelper.Geometries)
            {
                foreach (var columnVsCoordinates in geometry.Value)
                {
                    //Arrange
                    var geometryValidator = new GeometriesValidator();
                    string row = geometry.Key.ToUpper();
                    string expectedData = row + columnVsCoordinates.Key;

                    //Act
                    var areValidCoordinates = geometryValidator.AreCoordinatesValidToFormTriangle(columnVsCoordinates.Value, new ModelStateDictionary());

                    // Assert
                    Assert.IsTrue(areValidCoordinates);
                }
            }
        }

        [TestMethod]
        public void AreCoordinatesValidToFormTriangle_NullCoordinate_ReturnsFalse()
        {
            //Arrange
            var geometryValidator = new GeometriesValidator();

            //Act
            var areValidCoordinates = geometryValidator.AreCoordinatesValidToFormTriangle(null, new ModelStateDictionary());

            // Assert
            Assert.IsFalse(areValidCoordinates);
        }

        [TestMethod]
        public void AreCoordinatesValidToFormTriangle_CoordinateInsideListIsNull_ReturnsFalse()
        {
            //Arrange
            var geometryValidator = new GeometriesValidator();

            //Act
            var areValidCoordinates = geometryValidator.AreCoordinatesValidToFormTriangle(null, new ModelStateDictionary());

            // Assert
            Assert.IsFalse(areValidCoordinates);
        }

        [TestMethod]
        public void AreCoordinatesValidToFormTriangle_EmptyListOfCoordinate_ReturnsFalse()
        {
            //Arrange
            var geometryValidator = new GeometriesValidator();

            //Act
            var areValidCoordinates = geometryValidator.AreCoordinatesValidToFormTriangle(new List<Coordinates>(), new ModelStateDictionary());

            // Assert
            Assert.IsFalse(areValidCoordinates);
        }
    }
}
