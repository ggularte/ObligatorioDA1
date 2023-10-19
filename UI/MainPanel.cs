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
    public partial class MainPanel : Form
    {
        private FigureDriver figureDriver;
        private MaterialDriver materialDriver;
        private ModelDriver modelDriver;
        private SceneDriver sceneDriver;
        private ClientDriver clientDriver;

        public MainPanel(FigureDriver driverFigure, MaterialDriver driverMaterial, ModelDriver driverModel, SceneDriver driverScene, ClientDriver driverClient)
        {
            InitializeComponent();
            this.figureDriver = driverFigure;
            this.materialDriver = driverMaterial;
            this.modelDriver = driverModel;
            this.sceneDriver = driverScene;
            this.clientDriver = driverClient;
            LoadFigures();

        }

        private void btnFigures_Click(object sender, EventArgs e)
        {
            LoadFigures();
        }

        private void btnMaterials_Click(object sender, EventArgs e)
        {
            LoadMaterials();
        }

        private void btnModels_Click(object sender, EventArgs e)
        {
            LoadModels();
        }

        private void btnScenes_Click(object sender, EventArgs e)
        {
            LoadScenes();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            LoadSignin();
        }

        private void LoadFigures()
        {
            currentView.Controls.Clear();
            UserControl userControl = new ListOfFiguresView(figureDriver, clientDriver, modelDriver);
            currentView.Controls.Add(userControl);
        }

        private void LoadMaterials()
        {
            currentView.Controls.Clear();
            UserControl userControl = new ListOfMaterialsView(materialDriver, clientDriver, modelDriver);
            currentView.Controls.Add(userControl);
        }

        private void LoadModels()
        {
            currentView.Controls.Clear();
            UserControl userControl = new ListOfModelsView(modelDriver, figureDriver, materialDriver, clientDriver, sceneDriver);
            currentView.Controls.Add(userControl);
        }

        private void LoadScenes()
        {
            currentView.Controls.Clear();
            UserControl userControl = new ListOfScenesView(sceneDriver, modelDriver, clientDriver, materialDriver, this);
            currentView.Controls.Add(userControl);
        }

        private void LoadSignin()
        {
            Form Signin = new ClientPanel(figureDriver, materialDriver, modelDriver, sceneDriver, clientDriver);
            this.Hide();
            Signin.ShowDialog();
            this.Close();
        }

        private void MainPanel_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = ClientPanel.usernameClient.Username;
        }

        public void ShowEditSceneView(Scene scene)
        {
            currentView.Controls.Clear();
            UserControl userControl = new EditSceneView(sceneDriver, modelDriver, clientDriver, materialDriver, scene, this);
            currentView.Controls.Add(userControl);
        }
    }
}
