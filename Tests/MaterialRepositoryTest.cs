using Domain;
using Drivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class MaterialRepositoryTest
    {
        [TestCleanup]
        public void CleanUp()
        {
            using (RepositoryContext dbContext = new RepositoryContext())
            {
                dbContext.Clients.RemoveRange(dbContext.Clients);
                dbContext.Figures.RemoveRange(dbContext.Figures);
                dbContext.Materials.RemoveRange(dbContext.Materials);
                dbContext.Models.RemoveRange(dbContext.Models);
                dbContext.PositionatedModels.RemoveRange(dbContext.PositionatedModels);
                dbContext.Scenes.RemoveRange(dbContext.Scenes);
                dbContext.SaveChanges();
            }
        }

        [TestMethod]
        public void TestAddMaterialToClient()
        {
            var client = new Client
            {
                Username = "username1"
            };
            var material = new Material
            {
                MaterialName = "Test",
                MaterialOwnerId = client.Username,
                MaterialOwner = client
            };
            var repository1 = new ClientRepository();
            var repository2 = new MaterialRepository();

            repository1.AddClient(client);
            repository2.AddMaterial(material);

            Material dbMaterial = repository2.GetMaterial(client, material.MaterialName);
            Assert.IsTrue(material.MaterialName == dbMaterial.MaterialName);
        }

        [TestMethod]
        public void TestAddLambertianMaterialToClient()
        {
            var client = new Client
            {
                Username = "username1"
            };
            var material = new LambertianMaterial
            {
                MaterialName = "TestLambertianMaterial",
                MaterialOwnerId = client.Username,
                MaterialOwner = client
            };
            var repository1 = new ClientRepository();
            var repository2 = new MaterialRepository();

            repository1.AddClient(client);
            repository2.AddMaterial(material);

            Material dbMaterial = repository2.GetMaterial(client, material.MaterialName);
            bool isLambertian = false;
            if(dbMaterial is LambertianMaterial)
            {
                isLambertian = true;
            }
            Assert.IsTrue(isLambertian);
        }

        [TestMethod]
        public void TestAddMetalicMaterialToClient()
        {
            var client = new Client
            {
                Username = "username1"
            };
            var material = new MetalicMaterial
            {
                MaterialName = "TestLambertianMaterial",
                MaterialOwnerId = client.Username,
                MaterialOwner = client,
                Difuminated = 0
            };
            var repository1 = new ClientRepository();
            var repository2 = new MaterialRepository();

            repository1.AddClient(client);
            repository2.AddMaterial(material);

            Material dbMaterial = repository2.GetMaterial(client, material.MaterialName);
            bool isMetalic = false;
            if (dbMaterial is MetalicMaterial)
            {
                isMetalic = true;
            }
            Assert.IsTrue(isMetalic);
        }

        [TestMethod]
        public void AddsMultipleMaterials()
        {
            var client = new Client
            {
                Username = "username1"
            };
            var material1 = new Material
            {
                MaterialName = "Test1",
                MaterialOwnerId = client.Username,
                MaterialOwner = client
            };
            var material2 = new Material
            {
                MaterialName = "Test2",
                MaterialOwnerId = client.Username,
                MaterialOwner = client
            };
            var repository1 = new ClientRepository();
            var repository2 = new MaterialRepository();

            repository1.AddClient(client);
            repository2.AddMaterial(material1);
            repository2.AddMaterial(material2);

            Material dbMaterial1 = repository2.GetMaterial(client, material1.MaterialName);
            Assert.IsTrue(material1.MaterialName == dbMaterial1.MaterialName);
            Material dbMaterial2 = repository2.GetMaterial(client, material2.MaterialName);
            Assert.IsTrue(material2.MaterialName == dbMaterial2.MaterialName);
        }

        [TestMethod]
        public void GetMaterialByMaterialName_WhenMaterialExists_ReturnsMaterial()
        {
            var client = new Client
            {
                Username = "username1"
            };
            var material = new Material
            {
                MaterialName = "materialName",
                MaterialOwnerId = client.Username,
                MaterialOwner = client
            };

            var repository1 = new ClientRepository();
            var repository2 = new MaterialRepository();

            repository1.AddClient(client);
            repository2.AddMaterial(material);

            Material dbMaterial = repository2.GetMaterial(client, "materialName");
            Assert.IsTrue("materialName" == dbMaterial.MaterialName);
        }

        [TestMethod]
        public void GetMaterialByMaterialName_WhenMaterialNotExists_ReturnsNull()
        {
            var client = new Client
            {
                Username = "username1"
            };

            var repository1 = new ClientRepository();
            var repository2 = new MaterialRepository();

            repository1.AddClient(client);

            Material dbMaterial = repository2.GetMaterial(client, "materialName");
            Assert.IsNull(dbMaterial);
        }

        [TestMethod]
        public void TestDeleteMaterial()
        {
            var client = new Client
            {
                Username = "username1"
            };
            var material = new Material
            {
                MaterialName = "Test",
                MaterialOwnerId = client.Username,
                MaterialOwner = client
            };
            var repository1 = new ClientRepository();
            var repository2 = new MaterialRepository();

            repository1.AddClient(client);
            repository2.AddMaterial(material);

            Material dbMaterialAdd = repository2.GetMaterial(client, material.MaterialName);
            Assert.IsTrue(material.MaterialName == dbMaterialAdd.MaterialName);

            repository2.DeleteMaterial(material);
            Material dbMaterialDelete = repository2.GetMaterial(client, material.MaterialName);
            Assert.IsTrue(dbMaterialDelete == null);
        }

        [TestMethod]
        public void TestGetMaterials()
        {
            var repository = new MaterialRepository();
            var materials = repository.GetAllMaterials();

            Assert.IsNotNull(materials);
            Assert.AreEqual(0, materials.Count);
        }
    }
}
