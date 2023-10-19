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
    public class ModelTest
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
        public void ModelNameValidations_NullName_ThrowsException()
        {
            // Arrange
            Model modelo = new Model();
            string modelName = null;


            // Act & Assert
            Assert.ThrowsException<InvalidModelNameException>(() => modelo.ModelName = modelName);
        }

        [TestMethod]
        public void ModelNameValidations_EmptyName_ThrowsException()
        {
            // Arrange
            Model modelo = new Model();
            string modelName = "";


            // Act & Assert
            Assert.ThrowsException<InvalidModelNameException>(() => modelo.ModelName = modelName);
        }

        [TestMethod]
        public void ModelNameValidations_WhiteSpaceName_ThrowsException()
        {
            // Arrange
            Model modelo = new Model();
            string modelName = "   ";

            // Act & Assert
            Assert.ThrowsException<InvalidModelNameException>(() => modelo.ModelName = modelName);
        }

        [TestMethod]
        public void ModelNameValidations_NameWithLeadingWhiteSpace_ThrowsException()
        {
            // Arrange
            Model modelo = new Model();
            string modelName = "  Test";

            // Act & Assert
            Assert.ThrowsException<InvalidModelNameException>(() => modelo.ModelName = modelName);
        }

        [TestMethod]
        public void ModelNameValidations_NameWithTrailingWhiteSpace_ThrowsException()
        {
            // Arrange
            Model modelo = new Model();
            string modelName = "Test  ";

            // Act & Assert
            Assert.ThrowsException<InvalidModelNameException>(() => modelo.ModelName = modelName);
        }

        [TestMethod]
        public void ModelNameValidations_ValidName_DoesNotThrowException()
        {
            // Arrange
            Model modelo = new Model();
            string modelName = "Test";

            // Act
            modelo.ModelName = modelName;

            // Assert
            Assert.AreEqual(modelName, modelo.ModelName);
        }

        [TestMethod]
        public void ModelNameValidations_ValidNameWithInnerWhiteSpace_DoesNotThrowException()
        {
            // Arrange
            Model modelo = new Model();
            string modelName = "Test Model";

            // Act & Assert
            modelo.ModelName = modelName;
        }

        [TestMethod]
        public void ModelNameValidations_ValidNameWithSpecialCharacters_DoesNotThrowException()
        {
            // Arrange
            Model modelo = new Model();
            string modelName = "Test.Model-123";

            // Act & Assert
            modelo.ModelName = modelName;
        }


        [TestMethod]
        public void SetName_WhenNameContainsNumbers_ShouldSetName()
        {
            // Arrange
            var modelo = new Model
            {
                // Act
                ModelName = "Modelo 123"
            };

            // Assert
            Assert.AreEqual("Modelo 123", modelo.ModelName);
        }

        [TestMethod]
        public void ModelNameValidations_ThrowsException_WhenModelNameHasLeadingOrTrailingSpaces()
        {
            // Arrange
            string modelName = " Modelo ";
            Model modelo = new Model();

            // Act and Assert
            Assert.ThrowsException<InvalidModelNameException>(() => modelo.ModelName = modelName);
        }

        [TestMethod]
        public void SetName_WhenNameContainsLowerCaseCharacters_ShouldSetName()
        {
            // Arrange
            var modelo = new Model { ModelName = "modeloLowerCase" };

            // Assert
            Assert.AreEqual("modeloLowerCase", modelo.ModelName);
        }

        [TestMethod]
        public void SetName_WhenNameContainsUpperCaseCharacters_ShouldSetName()
        {
            // Arrange
            var modelo = new Model
            {
                // Act
                ModelName = "ModeloUpperCase"
            };

            // Assert
            Assert.AreEqual("ModeloUpperCase", modelo.ModelName);
        }
    }
}
