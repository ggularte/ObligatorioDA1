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
    public class FigureRepository : IFigureRepository
    {
        public void AddFigure(Figure figure)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                    Client dbClient = dbContext.Clients.Find(figure.FigureOwnerId);
                    if (dbClient != null)
                    {
                        figure.FigureOwner = dbClient;

                        dbContext.Figures.Add(figure);
                        dbContext.SaveChanges();
                    }
            }
        }

        public List<Figure> GetAllFigures()
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                return dbContext.Figures.ToList();
            }
        }

        public void DeleteFigure(Figure figure)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                var entry = dbContext.Entry(figure);

                if (entry.State == EntityState.Detached)
                {
                    dbContext.Figures.Attach(figure);
                }

                dbContext.Figures.Remove(figure);
                dbContext.SaveChanges();
            }
        }

        public Figure GetFigure(Client owner, string figureName)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                Figure returnFigure = null;
                Client dbClient = dbContext.Clients.Find(owner.Username);
                if (dbClient != null)
                {
                    returnFigure = dbContext.Figures.FirstOrDefault(f => f.FigureName == figureName && f.FigureOwner.Username == owner.Username);
                }
                return returnFigure;
            }
        }
    }
}
