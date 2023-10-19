using Domain;
using Drivers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ListOfScenesView : UserControl
    {
        private SceneDriver sceneDriver;
        private ModelDriver modelDriver;
        private ClientDriver clientDriver;
        private MaterialDriver materialDriver;
        private MainPanel mainPanel;

        public ListOfScenesView(SceneDriver driverScene, ModelDriver driverModel, ClientDriver driverClient, MaterialDriver driverMaterial, MainPanel panelMain)
        {
            InitializeComponent();
            this.sceneDriver = driverScene;
            this.modelDriver = driverModel;
            this.clientDriver = driverClient;
            this.materialDriver = driverMaterial;
            this.mainPanel = panelMain;
        }

        private void btnAddNewScene_Click(object sender, EventArgs e)
        {
            LoadEditScene();
        }

        private void LoadEditScene()
        {
            DateTime now = DateTime.Now;
            string dateName = now.ToString("ddMMyyyy_HHmmss");
            Scene scene = new Scene()
            {
                SceneOwner = ClientPanel.usernameClient,
                SceneOwnerId = ClientPanel.usernameClient.Username,
                SceneName = $"Escena_{dateName}",
                ModifiedDate = now,
                CreationDate = now,
                FoV = 30,
                LastRender = null,
                LookAtX = 0,
                LookAtY = 2,
                LookAtZ = 5,
                LookFromX = 0,
                LookFromY = 2,
                LookFromZ = 0,
                ScenePreviewPath = "none",
                LensRadius = 0.1,
                PositionatedModels = new List<PositionatedModel>()
            };
            sceneDriver.AddScene(scene);
            this.Controls.Clear();
            UserControl userControl = new EditSceneView(sceneDriver, modelDriver, clientDriver, materialDriver, scene, mainPanel);
            this.Controls.Add(userControl);
        }

        private void ListOfScenesView_Load(object sender, EventArgs e)
        {
            LoadScenes();
        }

        private void LoadScenes()
        {
            List<Scene> scenes = clientDriver.GetScenes(ClientPanel.usernameClient);
            int y = 0;
            foreach (Scene scene in scenes)
            {
                SceneCustomControl customControl = new SceneCustomControl(sceneDriver, modelDriver, clientDriver, materialDriver, mainPanel);
                customControl.SceneName = scene.SceneName;
                customControl.LastModification = $"Última modificación: {scene.ModifiedDate.ToString("HH:mm - dd/MM/yyyy")}";
                if (!scene.ScenePreviewPath.Equals("none"))
                {
                    string fileName = scene.ScenePreviewPath;
                    customControl.LoadPreview(fileName);
                }
                pnlListOfScnenes.Controls.Add(customControl);
                customControl.Location = new Point(0, y);
                customControl.Width = pnlListOfScnenes.Width;
                y += customControl.Height;
            }
        }

        private void pnlListOfScnenes_ControlAdded(object sender, ControlEventArgs e)
        {
            pnlListOfScnenes.Dock = DockStyle.None;
        }
    }
}
