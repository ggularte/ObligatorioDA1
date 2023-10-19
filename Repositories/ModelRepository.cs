using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ModelRepository : IModelRepository
    {
        public void AddModel(Model model)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                Client dbClient = dbContext.Clients.Find(model.ModelOwnerId);
                if (dbClient != null)
                {
                    model.ModelOwner = dbClient;

                    Figure dbFigure = dbContext.Figures.FirstOrDefault(f => f.FigureName == model.ModelFigureName && f.FigureOwner.Username == model.ModelFigureOwnerId);
                    if (dbFigure != null)
                    {
                        model.ModelFigure = dbFigure;
                    }

                    Material dbMaterial = dbContext.Materials.FirstOrDefault(m => m.MaterialName == model.ModelMaterialName && m.MaterialOwner.Username == model.ModelMaterialOwnerId);
                    if (dbMaterial != null)
                    {
                        model.ModelMaterial = dbMaterial;
                    }

                    dbContext.Models.Add(model);
                    dbContext.SaveChanges();
                }
            }
        }

        public List<Model> GetAllModels()
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                return dbContext.Models.ToList();
            }
        }

        public void DeleteModel(Model model)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                var entry = dbContext.Entry(model);

                if (entry.State == EntityState.Detached)
                {
                    dbContext.Models.Attach(model);
                }

                dbContext.Models.Remove(model);
                dbContext.SaveChanges();
            }
        }

        public Model GetModel(Client owner, string modelName)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                Model returnModel = null;
                Client dbClient = dbContext.Clients.Find(owner.Username);
                if (dbClient != null)
                {
                    returnModel = dbContext.Models.FirstOrDefault(m => m.ModelName == modelName && m.ModelOwner.Username == owner.Username);
                    if (returnModel != null)
                    {
                        dbContext.Entry(returnModel).Reference(m => m.ModelFigure).Load();
                        dbContext.Entry(returnModel).Reference(m => m.ModelMaterial).Load();
                    }
                }
                return returnModel;
            }
        }

        public bool ExistFigureInModel(Client figureOwner, Figure figure)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                Model returnModel = null;
                bool exist = false;
                Client dbClient = dbContext.Clients.Find(figureOwner.Username);
                if (dbClient != null)
                {
                    returnModel = dbContext.Models.FirstOrDefault(m => m.ModelFigureName == figure.FigureName && m.ModelOwner.Username == figureOwner.Username);
                }
                if (returnModel != null)
                {
                    exist = true;
                }
                return exist;
            }
        }

        public bool ExistMaterialInModel(Client materialOwner, Material material)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                Model returnModel = null;
                bool exist = false;
                Client dbClient = dbContext.Clients.Find(materialOwner.Username);
                if (dbClient != null)
                {
                    returnModel = dbContext.Models.FirstOrDefault(m => m.ModelMaterialName == material.MaterialName && m.ModelOwner.Username == materialOwner.Username);
                }
                if (returnModel != null)
                {
                    exist = true;
                }
                return exist;
            }
        }
    }
}
