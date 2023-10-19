using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.GraphicEngine;

namespace Tests
{
    [TestClass]
    public class GraphicEngineTest
    {
        [TestMethod]
        public void GetRandom_ReturnsValueBetweenZeroAndOne()
        {
            // Arrange
            Random random = new Random();
            RandomProvider randomProvider = new RandomProvider(false, random);

            // Act
            double result = randomProvider.getRandom();

            // Assert
            Assert.IsTrue(result >= 0 && result <= 1);
        }

        [TestMethod]
        public void GetRandom_ReturnsFixedValueWhenReturnFixedIsTrue()
        {
            // Arrange
            Random random = new Random();
            RandomProvider randomProvider = new RandomProvider(true, random);

            // Act
            double result = randomProvider.getRandom();

            // Assert
            Assert.AreEqual(result, 0.5);
        }

        private GraphicEngine engine;

        [TestInitialize]
        public void Setup()
        {
            Random random = new Random();
            engine = new GraphicEngine(new RandomProvider(false, random));
        }


        [TestMethod]
        public void IsSphereLambertianHit_RayDoesNotHitSphere_ReturnsNull()
        {
            // Arrange
            Sphere sphere = new Sphere(new Vector3D(0, 0, -1), 0.5, new Vector3D(0.1, 0.2, 0.3), "lambertian");
            Ray ray = new Ray(new Vector3D(0, 0, 0), new Vector3D(0, 1, 0));

            // Act
            var result = GraphicEngine.IsSphereHit(sphere, ray, 0, double.MaxValue);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsSphereMetalicHit_RayDoesNotHitSphere_ReturnsNull()
        {
            // Arrange
            Sphere sphere = new Sphere(new Vector3D(0, 0, -1), 0.5, new Vector3D(0.1, 0.2, 0.3), "metalic");
            Ray ray = new Ray(new Vector3D(0, 0, 0), new Vector3D(0, 1, 0));

            // Act
            var result = GraphicEngine.IsSphereHit(sphere, ray, 0, double.MaxValue);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestOriginValueOldVersion()
        {
            Vector3D lookFrom = new Vector3D(0, 0, 0);
            Vector3D lookAt = new Vector3D(0, 0, -1);
            Vector3D up = new Vector3D(0, 1, 0);
            int fov = 90;
            double aspectRatio = 16.0 / 9.0;

            Camera camera = new Camera(lookFrom, lookAt, up, fov, aspectRatio, "old");

            Assert.AreEqual(lookFrom, camera._origin);
        }

        [TestMethod]
        public void TestOriginValueNewVersion()
        {
            Vector3D lookFrom = new Vector3D(0, 0, 0);
            Vector3D lookAt = new Vector3D(0, 0, -1);
            Vector3D up = new Vector3D(0, 1, 0);
            int fov = 90;
            double aspectRatio = 16.0 / 9.0;

            Camera camera = new Camera(lookFrom, lookAt, up, fov, aspectRatio, "old");

            Assert.AreEqual(lookFrom, camera._origin);
        }

        [TestMethod]
        public void TestGetRandomInUnitSphere()
        {
            // Arrange

            // Act
            Vector3D result = engine.GetRandomInUnitSphere();

            // Assert
            Assert.IsTrue(result.X >= -1 && result.X <= 1);
            Assert.IsTrue(result.Y >= -1 && result.Y <= 1);
            Assert.IsTrue(result.Z >= -1 && result.Z <= 1);
            Assert.IsTrue(result.SquaredLength() < 1);
        }
    }
}
