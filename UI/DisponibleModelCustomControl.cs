using Domain;
using Drivers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Contexts;

namespace UI
{
    public partial class DisponibleModelCustomControl : UserControl
    {
        private ModelDriver modelDriver;
        private MaterialDriver materialDriver;
        private SceneDriver sceneDriver;
        private Scene scene;

        public DisponibleModelCustomControl(ModelDriver driverModel, MaterialDriver driverMaterial, SceneDriver driverScene, Scene aScene)
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

        private void DisponibleModelCustomControl_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese las tres coordenadas separadas por / (Barras laterales) para posicionar el modelo. EJEMPLO: X / Y / Z", "Ingrese las coordenadas");

            input = input.Replace('.', ',');
            string[] numbers = input.Split('/');

            if (numbers.Length != 3)
            {
                MessageBox.Show("Debe ingresar exactamente tres coordenadas separadas por barras laterales. EJEMPLO: X / Y / Z");
                return;
            }

            double x, y, z;
            if (!double.TryParse(numbers[0], out x) || !double.TryParse(numbers[1], out y) || !double.TryParse(numbers[2], out z))
            {
                MessageBox.Show("Los valores ingresados no son números válidos.");
                return;
            }

            Model model = modelDriver.GetModel(ClientPanel.usernameClient, ModelName);

            PositionatedModel positionedModel = new PositionatedModel
            {
                ModelOwnerId = model.ModelOwnerId,
                ModelName = model.ModelName,
                BaseModel = model,
                PositionX = x,
                PositionY = y,
                PositionZ = z
            };
            sceneDriver.AddPositionedModel(positionedModel, scene);
            this.Parent.Controls.Add(this);

            int index = this.Parent.Controls.IndexOf(this);
            for (int i = index + 1; i < this.Parent.Controls.Count; i++)
            {
                Control c = this.Parent.Controls[i];
                c.Location = new Point(c.Location.X, c.Location.Y - this.Height);
            }
            this.Parent.Controls.Add(this);
            this.Parent.Controls.Remove(this);
        }

        private void DisponibleModelCustomControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }

        private void DisponibleModelCustomControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

    }
}
