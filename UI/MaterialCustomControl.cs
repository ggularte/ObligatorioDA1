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
    public partial class MaterialCustomControl : UserControl
    {
        private MaterialDriver materialDriver;
        private ClientDriver clientDriver;
        private ModelDriver modelDriver;

        public MaterialCustomControl(MaterialDriver driverMaterial, ClientDriver driverClient, ModelDriver driverModel)
        {
            InitializeComponent();
            this.materialDriver = driverMaterial;
            this.clientDriver = driverClient;
            this.modelDriver = driverModel;
        }

        public string MaterialName
        {
            get { return lblMaterialName.Text; }
            set { lblMaterialName.Text = value; }
        }

        public string MaterialColor
        {
            set { lblMaterialColor.Text = value; }
        }

        public string MaterialType
        {
            set { lblMaterialType.Text = value; }
        }

        public string MaterialDifuminatedValue
        {
            set { lblDifuminatedValue.Text = value; }
        }

        public void ChangeColor()
        {
            Material material = materialDriver.GetMaterial(ClientPanel.usernameClient, MaterialName);
            btnColorMaterial.BackColor = material.Color;
        }

        private void btnDeleteMaterial_Click(object sender, EventArgs e)
        {
            Material material = materialDriver.GetMaterial(ClientPanel.usernameClient, MaterialName);
            if (modelDriver.ExistMaterialInModel(ClientPanel.usernameClient, material))
            {
                MessageBox.Show("No se puede eliminar este material debido a que forma parte de un modelo.", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DeleteMaterial();
            }
        }

        private void DeleteMaterial()
        {
            Material material = materialDriver.GetMaterial(ClientPanel.usernameClient, MaterialName);
            materialDriver.DeleteMaterial(material);
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
            Material material = materialDriver.GetMaterial(ClientPanel.usernameClient, MaterialName);
            if (material is LambertianMaterial)
            {
                MaterialType = "Lambertiano";
            }
            else if (material is MetalicMaterial)
            {
                MaterialType = "Metalico";
                lblDifuminatedValue.Visible = true;
                lblDifuminatedValue.Text = $"Difuminado: {((MetalicMaterial)material).Difuminated.ToString()}";
            }
        }

        private void MaterialCustomControl_Load(object sender, EventArgs e)
        {
            LoadType();
        }
    }
}
