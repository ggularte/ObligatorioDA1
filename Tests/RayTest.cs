using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class RayTest
    {
        [TestMethod]
        public void PointAt_ReturnsCorrectPoint()
        {
            // Arrange
            var origin = new Vector3D(1, 2, 3);
            var direction = new Vector3D(2, 0, 1);
            var ray = new Ray(origin, direction);

            // Act
            var result = ray.PointAt(2);

            // Assert
            Assert.AreEqual(result.X, 5);
            Assert.AreEqual(result.Y, 2);
            Assert.AreEqual(result.Z, 5);
        }

        [TestMethod]
        public void Origin_Setter_ModifiesOrigin()
        {
            // Arrange
            var origin = new Vector3D(1, 2, 3);
            var direction = new Vector3D(2, 0, 1);
            var ray = new Ray(origin, direction);
            var newOrigin = new Vector3D(4, 5, 6);

            // Act
            ray.Origin = newOrigin;

            // Assert
            Assert.AreEqual(ray.Origin, newOrigin);
        }

        [TestMethod]
        public void Direction_Setter_ModifiesDirection()
        {
            // Arrange
            var origin = new Vector3D(1, 2, 3);
            var direction = new Vector3D(2, 0, 1);
            var ray = new Ray(origin, direction);
            var newDirection = new Vector3D(1, 1, 1);

            // Act
            ray.Direction = newDirection;

            // Assert
            Assert.AreEqual(ray.Direction, newDirection);
        }
    }
}
