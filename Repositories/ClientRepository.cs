using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ClientRepository : IClientRepository
    {
        public void AddClient(Client client)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                dbContext.Clients.Add(client);

                dbContext.SaveChanges();
            }
        }

        public Client GetClientByUsername(string username)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                Client dbClient = dbContext.Clients.Find(username);
                return (Client)dbClient;
            }
        }

        public bool VerifyIdentity(string username, string password)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                bool verify = false;
                Client dbClient = dbContext.Clients.Find(username);
                if (dbClient != null)
                {
                    if (dbClient.Password.Equals(password))
                    {
                        verify = true;
                    }
                }
                return verify;
            }
        }

        public List<Figure> GetFigures(Client aClient)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                List<Figure> list = new List<Figure>();
                Client dbClient = dbContext.Clients.Find(aClient.Username);
                if (dbClient != null)
                {
                    list = (List<Figure>)dbClient.Figures;
                }
                return list;
            }
        }

        public List<Material> GetMaterials(Client aClient)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                List<Material> list = new List<Material>();
                Client dbClient = dbContext.Clients.Find(aClient.Username);
                if (dbClient != null)
                {
                    list = (List<Material>)dbClient.Materials;
                }
                return list;
            }
        }

        public List<Model> GetModels(Client aClient)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                List<Model> list = new List<Model>();
                Client dbClient = dbContext.Clients.Find(aClient.Username);
                if (dbClient != null)
                {
                    list = dbClient.Models.ToList();
                }
                return list;
            }
        }

        public List<Scene> GetScenes(Client aClient)
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                List<Scene> list = new List<Scene>();
                Client dbClient = dbContext.Clients.Find(aClient.Username);
                if (dbClient != null)
                {
                    list = (List<Scene>)dbClient.Scenes;
                }
                return list;
            }
        }
    }
}
