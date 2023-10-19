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
    public partial class ClientPanel : Form
    {
        private FigureDriver figureDriver;
        private MaterialDriver materialDriver;
        private ModelDriver modelDriver;
        private SceneDriver sceneDriver;
        private ClientDriver clientDriver;

        public static Client usernameClient = null;

        public ClientPanel()
        {
            InitializeComponent();
            this.figureDriver = new FigureDriver();
            this.materialDriver = new MaterialDriver();
            this.modelDriver = new ModelDriver();
            this.sceneDriver = new SceneDriver();
            this.clientDriver = new ClientDriver();
            LoadSignin();
        }

        public ClientPanel(FigureDriver driverFigure, MaterialDriver driverMaterial, ModelDriver driverModel, SceneDriver driverScene, ClientDriver driverClient)
        {
            InitializeComponent();
            this.figureDriver = driverFigure;
            this.materialDriver = driverMaterial;
            this.modelDriver = driverModel;
            this.sceneDriver = driverScene;
            this.clientDriver = driverClient;
            LoadSignin();
        }

        private void LoadSignin()
        {
            this.Controls.Clear();
            UserControl userControl = new SigninView(figureDriver, materialDriver, modelDriver, sceneDriver, clientDriver);
            this.Controls.Add(userControl);
        }
    }
}
