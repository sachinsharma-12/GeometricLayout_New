using GeometricLayout.BusinessLogic.Interface;
using GeometricLayout.Common;
using GeometricLayout.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;

namespace GeometricLayout.Tests.Controllers
{
    [TestClass]
    public class GeometricLayoutControllerTest
    {
        private GeometricLayoutController _geometricLayoutController;

        [TestInitialize]
        public void TestClassSetup()
        {
            _geometricLayoutController = new GeometricLayoutController();
        }

        #region GetCoordinate tests
        [TestMethod]
        public void GetCoordinates_ValidGeometries_ReturnsCoordinateList()
        {
            var row = 65; //ASCII value of A
            var column = 1;

            while (row < 71)//71 ASCII value of G - looping from A to F
            {
                int columnInternal = column;
                for (; columnInternal < 13; columnInternal++) //looping from 1st column to nth supported column
                {
                    //Arrange

                    var rowInternal = ((char)row).ToString();
                    var expectedData = GeometricLayoutControllerTestHelper.Geometries[rowInternal.ToLower()][columnInternal];

                    var geometryProcessorMock = new Mock<IGeometriesProcessor>();
                    geometryProcessorMock.Setup(x => x.GetTriangleCoordinates(rowInternal.ToLower(), columnInternal))
                        .Returns(expectedData);
                    _geometricLayoutController.GeometriesProcessor = geometryProcessorMock.Object;

                    var geometricValidatorMock = new Mock<IGeometriesValidator>();
                    geometricValidatorMock.Setup(x => x.IsValidInput(rowInternal.ToLower(), columnInternal, It.IsAny<ModelStateDictionary>()))
                        .Returns(true);
                    _geometricLayoutController.GeometriesValidator = geometricValidatorMock.Object;

                    _geometricLayoutController.ModelStateDictionary = new ModelStateDictionary();


                    //Act
                    IHttpActionResult result = _geometricLayoutController.GetCoordinates(rowInternal, columnInternal);
                    var actualCoordinates = ((OkNegotiatedContentResult<IList<Coordinates>>)result).Content;

                    // Assert
                    Assert.AreEqual(expectedData.Count, actualCoordinates.Count);
                    foreach (var coordinateInExpectedData in expectedData)
                    {
                        Assert.IsTrue(actualCoordinates.Contains(coordinateInExpectedData));
                    }
                }

                row++;
            }
        }

        [TestMethod]
        public void GetCoordinates_UnsupportedRow_ReturnsInvalidRowInBadRequest()
        {
            //Arrange
            string row = "h";
            int column = 1;

            var geometryValidatorMock = new Mock<IGeometriesValidator>();
            geometryValidatorMock.Setup(x => x.IsValidInput(row, column, It.IsAny<ModelStateDictionary>()))
                .Returns(false);
            _geometricLayoutController.GeometriesValidator = geometryValidatorMock.Object;
            _geometricLayoutController.ModelStateDictionary = new ModelStateDictionary()
            {
                {
                    "InvalidRow", new ModelState()
                }
            };

            //Act
            IHttpActionResult result = _geometricLayoutController.GetCoordinates(row, column);

            // Assert
            Assert.IsTrue((((InvalidModelStateResult)result).ModelState.Keys).Count > 0);
            Assert.IsTrue((((InvalidModelStateResult)result).ModelState.Keys.First().Contains("InvalidRow")));
        }

        [TestMethod]
        public void GetCoordinates_UnsupportedColumn_ReturnsInvalidColumnMessageInBadRequest()
        {
            //Arrange
            string row = "a";
            int column = 123;

            var geometryValidatorMock = new Mock<IGeometriesValidator>();
            geometryValidatorMock.Setup(x => x.IsValidInput(row, column, It.IsAny<ModelStateDictionary>()))
                .Returns(false);
            _geometricLayoutController.GeometriesValidator = geometryValidatorMock.Object;
            _geometricLayoutController.ModelStateDictionary = new ModelStateDictionary()
            {
                {
                    "InvalidColumn", new ModelState()
                }
            };

            //Act
            IHttpActionResult result = _geometricLayoutController.GetCoordinates(row, column);

            // Assert
            Assert.IsTrue((((InvalidModelStateResult)result).ModelState.Keys).Count > 0);
            Assert.IsTrue((((InvalidModelStateResult)result).ModelState.Keys.First().Contains("InvalidColumn")));
        }

        [TestMethod]
        public void GetCoordinates_UnsupportedRowAndColumn_ReturnsInvalidRowAndColumnMessageInBadRequest()
        {
            //Arrange
            string row = "abc";
            int column = 123;

            var geometryValidatorMock = new Mock<IGeometriesValidator>();
            geometryValidatorMock.Setup(x => x.IsValidInput(row, column, It.IsAny<ModelStateDictionary>()))
                .Returns(false);
            _geometricLayoutController.GeometriesValidator = geometryValidatorMock.Object;
            _geometricLayoutController.ModelStateDictionary = new ModelStateDictionary()
            {
                {
                    "InvalidColumn", new ModelState()
                },
                {
                    "InvalidRow", new ModelState()
                }
            };

            //Act
            IHttpActionResult result = _geometricLayoutController.GetCoordinates(row, column);

            // Assert
            Assert.IsTrue((((InvalidModelStateResult)result).ModelState.Keys).Count > 0);
            Assert.IsTrue((((InvalidModelStateResult)result).ModelState.Keys.First().Contains("InvalidColumn")));
            Assert.IsTrue((((InvalidModelStateResult)result).ModelState.Keys.Last().Contains("InvalidRow")));
        }

