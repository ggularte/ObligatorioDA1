using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IModelRepository
    {
        void AddModel(Model model);

        void DeleteModel(Model model);

        List<Model> GetAllModels();

        Model GetModel(Client owner, string modelName);

        bool ExistFigureInModel(Client figureOwner, Figure figure);

        bool ExistMaterialInModel(Client materialOwner, Material material);
    }
}
