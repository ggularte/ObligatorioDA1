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
    public partial class PositionedModelCustomControl : UserControl
    {
        private ModelDriver modelDriver;
        private MaterialDriver materialDriver;
        private SceneDriver sceneDriver;
        private Scene scene;

        public PositionedModelCustomControl(ModelDriver driverModel, MaterialDriver driverMaterial, SceneDriver driverScene, Scene aScene)
        {
            InitializeComponent();
            this.modelDriver = driverModel;
            this.materialDriver = driverMaterial;
            this.sceneDriver = driverScene;
            this.scene = aScene;
        }

        public string ModelName
        {
            get { return lblModelName.Text; }
            set { lblModelName.Text = value; }
        }

        public string ModelCoords
        {
            get { return lblCoords.Text; }
            set { lblCoords.Text = value; }
        }

        public string ModelId
        {
            get { return lblModelID.Text; }
            set { lblModelID.Text = value; }
        }

        public void ChangeColor()
        {
            Model model = modelDriver.GetModel(ClientPanel.usernameClient, ModelName);
            Material material = model.ModelMaterial;
            btnColorModel.BackColor = material.Color;
        }

        public void LoadPreview(string fileName)
        {
            btnColorModel.Visible = false;
            pbPreviewModel.Visible = false;
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

        private void btnDeleteModel_Click(object sender, EventArgs e)
        {
            DeleteModel();
        }

        private void DeleteModel()
        {
            sceneDriver.RemovePositionedModel(int.Parse(ModelId), scene);
            int index = this.Parent.Controls.IndexOf(this);
            for (int i = index + 1; i < this.Parent.Controls.Count; i++)
            {
                Control c = this.Parent.Controls[i];
                c.Location = new Point(c.Location.X, c.Location.Y - this.Height);
            }
            this.Parent.Controls.Remove(this);
        }
    }
}
