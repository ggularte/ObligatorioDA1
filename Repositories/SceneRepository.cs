using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SceneRepository : ISceneRepository
    {
        public void AddScene(Scene scene)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                Client dbClient = dbContext.Clients.Find(scene.SceneOwnerId);
                if (dbClient != null)
                {
                    scene.SceneOwner = dbClient;

                    dbContext.Scenes.Add(scene);
                    dbContext.SaveChanges();
                }
            }
        }

        public void DeleteScene(Scene scene)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                var entry = dbContext.Entry(scene);

                if (entry.State == EntityState.Detached)
                {
                    dbContext.Scenes.Attach(scene);
                }

                var positionedModelsCopy = scene.PositionatedModels.ToList();

                foreach (var positionedModel in positionedModelsCopy)
                {
                    dbContext.PositionatedModels.Remove(positionedModel);
                }

                dbContext.Scenes.Remove(scene);
                dbContext.SaveChanges();
            }
        }

        public List<Scene> GetAllScenes()
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                return dbContext.Scenes.ToList();
            }
        }

        public void AddPositionedModel(PositionatedModel model, Scene aScene)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                Scene dbScene = dbContext.Scenes.Include("PositionatedModels").SingleOrDefault(s => s.SceneName == aScene.SceneName && s.SceneOwnerId == aScene.SceneOwnerId);
                if (dbScene != null)
                {
                    Client existingClient = dbContext.Clients.FirstOrDefault(c => c.Username == model.BaseModel.ModelOwner.Username);

                    if (existingClient != null)
                    {
                        Figure existingFigure = dbContext.Figures.FirstOrDefault(f => f.FigureName == model.BaseModel.ModelFigureName && f.FigureOwnerId == model.BaseModel.ModelFigureOwnerId);
                        Material existingMaterial = dbContext.Materials.FirstOrDefault(m => m.MaterialName == model.BaseModel.ModelMaterialName && m.MaterialOwnerId == model.BaseModel.ModelMaterialOwnerId);

                        if (existingFigure != null && existingMaterial != null)
                        {
                            model.BaseModel.ModelOwner = existingClient;
                            model.BaseModel.ModelFigure = existingFigure;
                            model.BaseModel.ModelMaterial = existingMaterial;

                            Model existingModel = dbContext.Models.FirstOrDefault(m => m.ModelName == model.BaseModel.ModelName && m.ModelOwnerId == model.BaseModel.ModelMaterialOwnerId);
                            if (existingModel != null)
                            {
                                model.BaseModel = existingModel;

                                dbScene.PositionatedModels.Add(model);

                                dbContext.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        public void RemovePositionedModel(int modelId, Scene aScene)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                Scene dbScene = dbContext.Scenes.Include("PositionatedModels").SingleOrDefault(s => s.SceneName == aScene.SceneName && s.SceneOwnerId == aScene.SceneOwnerId);
                if (dbScene != null)
                {
                    PositionatedModel positionatedModel = dbScene.PositionatedModels.SingleOrDefault(pm => pm.PositionatedModelId == modelId);
                    if (positionatedModel != null)
                    {
                        dbScene.PositionatedModels.Remove(positionatedModel);
                        dbContext.PositionatedModels.Remove(positionatedModel);

                        dbContext.SaveChanges();
                    }
                }
            }
        }

        public List<PositionatedModel> GetPositionedModels(Scene aScene)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                List<PositionatedModel> positionatedModels = new List<PositionatedModel>();
                Scene dbScene = dbContext.Scenes.FirstOrDefault(s => s.SceneName == aScene.SceneName && s.SceneOwner.Username == aScene.SceneOwnerId);
                if (dbScene != null)
                {
                    positionatedModels = dbScene.PositionatedModels.ToList();
                }
                return positionatedModels;
            }
        }

        public Scene GetScene(Client client, string sceneName)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                Scene returnScene = null;
                Client dbClient = dbContext.Clients.Find(client.Username);
                if (dbClient != null)
                {
                    returnScene = dbContext.Scenes.FirstOrDefault(s => s.SceneName == sceneName && s.SceneOwner.Username == client.Username);
                }
                return returnScene;
            }
        }

        public bool ExistModelInScene(Client modelOwner, Model model)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                bool isPositioned = dbContext.Scenes.Any(scene => scene.PositionatedModels.Any(m => m.ModelName == model.ModelName && m.ModelOwnerId == model.ModelOwnerId));
                return isPositioned;
            }
        }

        public void UpdateScene(Scene updatedScene, string oldSceneName)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                Scene existingScene = dbContext.Scenes
                   .Include(s => s.PositionatedModels)
                   .SingleOrDefault(s => s.SceneName == oldSceneName && s.SceneOwnerId == updatedScene.SceneOwnerId);

                if (existingScene != null)
                {
                    Client existingClient = dbContext.Clients.SingleOrDefault(c => c.Username == updatedScene.SceneOwnerId);

                    Scene newScene = new Scene
                    {
                        SceneOwner = existingClient,
                        SceneOwnerId = updatedScene.SceneOwnerId,
                        SceneName = updatedScene.SceneName,
                        ModifiedDate = updatedScene.ModifiedDate,
                        CreationDate = updatedScene.CreationDate,
                        FoV = updatedScene.FoV,
                        LastRender = updatedScene.LastRender,
                        LookAtX = updatedScene.LookAtX,
                        LookAtY = updatedScene.LookAtY,
                        LookAtZ = updatedScene.LookAtZ,
                        LookFromX = updatedScene.LookFromX,
                        LookFromY = updatedScene.LookFromY,
                        LookFromZ = updatedScene.LookFromZ,
                        ScenePreviewPath = updatedScene.ScenePreviewPath,
                        LensRadius = updatedScene.LensRadius,
                        Blur = updatedScene.Blur,
                        PositionatedModels = this.GetPositionedModels(existingScene)
                    };

                    var positionedModelsCopy = existingScene.PositionatedModels.ToList();

                    foreach (var positionedModel in positionedModelsCopy)
                    {
                        dbContext.PositionatedModels.Remove(positionedModel);
                    }

                    dbContext.Scenes.Remove(existingScene);

                    dbContext.Scenes.Add(newScene);

                    dbContext.SaveChanges();
                }
            }
        }
    }
}