        [TestMethod]
        public void GetCoordinates_ExceptionWhileProcessInProgress_ReturnsInternalServerError()
        {
            //Arrange
            string row = "a";
            int column = 1;
            var expectedErrorMessage = "Unknown error occurred.";

            var geometryValidatorMock = new Mock<IGeometriesValidator>();
            geometryValidatorMock.Setup(x => x.IsValidInput(row, column, It.IsAny<ModelStateDictionary>()))
                .Throws(new Exception(expectedErrorMessage));
            _geometricLayoutController.GeometriesValidator = geometryValidatorMock.Object;

            //Act
            IHttpActionResult result = _geometricLayoutController.GetCoordinates(row, column);

            // Assert
            Assert.IsTrue(((ExceptionResult)result).Exception.Message.Contains(expectedErrorMessage));
        }
        #endregion

        #region GetTriangleLocation Tests
        [TestMethod]
        public void GetTriangleLocation_ValidCoordinates_ReturnsTriangleLocation()
        {
            foreach (var geometry in GeometricLayoutControllerTestHelper.Geometries)
            {
                string row = geometry.Key.ToUpper();
                foreach (var columnVsCoordinates in geometry.Value)
                {
                    //Arrange
                    string expectedData = row + columnVsCoordinates.Key;

                    //IGeometriesValidator Mock
                    var geometryValidatorMock = new Mock<IGeometriesValidator>();
                    geometryValidatorMock.Setup(x => x.AreCoordinatesValidToFormTriangle(columnVsCoordinates.Value, It.IsAny<ModelStateDictionary>()))
                        .Returns(true);
                    _geometricLayoutController.GeometriesValidator = geometryValidatorMock.Object;

                    //IGeometriesProcessor Mock
                    var geometriesProcessorMock = new Mock<IGeometriesProcessor>();
                    geometriesProcessorMock.Setup(x => x.GetTrianglePosition(columnVsCoordinates.Value))
                        .Returns(expectedData);
                    _geometricLayoutController.GeometriesValidator = geometryValidatorMock.Object;

                    //ModelStateDictionary
                    _geometricLayoutController.ModelStateDictionary = new ModelStateDictionary();


                    //Act
                    IHttpActionResult result = _geometricLayoutController.GetTriangleLocation(columnVsCoordinates.Value);
                    var actualLocation = ((OkNegotiatedContentResult<string>)result).Content;

                    // Assert
                    Assert.IsTrue(actualLocation.Contains(expectedData));
                }
            }
        }

        [TestMethod]
        public void GetTriangleLocation_InValidCoordinates_ReturnsInvalidCoordinateInBadRequest()
        {
            //Arrange
            var geometryValidatorMock = new Mock<IGeometriesValidator>();
            geometryValidatorMock.Setup(x => x.AreCoordinatesValidToFormTriangle(new List<Coordinates>(), It.IsAny<ModelStateDictionary>()))
                .Returns(false);
            _geometricLayoutController.GeometriesValidator = geometryValidatorMock.Object;
            _geometricLayoutController.ModelStateDictionary = new ModelStateDictionary()
            {
                {
                    "InvalidCoordinate", new ModelState()
                }
            };

            //Act
            IHttpActionResult result = _geometricLayoutController.GetTriangleLocation(new List<Coordinates>());

            // Assert
            Assert.IsTrue((((InvalidModelStateResult)result).ModelState.Keys).Count > 0);
            Assert.IsTrue((((InvalidModelStateResult)result).ModelState.Keys.First().Contains("InvalidCoordinate")));
        }

        [TestMethod]
        public void GetTriangleLocation_ExceptionWhileCalculatingLocation_ReturnsInternalServerError()
        {
            //Arrange
            var expectedErrorMessage = "Unknown error occurred.";

            var geometryValidatorMock = new Mock<IGeometriesValidator>();
            geometryValidatorMock.Setup(x => x.AreCoordinatesValidToFormTriangle(new List<Coordinates>(), It.IsAny<ModelStateDictionary>()))
                .Throws(new Exception(expectedErrorMessage));
            _geometricLayoutController.GeometriesValidator = geometryValidatorMock.Object;

            //Act
            IHttpActionResult result = _geometricLayoutController.GetTriangleLocation(new List<Coordinates>());

            // Assert
            Assert.IsTrue(((ExceptionResult)result).Exception.Message.Contains(expectedErrorMessage));
        } 
        #endregion
    }
}
