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
    public partial class ListOfMaterialsView : UserControl
    {
        private MaterialDriver materialDriver;
        private ClientDriver clientDriver;
        private ModelDriver modelDriver;

        public ListOfMaterialsView(MaterialDriver driverMaterial, ClientDriver clientDriver, ModelDriver driverModel)
        {
            InitializeComponent();
            this.materialDriver = driverMaterial;
            this.clientDriver = clientDriver;
            this.modelDriver = driverModel;
        }

        private void btnAddNewMaterial_Click(object sender, EventArgs e)
        {
            LoadAddMaterial();
        }

        private void LoadAddMaterial()
        {
            this.Controls.Clear();
            UserControl userControl = new AddNewMaterialView(materialDriver, clientDriver, modelDriver);
            this.Controls.Add(userControl);
        }

        private void ListOfMaterialsView_Load(object sender, EventArgs e)
        {
            LoadMaterials();
        }

        private void LoadMaterials()
        {
            List<Material> materials = clientDriver.GetMaterials(ClientPanel.usernameClient);
            int y = 0;
            foreach (Material material in materials)
            {
                MaterialCustomControl customControl = new MaterialCustomControl(materialDriver, clientDriver, modelDriver);
                customControl.MaterialName = material.MaterialName;
                customControl.MaterialColor = $"R:{material.Color.R} G:{material.Color.G} B:{material.Color.B}";
                customControl.ChangeColor();
                pnlListOfMaterials.Controls.Add(customControl);
                customControl.Location = new Point(0, y);
                customControl.Width = pnlListOfMaterials.Width;
                y += customControl.Height;
            }
        }
    }
}
