using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class MaterialRepository : IMaterialRepository
    {

        public void AddMaterial(Material material)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                Client dbClient = dbContext.Clients.Find(material.MaterialOwnerId);
                if (dbClient != null)
                {
                    material.MaterialOwner = dbClient;

                    dbContext.Materials.Add(material);
                    dbContext.SaveChanges();
                }
            }
        }

        public void DeleteMaterial(Material material)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                var entry = dbContext.Entry(material);

                if (entry.State == EntityState.Detached)
                {
                    dbContext.Materials.Attach(material);
                }

                dbContext.Materials.Remove(material);
                dbContext.SaveChanges();
            }
        }

        public List<Material> GetAllMaterials()
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                return dbContext.Materials.ToList();
            }
        }

        public Material GetMaterial(Client owner, string materialName)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                Material returnMaterial = null;
                Client dbClient = dbContext.Clients.Find(owner.Username);
                if (dbClient != null)
                {
                    returnMaterial = dbContext.Materials.FirstOrDefault(m => m.MaterialName == materialName && m.MaterialOwner.Username == owner.Username);
                }
                return returnMaterial;
            }
        }
    }
}
