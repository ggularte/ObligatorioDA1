using Domain;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers
{
    public class ClientDriver
    {
        private ClientRepository clientRepository;

        public ClientDriver()
        {
            clientRepository = new ClientRepository();
        }

        public void AddClient(Client client)
        {
            clientRepository.AddClient(client);
        }

        public bool VerifyIdentity(string username, string password)
        {
            return clientRepository.VerifyIdentity(username, password);
        }

        public Client GetClientByUsername(string username)
        {
            return clientRepository.GetClientByUsername(username);
        }

        public List<Figure> GetFigures(Client client)
        {
            return clientRepository.GetFigures(client);
        }

        public List<Material> GetMaterials(Client client)
        {
            return clientRepository.GetMaterials(client);
        }

        public List<Model> GetModels(Client client)
        {
            return clientRepository.GetModels(client);
        }

        public List<Scene> GetScenes(Client client)
        {
            return clientRepository.GetScenes(client);
        }
    }
}
