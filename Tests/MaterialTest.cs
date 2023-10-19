using Domain.Exceptions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;

namespace Tests
{
    [TestClass]
    public class MaterialTests
    {
        [TestCleanup]
        public void CleanUp()
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                dbContext.Clients.RemoveRange(dbContext.Clients);
                dbContext.Figures.RemoveRange(dbContext.Figures);
                dbContext.Materials.RemoveRange(dbContext.Materials);
                dbContext.Models.RemoveRange(dbContext.Models);
                dbContext.PositionatedModels.RemoveRange(dbContext.PositionatedModels);
                dbContext.Scenes.RemoveRange(dbContext.Scenes);
                dbContext.SaveChanges();
            }
        }

        [TestMethod]
        public void SetName_WhenNameIsNull_ShouldThrowInvalidMaterialNameException()
        {
            // Arrange
            var material = new Material();

            // Act
            void setNameAction() => material.MaterialName = null;

            // Assert
            Assert.ThrowsException<InvalidMaterialNameException>(setNameAction);
        }

        [TestMethod]
        public void FigureNameValidations_ThrowsException_WhenFigureNameHasLeadingOrTrailingSpaces()
        {
            // Arrange
            string materialName = " Material ";
            Material material = new Material();

            // Act and Assert
            Assert.ThrowsException<InvalidMaterialNameException>(() => material.MaterialName = materialName);
        }

        [TestMethod]
        public void SetName_WhenNameStartsWithSpace_ShouldThrowInvalidMaterialNameException()
        {
            // Arrange
            var material = new Material();

            // Act
            void setNameAction() => material.MaterialName = " Material";

            // Assert
            Assert.ThrowsException<InvalidMaterialNameException>(setNameAction);
        }

        [TestMethod]
        public void SetName_WhenNameEndsWithSpace_ShouldThrowInvalidMaterialNameException()
        {
            // Arrange
            var material = new Material();

            // Act
            void setNameAction() => material.MaterialName = "Material ";

            // Assert
            Assert.ThrowsException<InvalidMaterialNameException>(setNameAction);
        }

        [TestMethod]
        public void SetName_WhenNameContainsOnlySpaces_ShouldThrowInvalidMaterialNameException()
        {
            // Arrange
            var material = new Material();

            // Act
            void setNameAction() => material.MaterialName = "    ";

            // Assert
            Assert.ThrowsException<InvalidMaterialNameException>(setNameAction);
        }

        [TestMethod]
        public void SetName_WhenNameIsValid_ShouldSetName()
        {
            // Arrange
            var material = new Material
            {
                // Act
                MaterialName = "Material 1"
            };

            // Assert
            Assert.AreEqual("Material 1", material.MaterialName);
        }
        [TestMethod]
        public void MaterialNameValidations_DoesNotThrowException_WhenMaterialNameIsValid()
        {
            // Arrange
            string materialName = "Circle";
            Material material = new Material();

            // Act and Assert
            try
            {
                material.MaterialName = materialName;
            }
            catch (Exception)
            {
                Assert.Fail("Se ha producido una excepción.");
            }
        }
        [TestMethod]
        public void SetName_WhenNameContainsLowerCaseCharacters_ShouldSetName()
        {
            // Arrange
            var material = new Material { MaterialName = "materialLowerCase" };

            // Assert
            Assert.AreEqual("materialLowerCase", material.MaterialName);
        }

        [TestMethod]
        public void SetName_WhenNameContainsUpperCaseCharacters_ShouldSetName()
        {
            // Arrange
            var material = new Material
            {
                // Act
                MaterialName = "MaterialUpperCase"
            };

            // Assert
            Assert.AreEqual("MaterialUpperCase", material.MaterialName);
        }

        [TestMethod]
        public void SetName_WhenNameContainsNumbers_ShouldSetName()
        {
            // Arrange
            var material = new Material { MaterialName = "Material 123" };

            // Assert
            Assert.AreEqual("Material 123", material.MaterialName);
        }

        [TestMethod]
        public void MaterialNameValidations_ValidNameWithSpecialCharacters_DoesNotThrowException()
        {
            // Arrange
            Material material = new Material();
            string materialName = "Test.Model-123";

            // Act & Assert
            material.MaterialName = materialName;
        }

        [TestMethod]
        public void SetName_WhenNameContainsAlphabetsOnly_ShouldSetName()
        {
            // Arrange
            var material = new Material
            {
                // Act
                MaterialName = "MaterialOnlyAlphabets"
            };

            // Assert
            Assert.AreEqual("MaterialOnlyAlphabets", material.MaterialName);
        }
    }
}
