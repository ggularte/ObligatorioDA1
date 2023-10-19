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
    public partial class ModelCustomControl : UserControl
    {
        private ModelDriver modelDriver;
        private MaterialDriver materialDriver;
        private SceneDriver sceneDriver;
        private ClientDriver clientDriver;

        public ModelCustomControl(ModelDriver driverModel, MaterialDriver driverMaterial, SceneDriver driverScene, ClientDriver driverClient)
        {
            InitializeComponent();
            this.modelDriver = driverModel;
            this.materialDriver = driverMaterial;
            this.sceneDriver = driverScene;
            this.clientDriver = driverClient;
        }

        public string ModelName
        {
            get { return lblModelName.Text; }
            set { lblModelName.Text = value; }
        }

        public string ModelFigure
        {
            get { return lblModelFigure.Text; }
            set { lblModelFigure.Text = value; }
        }

        public string ModelMaterial
        {
            get { return lblModelMaterial.Text; }
            set { lblModelMaterial.Text = value; }
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

        public void ChangeColor()
        {
            string materialName = lblModelMaterial.Text.Substring(9);
            Material material = materialDriver.GetMaterial(ClientPanel.usernameClient, materialName);
            btnColorModel.BackColor = material.Color;
        }

        private void btnDeleteModel_Click(object sender, EventArgs e)
        {
            Model model = modelDriver.GetModel(ClientPanel.usernameClient, ModelName);
            if (sceneDriver.ExistModelInScene(ClientPanel.usernameClient, model))
            {
                MessageBox.Show("No se puede eliminar este modelo debido a que forma parte de alguna escena.", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DeleteModel();
            }
        }

        private void DeleteModel()
        {
            Model model = modelDriver.GetModel(ClientPanel.usernameClient, ModelName);
            modelDriver.DeleteModel(model);
            int index = this.Parent.Controls.IndexOf(this);
            for (int i = index + 1; i < this.Parent.Controls.Count; i++)
            {
                Control c = this.Parent.Controls[i];
                c.Location = new Point(c.Location.X, c.Location.Y - this.Height);
            }
            this.Parent.Controls.Remove(this);
        }

        private void LoadType()
        {
            Model model = modelDriver.GetModel(ClientPanel.usernameClient, ModelName);
            Material material = materialDriver.GetMaterial(ClientPanel.usernameClient, model.ModelMaterialName);
            if (material is LambertianMaterial)
            {
                ModelMaterial = $"{model.ModelMaterialName} (Lambertiano)";
            }
            else if (material is MetalicMaterial)
            {
                ModelMaterial = $"{model.ModelMaterialName} (Metalico)";
            }
        }

        private void ModelCustomControl_Load(object sender, EventArgs e)
        {
            LoadType();
        }
    }
}
