using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ISceneRepository
    {
        void AddScene(Scene scene);

        void DeleteScene(Scene scene);

        List<Scene> GetAllScenes();

        void AddPositionedModel(PositionatedModel model, Scene scene);

        void RemovePositionedModel(int modelId, Scene scene);

        List<PositionatedModel> GetPositionedModels(Scene scene);

        Scene GetScene(Client client, string sceneName);

        bool ExistModelInScene(Client modelOwner, Model model);

        void UpdateScene(Scene scene, string oldSceneName);
    }
}
