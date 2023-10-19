using Domain;
using Drivers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class SceneCustomControl : UserControl
    {
        private SceneDriver sceneDriver;
        private ModelDriver modelDriver;
        private ClientDriver clientDriver;
        private MaterialDriver materialDriver;
        private MainPanel mainPanel;

        public SceneCustomControl(SceneDriver driverScene, ModelDriver driverModel, ClientDriver driverClient, MaterialDriver driverMaterial, MainPanel panelMain)
        {
            InitializeComponent();
            this.sceneDriver = driverScene;
            this.modelDriver = driverModel;
            this.clientDriver = driverClient;
            this.materialDriver = driverMaterial;
            this.mainPanel = panelMain;
        }

        public string SceneName
        {
            get { return lblSceneName.Text; }
            set { lblSceneName.Text = value; }
        }

        public string LastModification
        {
            get { return lblLastModificationDate.Text; }
            set { lblLastModificationDate.Text = value; }
        }

        public void LoadPreview(string fileName)
        {
            pbPreviewScene.Visible = false;
            picBoxImage.Visible = true;
            var fileContents = File.ReadLines(fileName).ToArray();
            var resolution = fileContents[1].Trim().Split(' ');
            var width = int.Parse(resolution[0]);
            var height = int.Parse(resolution[1]);
            var bitmap = new Bitmap(width, height);
            for (int i = 3; i < fileContents.Length; i++)
            {
                var rgbValues = fileContents[i].Split(' ').Select(value => int.Parse(value)).ToArray();
                var r = rgbValues[0];
                var g = rgbValues[1];
                var b = rgbValues[2];
                var lineNumber = i - 3;
                var pixelColumn = lineNumber % width;
                var pixelRow = lineNumber / width;
                bitmap.SetPixel(pixelColumn, pixelRow, Color.FromArgb(r, g, b));
            }
            this.picBoxImage.Image = bitmap;
            Refresh();
        }

        private void btnDeleteScene_Click(object sender, EventArgs e)
        {
            DeleteScene();
        }

        private void DeleteScene()
        {
            Scene scene = sceneDriver.GetScene(ClientPanel.usernameClient, SceneName);
            sceneDriver.DeleteScene(scene);
            int index = this.Parent.Controls.IndexOf(this);
            for (int i = index + 1; i < this.Parent.Controls.Count; i++)
            {
                Control c = this.Parent.Controls[i];
                c.Location = new Point(c.Location.X, c.Location.Y - this.Height);
            }
            this.Parent.Controls.Remove(this);
        }

        private void SceneCustomControl_Click(object sender, EventArgs e)
        {
            Scene scene = sceneDriver.GetScene(ClientPanel.usernameClient, SceneName);
            mainPanel.ShowEditSceneView(scene);
        }

        private void SceneCustomControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }

        private void SceneCustomControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
