using Domain;
using Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers
{
    public class MaterialDriver
    {
        private MaterialRepository materialRepository;

        public MaterialDriver()
        {
            materialRepository = new MaterialRepository();
        }

        public void AddMaterial(Material material)
        {
            materialRepository.AddMaterial(material);
        }

        public void DeleteMaterial(Material material)
        {
            materialRepository.DeleteMaterial(material);
        }

        public List<Material> GetAllMaterials()
        {
            return materialRepository.GetAllMaterials();
        }

        public Material GetMaterial(Client owner, string materialName)
        {
            return materialRepository.GetMaterial(owner, materialName);
        }
    }
}
