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
    public class FigureTests
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
        public void FigureNameValidations_ThrowsException_WhenFigureNameIsNullOrWhiteSpace()
        {
            // Arrange
            string figureName = "   ";
            Figure figura = new Figure();

            // Act and Assert
            Assert.ThrowsException<InvalidFigureNameException>(() => figura.FigureName = figureName);
        }

        [TestMethod]
        public void FigureNameValidations_ThrowsException_WhenFigureNameHasLeadingOrTrailingSpaces()
        {
            // Arrange
            string figureName = " Circle ";
            Figure figura = new Figure();

            // Act and Assert
            Assert.ThrowsException<InvalidFigureNameException>(() => figura.FigureName = figureName);
        }

        [TestMethod]
        public void FigureNameValidations_ThrowsException_WhenFigureNameHasLeadingSpaces()
        {
            // Arrange
            string figureName = " Circle";
            Figure figura = new Figure();

            // Act and Assert
            Assert.ThrowsException<InvalidFigureNameException>(() => figura.FigureName = figureName);
        }

        [TestMethod]
        public void FigureNameValidations_ThrowsException_WhenFigureNameHasTailSpaces()
        {
            // Arrange
            string figureName = "Circle ";
            Figure figura = new Figure();

            // Act and Assert
            Assert.ThrowsException<InvalidFigureNameException>(() => figura.FigureName = figureName);
        }

        [TestMethod]
        public void FigureNameValidations_DoesNotThrowException_WhenFigureNameIsValid()
        {
            // Arrange
            string figureName = "Circle";
            Figure figura = new Figure();

            // Act and Assert
            try
            {
                figura.FigureName = figureName;
            }
            catch (Exception)
            {
                Assert.Fail("Se ha producido una excepción.");
            }
        }

        [TestMethod]
        public void FigureRadioValidations_ThrowsException_WhenRadioIsZeroOrNegative()
        {
            // Arrange
            double radio = -1;
            Figure figura = new Figure();

            // Act and Assert
            Assert.ThrowsException<InvalidFigureRadioException>(() => figura.Radio = radio);
        }

        [TestMethod]
        public void FigureRadioValidations_DoesNotThrowException_WhenRadioIsValid()
        {
            // Arrange
            double radio = 1;
            Figure figura = new Figure();

            // Act and Assert
            try
            {
                figura.Radio = radio;
            }
            catch (Exception) { Assert.Fail("Se ha producido una excepción."); }
        }

        [TestMethod]
        public void ToString_ReturnsCorrectStringRepresentation()
        {
            // Arrange
            Figure figura = new Figure
            {
                FigureName = "Circle",
                Radio = 1
            };

            // Act
            string result = figura.ToString();

            // Assert
            Assert.AreEqual("Circle (Radio: 1)", result);
        }

        [TestMethod]
        public void FigureConstructor_SetsPropertiesToDefaultValues()
        {
            // Arrange and Act
            Figure figura = new Figure();

            // Assert
            Assert.AreEqual(null, figura.FigureName);
            Assert.AreEqual(0, figura.Radio);
        }

        [TestMethod]
        public void FigureConstructor_SetsPropertiesToProvidedValues()
        {
            // Arrange
            string figureName = "Circle";
            double radio = 1;

            // Act
            Figure figura = new Figure
            {
                FigureName = figureName,
                Radio = radio
            };

            // Assert
            Assert.AreEqual(figureName, figura.FigureName);
            Assert.AreEqual(radio, figura.Radio);
        }


        [TestMethod]
        public void FigureName_CanBeSetAndRetrieved()
        {
            // Arrange
            string figureName = "Sphere";
            Figure figura = new Figure
            {
                // Act
                FigureName = figureName
            };

            // Assert
            Assert.AreEqual(figureName, figura.FigureName);
        }

        [TestMethod]
        public void Radio_CanBeSetAndRetrieved()
        {
            // Arrange
            double radio = 2.5;
            Figure figura = new Figure
            {
                // Act
                Radio = radio
            };

            // Assert
            Assert.AreEqual(radio, figura.Radio);
        }

        [TestMethod]
        public void ToString_ReturnsCorrectStringRepresentationForSphere()
        {
            // Arrange
            double radio = 2.5;
            Figure figura = new Figure
            {
                FigureName = "Sphere",
                Radio = radio
            };

            // Act
            string result = figura.ToString();

            // Assert
            Assert.AreEqual($"Sphere (Radio: {radio})", result);
        }

        //aqui
        [TestMethod]
        public void SetName_WhenNameContainsLowerCaseCharacters_ShouldSetName()
        {
            // Arrange
            var figura = new Figure { FigureName = "figuraLowerCase" };

            // Assert
            Assert.AreEqual("figuraLowerCase", figura.FigureName);
        }

        [TestMethod]
        public void SetName_WhenNameContainsUpperCaseCharacters_ShouldSetName()
        {
            // Arrange
            var figura = new Figure { FigureName = "FiguraUpperCase" };

            // Assert
            Assert.AreEqual("FiguraUpperCase", figura.FigureName);
        }

        [TestMethod]
        public void SetName_WhenNameContainsNumbers_ShouldSetName()
        {
            // Arrange
            var figura = new Figure { FigureName = "Figura 123" };

            // Assert
            Assert.AreEqual("Figura 123", figura.FigureName);
        }

        [TestMethod]
        public void FigureNameValidations_ValidNameWithSpecialCharacters_DoesNotThrowException()
        {
            // Arrange
            Figure figura = new Figure();
            string figureName = "Test.Model-123";

            // Act & Assert
            figura.FigureName = figureName;
        }

        [TestMethod]
        public void SetName_WhenNameContainsAlphabetsOnly_ShouldSetName()
        {
            // Arrange
            var figura = new Figure
            {
                // Act
                FigureName = "MaterialOnlyAlphabets"
            };

            // Assert
            Assert.AreEqual("MaterialOnlyAlphabets", figura.FigureName);
        }
    }
}
