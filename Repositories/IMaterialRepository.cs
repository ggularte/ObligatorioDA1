using Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IMaterialRepository
    {
        void AddMaterial(Material material);

        void DeleteMaterial(Material material);

        List<Material> GetAllMaterials();

        Material GetMaterial(Client owner, string materialName);

    }
}
