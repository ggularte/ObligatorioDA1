using Domain;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers
{
    public class SceneDriver
    {
        private readonly SceneRepository sceneRepository;

        public SceneDriver()
        {
            this.sceneRepository = new SceneRepository();
        }

        public void AddScene(Scene scene)
        {
            sceneRepository.AddScene(scene);
        }

        public void DeleteScene(Scene scene)
        {
            sceneRepository.DeleteScene(scene);
        }

        public List<Scene> GetAllScenes()
        {
            return sceneRepository.GetAllScenes();
        }

        public void AddPositionedModel(PositionatedModel positionedModel, Scene scene)
        {
            sceneRepository.AddPositionedModel(positionedModel, scene);
        }

        public List<PositionatedModel> GetPositionedModels(Scene scene)
        {
            return sceneRepository.GetPositionedModels(scene);
        }

        public void RemovePositionedModel(int modelId, Scene scene)
        {
            sceneRepository.RemovePositionedModel(modelId, scene);
        }

        public Scene GetScene(Client sceneOwner, string sceneName)
        {
            return sceneRepository.GetScene(sceneOwner, sceneName);
        }

        public bool ExistModelInScene(Client modelOwner, Model model)
        {
            return sceneRepository.ExistModelInScene(modelOwner, model);
        }

        public void UpdateScene(Scene scene, string oldSceneName)
        {
            sceneRepository.UpdateScene(scene, oldSceneName);
        }
    }
}
