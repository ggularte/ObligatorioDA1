using Domain;
using Drivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class FigureDriverTest
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
        public void TestAddFigureToClient()
        {
            var client = new Client
            {
                Username = "username1"
            };
            var figure = new Figure
            {
                FigureName = "Test",
                FigureOwnerId = client.Username,
                FigureOwner = client,
                Radio = 1
            };
            var repository1 = new ClientDriver();
            var repository2 = new FigureDriver();

            repository1.AddClient(client);
            repository2.AddFigure(figure);

            Figure dbFigure = repository2.GetFigure(client, figure.FigureName);
            Assert.IsTrue(figure.FigureName == dbFigure.FigureName);
        }

        [TestMethod]
        public void AddsMultipleFigures()
        {
            var client = new Client
            {
                Username = "username1"
            };
            var figure1 = new Figure
            {
                FigureName = "Test1",
                FigureOwnerId = client.Username,
                FigureOwner = client,
                Radio = 1
            };
            var figure2 = new Figure
            {
                FigureName = "Test2",
                FigureOwnerId = client.Username,
                FigureOwner = client,
                Radio = 1
            };
            var repository1 = new ClientDriver();
            var repository2 = new FigureDriver();

            repository1.AddClient(client);
            repository2.AddFigure(figure1);
            repository2.AddFigure(figure2);

            Figure dbFigure1 = repository2.GetFigure(client, figure1.FigureName);
            Assert.IsTrue(figure1.FigureName == dbFigure1.FigureName);
            Figure dbFigure2 = repository2.GetFigure(client, figure2.FigureName);
            Assert.IsTrue(figure2.FigureName == dbFigure2.FigureName);
        }

        [TestMethod]
        public void GetFigureByFigureName_WhenFigureExists_ReturnsFigure()
        {
            var client = new Client
            {
                Username = "username1"
            };
            var figure = new Figure
            {
                FigureName = "figureName",
                FigureOwnerId = client.Username,
                FigureOwner = client,
                Radio = 1
            };
            var repository1 = new ClientDriver();
            var repository2 = new FigureDriver();

            repository1.AddClient(client);
            repository2.AddFigure(figure);

            Figure dbFigure = repository2.GetFigure(client, "figureName");
            Assert.IsTrue("figureName" == dbFigure.FigureName);
        }

        [TestMethod]
        public void GetMaterialByMaterialName_WhenMaterialNotExists_ReturnsNull()
        {
            var client = new Client
            {
                Username = "username1"
            };

            var repository1 = new ClientDriver();
            var repository2 = new FigureDriver();

            repository1.AddClient(client);

            Figure dbFigure = repository2.GetFigure(client, "figureName");
            Assert.IsNull(dbFigure);
        }

        [TestMethod]
        public void TestDeleteFigure()
        {
            var client = new Client
            {
                Username = "username1"
            };
            var figure = new Figure
            {
                FigureName = "Test",
                FigureOwnerId = client.Username,
                FigureOwner = client,
                Radio = 1
            };
            var repository1 = new ClientDriver();
            var repository2 = new FigureDriver();

            repository1.AddClient(client);
            repository2.AddFigure(figure);

            Figure dbFigureAdd = repository2.GetFigure(client, figure.FigureName);
            Assert.IsTrue(figure.FigureName == dbFigureAdd.FigureName);

            repository2.DeleteFigure(figure);
            Figure dbFigureDelete = repository2.GetFigure(client, figure.FigureName);
            Assert.IsTrue(dbFigureDelete == null);
        }

        [TestMethod]
        public void TestGetFigures()
        {
            var repository = new FigureDriver();
            var figuras = repository.GetAllFigures();

            Assert.IsNotNull(figuras);
            Assert.AreEqual(0, figuras.Count);
        }
    }
}
