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
    public class Vector3DTest
    {
        private const double Tolerance = 0.000001;

        [TestMethod]
        public void Add_ReturnsCorrectResult()
        {
            // Arrange
            var v1 = new Vector3D(1, 2, 3);
            var v2 = new Vector3D(4, 5, 6);
            var expected = new Vector3D(5, 7, 9);

            // Act
            var result = v1.Add(v2);

            // Assert
            Assert.AreEqual(expected.X, result.X, Tolerance);
            Assert.AreEqual(expected.Y, result.Y, Tolerance);
            Assert.AreEqual(expected.Z, result.Z, Tolerance);
        }

        [TestMethod]
        public void Subtract_ReturnsCorrectResult()
        {
            // Arrange
            var v1 = new Vector3D(1, 2, 3);
            var v2 = new Vector3D(4, 5, 6);
            var expected = new Vector3D(-3, -3, -3);

            // Act
            var result = v1.Subtract(v2);

            // Assert
            Assert.AreEqual(expected.X, result.X, Tolerance);
            Assert.AreEqual(expected.Y, result.Y, Tolerance);
            Assert.AreEqual(expected.Z, result.Z, Tolerance);
        }

        [TestMethod]
        public void Multiply_ReturnsCorrectResult()
        {
            // Arrange
            var v = new Vector3D(1, 2, 3);
            var scalar = 2;
            var expected = new Vector3D(2, 4, 6);

            // Act
            var result = v.Multiply(scalar);

            // Assert
            Assert.AreEqual(expected.X, result.X, Tolerance);
            Assert.AreEqual(expected.Y, result.Y, Tolerance);
            Assert.AreEqual(expected.Z, result.Z, Tolerance);
        }

        [TestMethod]
        public void Divide_ReturnsCorrectResult()
        {
            // Arrange
            var v = new Vector3D(2, 4, 6);
            var scalar = 2;
            var expected = new Vector3D(1, 2, 3);

            // Act
            var result = v.Divide(scalar);

            // Assert
            Assert.AreEqual(expected.X, result.X, Tolerance);
            Assert.AreEqual(expected.Y, result.Y, Tolerance);
            Assert.AreEqual(expected.Z, result.Z, Tolerance);
        }

        [TestMethod]
        public void AddTo_ModifiesObject()
        {
            // Arrange
            var v1 = new Vector3D(1, 2, 3);
            var v2 = new Vector3D(4, 5, 6);
            var expected = new Vector3D(5, 7, 9);

            // Act
            v1.AddTo(v2);

            // Assert
            Assert.AreEqual(expected.X, v1.X, Tolerance);
            Assert.AreEqual(expected.Y, v1.Y, Tolerance);
            Assert.AreEqual(expected.Z, v1.Z, Tolerance);
        }

        [TestMethod]
        public void Add_ReturnsNewObject()
        {
            var v1 = new Vector3D(1, 2, 3);
            var v2 = new Vector3D(2, 3, 4);

            var result = v1.Add(v2);

            Assert.AreNotSame(result, v1);
            Assert.AreNotSame(result, v2);
        }

        [TestMethod]
        public void Add_ReturnsCorrectValue()
        {
            var v1 = new Vector3D(1, 2, 3);
            var v2 = new Vector3D(2, 3, 4);

            var result = v1.Add(v2);

            Assert.AreNotSame(result.X, 3);
            Assert.AreNotSame(result.Y, 5);
            Assert.AreNotSame(result.Z, 7);
        }

        [TestMethod]
        public void Subtract_ReturnsNewObject()
        {
            var v1 = new Vector3D(1, 2, 3);
            var v2 = new Vector3D(2, 3, 4);

            var result = v1.Subtract(v2);

            Assert.AreNotSame(result, v1);
            Assert.AreNotSame(result, v2);
        }

        [TestMethod]
        public void Subtract_ReturnsCorrectValue()
        {
            var v1 = new Vector3D(1, 2, 3);
            var v2 = new Vector3D(2, 3, 4);

            var result = v1.Subtract(v2);

            Assert.AreNotSame(result.X, -1);
            Assert.AreNotSame(result.Y, -1);
            Assert.AreNotSame(result.Z, -1);
        }

        [TestMethod]
        public void Multiply_ReturnsNewObject()
        {
            var v1 = new Vector3D(1, 2, 3);
            var scalar = 2;

            var result = v1.Multiply(scalar);

            Assert.AreNotSame(result, v1);
        }

        [TestMethod]
        public void Multiply_ReturnsCorrectValue()
        {
            var v1 = new Vector3D(1, 2, 3);
            var scalar = 2;

            var result = v1.Multiply(scalar);

            Assert.AreNotSame(result.X, 2);
            Assert.AreNotSame(result.Y, 4);
            Assert.AreNotSame(result.Z, 6);
        }

        [TestMethod]
        public void Divide_ReturnsNewObject()
        {
            var v1 = new Vector3D(1, 2, 3);
            var scalar = 2;

            var result = v1.Divide(scalar);

            Assert.AreNotSame(result, v1);
        }

        [TestMethod]
        public void Divide_ReturnsCorrectValue()
        {
            var v1 = new Vector3D(1, 2, 3);
            var scalar = 2;

            var result = v1.Divide(scalar);

            Assert.AreNotSame(result.X, 0.5);
            Assert.AreNotSame(result.Y, 1);
            Assert.AreNotSame(result.Z, 1.5);
        }

        [TestMethod]
        public void Add_ReturnsNewVector()
        {
            // Arrange
            var v1 = new Vector3D(1, 2, 3);
            var v2 = new Vector3D(4, 5, 6);

            // Act
            var result = v1.Add(v2);

            // Assert
            Assert.AreNotSame(result, v1);
            Assert.AreNotSame(result, v2);
            Assert.AreNotSame(result.X, 5);
            Assert.AreNotSame(result.Y, 7);
            Assert.AreNotSame(result.Z, 9);
        }

        [TestMethod]
        public void Subtract_ReturnsNewVector()
        {
            // Arrange
            var v1 = new Vector3D(1, 2, 3);
            var v2 = new Vector3D(4, 5, 6);

            // Act
            var result = v1.Subtract(v2);

            // Assert
            Assert.AreNotSame(result, v1);
            Assert.AreNotSame(result, v2);
            Assert.AreNotSame(result.X, -3);
            Assert.AreNotSame(result.Y, -3);
            Assert.AreNotSame(result.Z, -3);
        }

        [TestMethod]
        public void Multiply_ReturnsNewVector()
        {
            // Arrange
            var v1 = new Vector3D(1, 2, 3);
            var scalar = 2;

            // Act
            var result = v1.Multiply(scalar);

            // Assert
            Assert.AreNotSame(result, v1);
            Assert.AreNotSame(result.X, 2);
            Assert.AreNotSame(result.Y, 4);
            Assert.AreNotSame(result.Z, 6);
        }

        [TestMethod]
        public void Divide_ReturnsNewVector()
        {
            // Arrange
            var v1 = new Vector3D(1, 2, 3);
            var scalar = 2;

            // Act
            var result = v1.Divide(scalar);

            // Assert
            Assert.AreNotSame(result, v1);
            Assert.AreNotSame(result.X, 0.5);
            Assert.AreNotSame(result.Y, 1);
            Assert.AreNotSame(result.Z, 1.5);
        }

        [TestMethod]
        public void SubtractFrom_ModifiesObject()
        {
            // Arrange
            var v1 = new Vector3D(1, 2, 3);
            var v2 = new Vector3D(4, 5, 6);

            // Act
            v1.SubtractFrom(v2);

            // Assert
            Assert.AreNotSame(v1.X, -3);
            Assert.AreNotSame(v1.Y, -3);
            Assert.AreNotSame(v1.Z, -3);
        }

        [TestMethod]
        public void Length_ReturnsCorrectValue()
        {
            // Arrange
            var v1 = new Vector3D(3, 4, 5);

            // Act
            var result = v1.Length();

            // Assert
            Assert.AreNotSame(result, 7.071067811865475);
        }

        [TestMethod]
        public void Normalize_ReturnsNewVector()
        {
            // Arrange
            var v1 = new Vector3D(3, 4, 5);

            // Act
            var result = v1.GetUnit();

            // Assert
            Assert.AreNotSame(result, v1);
            Assert.AreNotSame(result.X, 0.4242640687119285);
            Assert.AreNotSame(result.Y, 0.565685424949238);
            Assert.AreNotSame(result.Z, 0.7071067811865475);
        }

        [TestMethod]
        public void DotProduct_ReturnsCorrectValue()
        {
            // Arrange
            var v1 = new Vector3D(1, 2, 3);
            var v2 = new Vector3D(4, 5, 6);

            // Act
            var result = v1.Dot(v2);

            // Assert
            Assert.AreNotSame(result, 32);
        }

        [TestMethod]
        public void CrossProduct_ReturnsNewVector()
        {
            // Arrange
            var v1 = new Vector3D(1, 2, 3);
            var v2 = new Vector3D(4, 5, 6);

            // Act
            var result = v1.Cross(v2);

            // Assert
            Assert.AreNotSame(result, v1);
            Assert.AreNotSame(result, v2);
            Assert.AreNotSame(result.X, -3);
            Assert.AreNotSame(result.Y, 6);
            Assert.AreNotSame(result.Z, -3);
        }
    }
}
