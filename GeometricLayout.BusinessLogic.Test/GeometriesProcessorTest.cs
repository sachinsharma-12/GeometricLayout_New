using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using GeometricLayout.Common;
using GeometricLayout.Tests.Controllers;

namespace GeometricLayout.BusinessLogic.Test
{
    [TestClass]
    public class GeometriesProcessorTest
    {
        #region GetTriangleCoordinate tests
        [TestMethod]
        public void GetTriangleCoordinates_AllValidRowColumnCombinations_ReturnsValidCoordinate()
        {
            var geometryProcessor = new GeometriesProcessor();

            foreach (var geometry in GeometricLayoutControllerTestHelper.Geometries)
            {
                string row = geometry.Key;
                foreach (var columnVsCoordinates in geometry.Value)
                {
                    //Act
                    var actualCoordinates = geometryProcessor.GetTriangleCoordinates(row, columnVsCoordinates.Key);

                    // Assert
                    Assert.IsTrue(actualCoordinates.Count == columnVsCoordinates.Value.Count);
                    foreach (var actualCoordinate in actualCoordinates)
                    {
                        Assert.IsTrue(columnVsCoordinates.Value.Contains(actualCoordinate));
                    }
                }
            }
        }

        [TestMethod]
        public void GetTriangleCoordinates_NonSupportedRow_ReturnsEmptyListOfCoordinate()
        {
            var geometryProcessor = new GeometriesProcessor();

            //Act
            var actualCoordinates = geometryProcessor.GetTriangleCoordinates("j", 1);

            // Assert
            Assert.IsTrue(actualCoordinates.Count == 0);
        }

        [TestMethod]
        public void GetTriangleCoordinates_NonSupportedColumn_ReturnsEmptyListOfCoordinate()
        {
            var geometryProcessor = new GeometriesProcessor();

            //Act
            var actualCoordinates = geometryProcessor.GetTriangleCoordinates("a", 15);

            // Assert
            Assert.IsTrue(actualCoordinates.Count == 0);
        }

        [TestMethod]
        public void GetTriangleCoordinates_NonSupportedRowAndColumn_ReturnsEmptyListOfCoordinate()
        {
            var geometryProcessor = new GeometriesProcessor();

            //Act
            var actualCoordinates = geometryProcessor.GetTriangleCoordinates("j", 18);

            // Assert
            Assert.IsTrue(actualCoordinates.Count == 0);
        }

        [TestMethod]
        public void GetTriangleCoordinates_NullRow_ReturnsEmptyListOfCoordinate()
        {
            var geometryProcessor = new GeometriesProcessor();

            //Act
            var actualCoordinates = geometryProcessor.GetTriangleCoordinates(null, 18);

            // Assert
            Assert.IsTrue(actualCoordinates.Count == 0);
        }
        #endregion


        [TestMethod]
        public void GetTrianglePosition_AllValidRowColumnCombinations_ReturnsValidRowColumn()
        {

            foreach (var geometry in GeometricLayoutControllerTestHelper.Geometries)
            {
                foreach (var columnVsCoordinates in geometry.Value)
                {
                    //Arrange
                    var geometryProcessor = new GeometriesProcessor();
                    string row = geometry.Key.ToUpper();
                    string expectedData = row + columnVsCoordinates.Key;

                    //Act
                    var actualRowColumn = geometryProcessor.GetTrianglePosition(columnVsCoordinates.Value);

                    // Assert
                    Assert.IsTrue(actualRowColumn.Contains(expectedData));
                }
            }
        }

        [TestMethod]
        public void GetTrianglePosition_NullCoordinates_ReturnsEmptyRowColumn()
        {
            //Arrange
            var geometryProcessor = new GeometriesProcessor();

            //Act
            var actualRowColumn = geometryProcessor.GetTrianglePosition(null);

            // Assert
            Assert.IsTrue(actualRowColumn.Equals(""));
        }

        [TestMethod]
        public void GetTrianglePosition_CoordinateInsideListIsNull_ReturnsEmptyRowColumn()
        {
            //Arrange
            var geometryProcessor = new GeometriesProcessor();

            //Act
            var actualRowColumn = geometryProcessor.GetTrianglePosition(new List<Coordinates>()
            {
                new Coordinates(1,2),null,null
            });

            // Assert
            Assert.IsTrue(actualRowColumn.Equals(""));
        }

        [TestMethod]
        public void GetTrianglePosition_EmptyListOfCoordinates_ReturnsEmptyRowAndColumn()
        {
            //Arrange
            var geometryProcessor = new GeometriesProcessor();

            //Act
            var actualRowColumn = geometryProcessor.GetTrianglePosition(new List<Coordinates>()
            {
            });

            // Assert
            Assert.IsTrue(actualRowColumn.Equals(""));
        }
    }
}
