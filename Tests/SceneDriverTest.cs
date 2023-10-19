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
    public class SceneDriverTest
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
        public void AddScene_ShouldAddNewScene()
        {
            var client = new Client
            {
                Username = "username1"
            };

            var scene = new Scene
            {
                SceneName = "sceneTest",
                SceneOwnerId = client.Username,
                SceneOwner = client,
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var repository1 = new ClientDriver();
            var repository2 = new SceneDriver();

            repository1.AddClient(client);
            repository2.AddScene(scene);

            Scene dbScene = repository2.GetScene(client, scene.SceneName);
            Assert.IsTrue(scene.SceneName == dbScene.SceneName);
        }

        [TestMethod]
        public void AddsMultipleScenes()
        {
            var client = new Client
            {
                Username = "username1"
            };

            var scene1 = new Scene
            {
                SceneName = "sceneTest1",
                SceneOwnerId = client.Username,
                SceneOwner = client,
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var scene2 = new Scene
            {
                SceneName = "sceneTest2",
                SceneOwnerId = client.Username,
                SceneOwner = client,
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var repository1 = new ClientDriver();
            var repository2 = new SceneDriver();

            repository1.AddClient(client);
            repository2.AddScene(scene1);
            repository2.AddScene(scene2);

            Scene dbScene1 = repository2.GetScene(client, scene1.SceneName);
            Assert.IsTrue(scene1.SceneName == dbScene1.SceneName);
            Scene dbScene2 = repository2.GetScene(client, scene2.SceneName);
            Assert.IsTrue(scene2.SceneName == dbScene2.SceneName);
        }

        [TestMethod]
        public void GetSceneBySceneName_WhenSceneExists_ReturnsScene()
        {
            var client = new Client
            {
                Username = "username1"
            };

            var scene = new Scene
            {
                SceneName = "sceneName",
                SceneOwnerId = client.Username,
                SceneOwner = client,
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var repository1 = new ClientDriver();
            var repository2 = new SceneDriver();

            repository1.AddClient(client);
            repository2.AddScene(scene);

            Scene dbScene = repository2.GetScene(client, "sceneName");
            Assert.IsTrue("sceneName" == dbScene.SceneName);
        }

        [TestMethod]
        public void GetSceneBySceneName_WhenSceneNotExists_ReturnsNull()
        {
            var client = new Client
            {
                Username = "username1"
            };

            var repository1 = new ClientDriver();
            var repository2 = new SceneDriver();

            repository1.AddClient(client);

            Scene dbScene = repository2.GetScene(client, "sceneName");
            Assert.IsNull(dbScene);
        }

        [TestMethod]
        public void TestDeleteScene()
        {
            var client = new Client
            {
                Username = "username1"
            };

            var scene = new Scene
            {
                SceneName = "sceneTest",
                SceneOwnerId = client.Username,
                SceneOwner = client,
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var repository1 = new ClientDriver();
            var repository2 = new SceneDriver();

            repository1.AddClient(client);
            repository2.AddScene(scene);

            Scene dbSceneAdd = repository2.GetScene(client, scene.SceneName);
            Assert.IsTrue(scene.SceneName == dbSceneAdd.SceneName);

            repository2.DeleteScene(scene);
            Scene dbSceneRemove = repository2.GetScene(client, scene.SceneName);
            Assert.IsTrue(dbSceneRemove == null);
        }

        [TestMethod]
        public void TestGetScenes()
        {
            var repository = new SceneDriver();
            var scenes = repository.GetAllScenes();

            Assert.IsNotNull(scenes);
            Assert.AreEqual(0, scenes.Count);
        }

        [TestMethod]
        public void AddPositionedModel_ShouldAddNewPositionedModel()
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


            var scene = new Scene
            {
                SceneName = "sceneTest",
                SceneOwnerId = client.Username,
                SceneOwner = client,
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var positionatedModel = new PositionatedModel
            {
                BaseModel = model,
                ModelOwnerId = model.ModelOwnerId,
                ModelName = model.ModelName
            };

            var repository1 = new ClientDriver();
            var repository2 = new FigureDriver();
            var repository3 = new MaterialDriver();
            var repository4 = new ModelDriver();
            var repository5 = new SceneDriver();

            repository1.AddClient(client);
            repository2.AddFigure(figure);
            repository3.AddMaterial(material);
            repository4.AddModel(model);
            repository5.AddScene(scene);
            repository5.AddPositionedModel(positionatedModel, scene);

            var positionedModels = repository5.GetPositionedModels(scene);
            var isModelPositioned = positionedModels.Any(pm =>
                pm.ModelOwnerId == positionatedModel.ModelOwnerId &&
                pm.ModelName == positionatedModel.ModelName);

            Assert.IsTrue(isModelPositioned);
        }

        [TestMethod]
        public void AddsMultiplePositionedModels()
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


            var scene = new Scene
            {
                SceneName = "sceneTest",
                SceneOwnerId = client.Username,
                SceneOwner = client,
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var positionatedModel1 = new PositionatedModel
            {
                BaseModel = model,
                ModelOwnerId = model.ModelOwnerId,
                ModelName = model.ModelName
            };

            var positionatedModel2 = new PositionatedModel
            {
                BaseModel = model,
                ModelOwnerId = model.ModelOwnerId,
                ModelName = model.ModelName
            };

            var repository1 = new ClientDriver();
            var repository2 = new FigureDriver();
            var repository3 = new MaterialDriver();
            var repository4 = new ModelDriver();
            var repository5 = new SceneDriver();

            repository1.AddClient(client);
            repository2.AddFigure(figure);
            repository3.AddMaterial(material);
            repository4.AddModel(model);
            repository5.AddScene(scene);
            repository5.AddPositionedModel(positionatedModel1, scene);
            repository5.AddPositionedModel(positionatedModel2, scene);

            var positionedModels = repository5.GetPositionedModels(scene);
            var isModelPositioned1 = positionedModels.Any(pm =>
                pm.ModelOwnerId == positionatedModel1.ModelOwnerId &&
                pm.ModelName == positionatedModel1.ModelName);
            var isModelPositioned2 = positionedModels.Any(pm =>
                pm.ModelOwnerId == positionatedModel2.ModelOwnerId &&
                pm.ModelName == positionatedModel2.ModelName);

            Assert.IsTrue(isModelPositioned1);
            Assert.IsTrue(isModelPositioned2);
        }

        [TestMethod]
        public void TestDeletePositionedModel()
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


            var scene = new Scene
            {
                SceneName = "sceneTest",
                SceneOwnerId = client.Username,
                SceneOwner = client,
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var positionatedModel = new PositionatedModel
            {
                BaseModel = model,
                ModelOwnerId = model.ModelOwnerId,
                ModelName = model.ModelName
            };

            var repository1 = new ClientDriver();
            var repository2 = new FigureDriver();
            var repository3 = new MaterialDriver();
            var repository4 = new ModelDriver();
            var repository5 = new SceneDriver();

            repository1.AddClient(client);
            repository2.AddFigure(figure);
            repository3.AddMaterial(material);
            repository4.AddModel(model);
            repository5.AddScene(scene);
            repository5.AddPositionedModel(positionatedModel, scene);

            var positionedModelsAdd = repository5.GetPositionedModels(scene);
            var isModelPositionedAdd = positionedModelsAdd.Any(pm =>
                pm.ModelOwnerId == positionatedModel.ModelOwnerId &&
                pm.ModelName == positionatedModel.ModelName);

            Assert.IsTrue(isModelPositionedAdd);

            repository5.RemovePositionedModel(positionatedModel.PositionatedModelId, scene);
            var positionedModelsRemove = repository5.GetPositionedModels(scene);
            var isModelPositionedRemove = positionedModelsRemove.Any(pm =>
                pm.ModelOwnerId == positionatedModel.ModelOwnerId &&
                pm.ModelName == positionatedModel.ModelName);

            Assert.IsFalse(isModelPositionedRemove);
        }

        [TestMethod]
        public void ExistModelInScene_ModelInSceneExists_ReturnsTrue()
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

            var scene = new Scene
            {
                SceneName = "sceneTest",
                SceneOwnerId = client.Username,
                SceneOwner = client,
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var positionatedModel = new PositionatedModel
            {
                BaseModel = model,
                ModelOwnerId = model.ModelOwnerId,
                ModelName = model.ModelName
            };

            var repository1 = new ClientDriver();
            var repository2 = new FigureDriver();
            var repository3 = new MaterialDriver();
            var repository4 = new ModelDriver();
            var repository5 = new SceneDriver();

            repository1.AddClient(client);
            repository2.AddFigure(figure);
            repository3.AddMaterial(material);
            repository4.AddModel(model);
            repository5.AddScene(scene);
            repository5.AddPositionedModel(positionatedModel, scene);

            var result = repository5.ExistModelInScene(client, positionatedModel.BaseModel);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ExistModelInScene_ModelInSceneDoesNotExist_ReturnsFalse()
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

            var scene = new Scene
            {
                SceneName = "sceneTest",
                SceneOwnerId = client.Username,
                SceneOwner = client,
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var positionatedModel = new PositionatedModel
            {
                BaseModel = model,
                ModelOwnerId = model.ModelOwnerId,
                ModelName = model.ModelName
            };

            var repository1 = new ClientDriver();
            var repository2 = new FigureDriver();
            var repository3 = new MaterialDriver();
            var repository4 = new ModelDriver();
            var repository5 = new SceneDriver();

            repository1.AddClient(client);
            repository2.AddFigure(figure);
            repository3.AddMaterial(material);
            repository4.AddModel(model);
            repository5.AddScene(scene);

            var result = repository5.ExistModelInScene(client, positionatedModel.BaseModel);

            Assert.IsFalse(result);
        }
    }
}
