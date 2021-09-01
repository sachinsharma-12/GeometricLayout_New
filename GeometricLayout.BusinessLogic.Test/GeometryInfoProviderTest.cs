using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.ModelBinding;
using GeometricLayout.Common;
using GeometricLayout.Tests.Controllers;

namespace GeometricLayout.BusinessLogic.Test
{
    [TestClass]
    public class GeometryInfoProviderTest
    {
        #region IsEvenColumnTriangle tests
        [TestMethod]
        public void IsEvenColumnTriangle_AllEvenColumnTrianglesCoordinate_ReturnsTrue()
        {
            foreach (var geometry in GeometricLayoutControllerTestHelper.Geometries)
            {
                string row = geometry.Key;
                var evenColumnTriangleCoordinates = geometry.Value.Where(x => x.Key % 2 == 0);
                foreach (var columnVsCoordinates in evenColumnTriangleCoordinates)
                {
                    //Act
                    var isValid = GeometryInfoProvider.IsEvenColumnTriangle(columnVsCoordinates.Value);

                    // Assert
                    Assert.IsTrue(isValid);
                }
            }
        }

        [TestMethod]
        public void IsEvenColumnTriangle_NullCoordinate_ReturnsFalse()
        {
            //Act
            var isValid = GeometryInfoProvider.IsEvenColumnTriangle(null);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsEvenColumnTriangle_EmptyCoordinate_ReturnsFalse()
        {
            //Act
            var isValid = GeometryInfoProvider.IsEvenColumnTriangle(new List<Coordinates>());

            // Assert
            Assert.IsFalse(isValid);
        }

        #endregion

        #region IsOddColumnTriangle tests
        [TestMethod]
        public void IsOddColumnTriangle_AllOddColumnTrianglesCoordinate_ReturnsTrue()
        {
            foreach (var geometry in GeometricLayoutControllerTestHelper.Geometries)
            {
                string row = geometry.Key;
                var oddColumnTriangleCoordinates = geometry.Value.Where(x => x.Key % 2 != 0);
                foreach (var columnVsCoordinates in oddColumnTriangleCoordinates)
                {
                    //Act
                    var isValid = GeometryInfoProvider.IsOddColumnTriangle(columnVsCoordinates.Value);

                    // Assert
                    Assert.IsTrue(isValid);
                }
            }
        }

        [TestMethod]
        public void IsOddColumnTriangle_NullCoordinate_ReturnsFalse()
        {
            //Act
            var isValid = GeometryInfoProvider.IsOddColumnTriangle(null);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsOddColumnTriangle_EmptyCoordinate_ReturnsFalse()
        {
            //Act
            var isValid = GeometryInfoProvider.IsOddColumnTriangle(new List<Coordinates>());

            // Assert
            Assert.IsFalse(isValid);
        } 
        #endregion
    }
}
