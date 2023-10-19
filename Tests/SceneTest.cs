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
    public class SceneTest
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
        public void SceneNameValidations_NullName_ThrowsException()
        {
            // Arrange
            Scene escena = new Scene();
            string sceneName = null;


            // Act & Assert
            Assert.ThrowsException<InvalidSceneNameException>(() => escena.SceneName = sceneName);
        }

        [TestMethod]
        public void SceneNameValidations_EmptyName_ThrowsException()
        {
            // Arrange
            Scene escena = new Scene();
            string sceneName = "";


            // Act & Assert
            Assert.ThrowsException<InvalidSceneNameException>(() => escena.SceneName = sceneName);
        }

        [TestMethod]
        public void SceneNameValidations_WhiteSpaceName_ThrowsException()
        {
            // Arrange
            Scene escena = new Scene();
            string sceneName = "   ";

            // Act & Assert
            Assert.ThrowsException<InvalidSceneNameException>(() => escena.SceneName = sceneName);
        }

        [TestMethod]
        public void SceneNameValidations_NameWithLeadingWhiteSpace_ThrowsException()
        {
            // Arrange
            Scene escena = new Scene();
            string sceneName = "  Test";

            // Act & Assert
            Assert.ThrowsException<InvalidSceneNameException>(() => escena.SceneName = sceneName);
        }

        [TestMethod]
        public void SceneNameValidations_NameWithTrailingWhiteSpace_ThrowsException()
        {
            // Arrange
            Scene escena = new Scene();
            string sceneName = "Test  ";

            // Act & Assert
            Assert.ThrowsException<InvalidSceneNameException>(() => escena.SceneName = sceneName);
        }

        [TestMethod]
        public void SceneNameValidations_ValidName_DoesNotThrowException()
        {
            // Arrange
            Scene escena = new Scene();
            string sceneName = "Test";

            // Act
            escena.SceneName = sceneName;

            // Assert
            Assert.AreEqual(sceneName, escena.SceneName);
        }

        [TestMethod]
        public void SceneNameValidations_ValidNameWithInnerWhiteSpace_DoesNotThrowException()
        {
            // Arrange
            Scene escena = new Scene();
            string sceneName = "Test Scene";

            // Act & Assert
            escena.SceneName = sceneName;
        }

        [TestMethod]
        public void SceneNameValidations_ValidNameWithSpecialCharacters_DoesNotThrowException()
        {
            // Arrange
            Scene escena = new Scene();
            string sceneName = "Test.Scene-123";

            // Act & Assert
            escena.SceneName = sceneName;
        }


        [TestMethod]
        public void SetName_WhenNameContainsNumbers_ShouldSetName()
        {
            // Arrange
            var scene = new Scene
            {
                // Act
                SceneName = "Escena 123"
            };

            // Assert
            Assert.AreEqual("Escena 123", scene.SceneName);
        }

        [TestMethod]
        public void SceneNameValidations_ThrowsException_WhenSceneNameHasLeadingOrTrailingSpaces()
        {
            // Arrange
            string sceneName = " Scene ";
            Scene escena = new Scene();

            // Act and Assert
            Assert.ThrowsException<InvalidSceneNameException>(() => escena.SceneName = sceneName);
        }

        [TestMethod]
        public void SetName_WhenNameContainsLowerCaseCharacters_ShouldSetName()
        {
            // Arrange
            var scene = new Scene { SceneName = "escenaLowerCase" };

            // Assert
            Assert.AreEqual("escenaLowerCase", scene.SceneName);
        }

        [TestMethod]
        public void SetName_WhenNameContainsUpperCaseCharacters_ShouldSetName()
        {
            // Arrange
            var scene = new Scene
            {
                // Act
                SceneName = "EcenaUpperCase"
            };

            // Assert
            Assert.AreEqual("EcenaUpperCase", scene.SceneName);
        }
    }
}
