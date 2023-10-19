using Domain;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers
{
    public class ModelDriver
    {
        private ModelRepository modelRepository;

        public ModelDriver()
        {
            this.modelRepository = new ModelRepository();
        }

        public void AddModel(Model model)
        {
            modelRepository.AddModel(model);
        }

        public void DeleteModel(Model model)
        {
            modelRepository.DeleteModel(model);
        }

        public List<Model> GetAllModels()
        {
            return modelRepository.GetAllModels();
        }

        public Model GetModel(Client owner, string modelName)
        {
            return modelRepository.GetModel(owner, modelName);
        }

        public bool ExistFigureInModel(Client figureOwner, Figure figure)
        {
            return modelRepository.ExistFigureInModel(figureOwner, figure);
        }

        public bool ExistMaterialInModel(Client materialOwner, Material material)
        {
            return modelRepository.ExistMaterialInModel(materialOwner, material);
        }
    }
}
