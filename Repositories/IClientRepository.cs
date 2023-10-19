using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IClientRepository
    {
        void AddClient(Client client);

        bool VerifyIdentity(string username, string password);

        Client GetClientByUsername(string username);

        List<Figure> GetFigures(Client client);

        List<Material> GetMaterials(Client client);

        List<Model> GetModels(Client client);

        List<Scene> GetScenes(Client client);
    }
}
