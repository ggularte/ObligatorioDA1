using Domain;
using Drivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity.Infrastructure;
using System;
using Repositories;

namespace Tests
{
    [TestClass]
    public class ClientDriverTest
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
        public void AddClient_ShouldAddNewClient()
        {
            // Arrange
            var repository = new ClientDriver();
            var client = new Client
            {
                Username = "username"
            };

            // Act
            repository.AddClient(client);

            // Assert
            Client dbClient = repository.GetClientByUsername("username");
            Assert.IsTrue(client.Username == dbClient.Username);
        }

        [TestMethod]
        public void GetClientByUsername_WhenClientExists_ReturnsClient()
        {
            // Arrange
            var repository = new ClientDriver();
            var client = new Client
            {
                Username = "user1"
            };
            repository.AddClient(client);
            var username = "user1";

            // Act

            var result = repository.GetClientByUsername(username);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(username, result.Username);
        }

        [TestMethod]
        public void GetClientByUsername_WhenClientNotExists_ReturnsNull()
        {
            // Arrange
            var repository = new ClientDriver();

            // Act

            var result = repository.GetClientByUsername("user1");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void VerifyIdentity_ExistingClient_ReturnsTrue()
        {
            // Arrange
            string username = "alice";
            string password = "1234";
            Client client = new Client
            {
                Username = username,
                Password = password
            };
            var repository = new ClientDriver();
            repository.AddClient(client);

            // Act
            bool result = repository.VerifyIdentity(username, password);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void VerifyIdentity_NonExistingClient_ReturnsFalse()
        {
            // Arrange
            string username = "charlie";
            string password = "9999";
            var repository = new ClientDriver();

            // Act
            bool result = repository.VerifyIdentity(username, password);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void VerifyIdentity_EmptyUsername_ReturnsFalse()
        {
            // Arrange
            string username = "";
            string password = "5678";
            var repository = new ClientDriver();

            // Act
            bool result = repository.VerifyIdentity(username, password);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void VerifyIdentity_EmptyPassword_ReturnsFalse()
        {
            // Arrange
            string username = "bob";
            string password = "";
            var repository = new ClientDriver();

            // Act
            bool result = repository.VerifyIdentity(username, password);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestGetFiguresOfClient()
        {
            var cliente = new Client();
            var repository = new ClientDriver();
            var figuras = repository.GetFigures(cliente);

            Assert.IsNotNull(figuras);
            Assert.AreEqual(0, figuras.Count);
        }

        [TestMethod]
        public void GetFigures_ReturnsAllFiguresOfClient()
        {
            // Arrange
            var repository = new ClientDriver();
            var repository2 = new FigureDriver();
            var client = new Client { Username = "user1" };
            var figure1 = new Figure { FigureName = "Figure 1", Radio = 1 };
            var figure2 = new Figure { FigureName = "Figure 2", Radio = 1 };
            client.Figures.Add(figure1);
            client.Figures.Add(figure2);
            repository.AddClient(client);

            // Act
            var result = repository.GetFigures(client);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(repository2.GetFigure(client, figure1.FigureName) != null);
            Assert.IsTrue(repository2.GetFigure(client, figure2.FigureName) != null);
        }

        [TestMethod]
        public void TestGetMaterialsOfClient()
        {
            var cliente = new Client();
            var repository = new ClientDriver();


            var materiales = repository.GetMaterials(cliente);

            Assert.IsNotNull(materiales);
            Assert.AreEqual(0, materiales.Count);
        }

        [TestMethod]
        public void TestGetModelsOfClient()
        {
            var cliente = new Client();
            var repository = new ClientDriver();

            var modelos = repository.GetModels(cliente);

            Assert.IsNotNull(modelos);
            Assert.AreEqual(0, modelos.Count);
        }

        [TestMethod]
        public void TestGetScenesOfClient()
        {
            var cliente = new Client();
            var repository = new ClientDriver();

            var escenas = repository.GetModels(cliente);

            Assert.IsNotNull(escenas);
            Assert.AreEqual(0, escenas.Count);
        }
    }
}
