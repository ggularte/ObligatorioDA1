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
    public class ModelRepositoryTest
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
        public void TestAddModelToClient()
        {
            var client = new Client
            {
                Username = "username1"
            };

            var figure = new Figure
            {
                FigureName = "figureTest",
                FigureOwnerId = client.Username,
                FigureOwner = client,
                Radio = 1
            };

            var material = new Material
            {
                MaterialName = "materialTest",
                MaterialOwnerId = client.Username,
                MaterialOwner = client
            };

            var model = new Model
            {
                ModelName = "modelTest",
                ModelOwnerId = client.Username,
                ModelOwner = client,
                ModelFigureOwnerId = client.Username,
                ModelFigureName = figure.FigureName,
                ModelMaterialOwnerId = client.Username,
                ModelMaterialName = material.MaterialName
            };

            var repository1 = new ClientRepository();
            var repository2 = new FigureRepository();
            var repository3 = new MaterialRepository();
            var repository4 = new ModelRepository();

            repository1.AddClient(client);
            repository2.AddFigure(figure);
            repository3.AddMaterial(material);
            repository4.AddModel(model);

            Model dbModel = repository4.GetModel(client, model.ModelName);
            Assert.IsTrue(model.ModelName == dbModel.ModelName);
        }

        [TestMethod]
        public void AddsMultipleModels()
        {
            var client = new Client
            {
                Username = "username1"
            };

            var figure = new Figure
            {
                FigureName = "figureTest",
                FigureOwnerId = client.Username,
                FigureOwner = client,
                Radio = 1
            };

            var material = new Material
            {
                MaterialName = "materialTest",
                MaterialOwnerId = client.Username,
                MaterialOwner = client
            };

            var model1 = new Model
            {
                ModelName = "modelTest1",
                ModelOwnerId = client.Username,
                ModelOwner = client,
                ModelFigureOwnerId = client.Username,
                ModelFigureName = figure.FigureName,
                ModelMaterialOwnerId = client.Username,
                ModelMaterialName = material.MaterialName
            };
            var model2 = new Model
            {
                ModelName = "modelTest2",
                ModelOwnerId = client.Username,
                ModelOwner = client,
                ModelFigureOwnerId = client.Username,
                ModelFigureName = figure.FigureName,
                ModelMaterialOwnerId = client.Username,
                ModelMaterialName = material.MaterialName
            };

            var repository1 = new ClientRepository();
            var repository2 = new FigureRepository();
            var repository3 = new MaterialRepository();
            var repository4 = new ModelRepository();

            repository1.AddClient(client);
            repository2.AddFigure(figure);
            repository3.AddMaterial(material);
            repository4.AddModel(model1);
            repository4.AddModel(model2);

            Model dbModel1 = repository4.GetModel(client, model1.ModelName);
            Assert.IsTrue(model1.ModelName == dbModel1.ModelName);
            Model dbModel2 = repository4.GetModel(client, model2.ModelName);
            Assert.IsTrue(model2.ModelName == dbModel2.ModelName);
        }

        [TestMethod]
        public void GetModelByModelName_WhenModelExists_ReturnsFigure()
        {
            var client = new Client
            {
                Username = "username1"
            };

            var figure = new Figure
            {
                FigureName = "figureTest",
                FigureOwnerId = client.Username,
                FigureOwner = client,
                Radio = 1
            };

            var material = new Material
            {
                MaterialName = "materialTest",
                MaterialOwnerId = client.Username,
                MaterialOwner = client
            };

            var model = new Model
            {
                ModelName = "modelName",
                ModelOwnerId = client.Username,
                ModelOwner = client,
                ModelFigureOwnerId = client.Username,
                ModelFigureName = figure.FigureName,
                ModelMaterialOwnerId = client.Username,
                ModelMaterialName = material.MaterialName
            };

            var repository1 = new ClientRepository();
            var repository2 = new FigureRepository();
            var repository3 = new MaterialRepository();
            var repository4 = new ModelRepository();

            repository1.AddClient(client);
            repository2.AddFigure(figure);
            repository3.AddMaterial(material);
            repository4.AddModel(model);

            Model dbModel = repository4.GetModel(client, "modelName");
            Assert.IsTrue("modelName" == dbModel.ModelName);
        }

        [TestMethod]
        public void GetModelByModelName_WhenModelNotExists_ReturnsNull()
        {
            var client = new Client
            {
                Username = "username1"
            };

            var repository1 = new ClientRepository();
            var repository2 = new ModelRepository();

            repository1.AddClient(client);

            Model dbModel = repository2.GetModel(client, "modelName");
            Assert.IsNull(dbModel);
        }

        [TestMethod]
        public void TestDeleteModel()
        {
            var client = new Client
            {
                Username = "username1"
            };

            var figure = new Figure
            {
                FigureName = "figureTest",
                FigureOwnerId = client.Username,
                FigureOwner = client,
                Radio = 1
            };

            var material = new Material
            {
                MaterialName = "materialTest",
                MaterialOwnerId = client.Username,
                MaterialOwner = client
            };

            var model = new Model
            {
                ModelName = "modelTest",
                ModelOwnerId = client.Username,
                ModelOwner = client,
                ModelFigureOwnerId = client.Username,
                ModelFigureName = figure.FigureName,
                ModelMaterialOwnerId = client.Username,
                ModelMaterialName = material.MaterialName
            };

            var repository1 = new ClientRepository();
            var repository2 = new FigureRepository();
            var repository3 = new MaterialRepository();
            var repository4 = new ModelRepository();

            repository1.AddClient(client);
            repository2.AddFigure(figure);
            repository3.AddMaterial(material);
            repository4.AddModel(model);

            Model dbModelAdd = repository4.GetModel(client, model.ModelName);
            Assert.IsTrue(model.ModelName == dbModelAdd.ModelName);

            repository4.DeleteModel(model);
            Model dbModelDelete = repository4.GetModel(client, material.MaterialName);
            Assert.IsTrue(dbModelDelete == null);
        }

        [TestMethod]
        public void TestGetModels()
        {
            var repository = new ModelRepository();
            var models = repository.GetAllModels();

            Assert.IsNotNull(models);
            Assert.AreEqual(0, models.Count);
        }

        [TestMethod]
        public void ExistFigureInModel_FigureInModelExists_ReturnsTrue()
        {
            var client = new Client
            {
                Username = "username1"
            };

            var figure = new Figure
            {
                FigureName = "figureTest",
                FigureOwnerId = client.Username,
                FigureOwner = client,
                Radio = 1
            };

            var material = new Material
            {
                MaterialName = "materialTest",
                MaterialOwnerId = client.Username,
                MaterialOwner = client
            };

            var model = new Model
            {
                ModelName = "modelTest",
                ModelOwnerId = client.Username,
                ModelOwner = client,
                ModelFigureOwnerId = client.Username,
                ModelFigureName = figure.FigureName,
                ModelMaterialOwnerId = client.Username,
                ModelMaterialName = material.MaterialName
            };

            var repository1 = new ClientRepository();
            var repository2 = new FigureRepository();
            var repository3 = new MaterialRepository();
            var repository4 = new ModelRepository();

            repository1.AddClient(client);
            repository2.AddFigure(figure);
            repository3.AddMaterial(material);
            repository4.AddModel(model);

            var result = repository4.ExistFigureInModel(client, figure);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ExistFigureInModel_FigureInModelDoesNotExist_ReturnsFalse()
        {
            var client = new Client
            {
                Username = "username1"
            };

            var figure1 = new Figure
            {
                FigureName = "figureTest",
                FigureOwnerId = client.Username,
                FigureOwner = client,
                Radio = 1
            };

            var figure2 = new Figure
            {
                FigureName = "figureTestNotInModel",
                FigureOwnerId = client.Username,
                FigureOwner = client,
                Radio = 1
            };

            var material = new Material
            {
                MaterialName = "materialTest",
                MaterialOwnerId = client.Username,
                MaterialOwner = client
            };

            var model = new Model
            {
                ModelName = "modelTest",
                ModelOwnerId = client.Username,
                ModelOwner = client,
                ModelFigureOwnerId = client.Username,
                ModelFigureName = figure1.FigureName,
                ModelMaterialOwnerId = client.Username,
                ModelMaterialName = material.MaterialName
            };

            var repository1 = new ClientRepository();
            var repository2 = new FigureRepository();
            var repository3 = new MaterialRepository();
            var repository4 = new ModelRepository();

            repository1.AddClient(client);
            repository2.AddFigure(figure1);
            repository2.AddFigure(figure2);
            repository3.AddMaterial(material);
            repository4.AddModel(model);

            var result = repository4.ExistFigureInModel(client, figure2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ExistMaterialInModel_MaterialInModelExists_ReturnsTrue()
        {
            var client = new Client
            {
                Username = "username1"
            };

            var figure = new Figure
            {
                FigureName = "figureTest",
                FigureOwnerId = client.Username,
                FigureOwner = client,
                Radio = 1
            };

            var material = new Material
            {
                MaterialName = "materialTest",
                MaterialOwnerId = client.Username,
                MaterialOwner = client
            };

            var model = new Model
            {
                ModelName = "modelTest",
                ModelOwnerId = client.Username,
                ModelOwner = client,
                ModelFigureOwnerId = client.Username,
                ModelFigureName = figure.FigureName,
                ModelMaterialOwnerId = client.Username,
                ModelMaterialName = material.MaterialName
            };

            var repository1 = new ClientRepository();
            var repository2 = new FigureRepository();
            var repository3 = new MaterialRepository();
            var repository4 = new ModelRepository();

            repository1.AddClient(client);
            repository2.AddFigure(figure);
            repository3.AddMaterial(material);
            repository4.AddModel(model);

            var result = repository4.ExistMaterialInModel(client, material);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ExistMaterialInModel_MaterialInModelDoesNotExist_ReturnsFalse()
        {
            var client = new Client
            {
                Username = "username1"
            };

            var figure = new Figure
            {
                FigureName = "figureTest",
                FigureOwnerId = client.Username,
                FigureOwner = client,
                Radio = 1
            };

            var material1 = new Material
            {
                MaterialName = "materialTest",
                MaterialOwnerId = client.Username,
                MaterialOwner = client
            };

            var material2 = new Material
            {
                MaterialName = "materialTestNotExistInModel",
                MaterialOwnerId = client.Username,
                MaterialOwner = client
            };

            var model = new Model
            {
                ModelName = "modelTest",
                ModelOwnerId = client.Username,
                ModelOwner = client,
                ModelFigureOwnerId = client.Username,
                ModelFigureName = figure.FigureName,
                ModelMaterialOwnerId = client.Username,
                ModelMaterialName = material1.MaterialName
            };

            var repository1 = new ClientRepository();
            var repository2 = new FigureRepository();
            var repository3 = new MaterialRepository();
            var repository4 = new ModelRepository();

            repository1.AddClient(client);
            repository2.AddFigure(figure);
            repository3.AddMaterial(material1);
            repository3.AddMaterial(material2);
            repository4.AddModel(model);

            var result = repository4.ExistMaterialInModel(client, material2);

            Assert.IsFalse(result);
        }
    }
}
