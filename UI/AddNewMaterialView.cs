using Domain.Exceptions;
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
    public partial class AddNewMaterialView : UserControl
    {
        private MaterialDriver materialDriver;
        private ClientDriver clientDriver;
        private ModelDriver modelDriver;

        public AddNewMaterialView(MaterialDriver driverMaterial, ClientDriver driverClient, ModelDriver driverModel)
        {
            InitializeComponent();
            this.materialDriver = driverMaterial;
            this.clientDriver = driverClient;
            this.modelDriver = driverModel;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadMaterials();
        }

        private void LoadMaterials()
        {
            this.Controls.Clear();
            UserControl userControl = new ListOfMaterialsView(materialDriver, clientDriver, modelDriver);
            this.Controls.Add(userControl);
        }

        private void btnMaterialColorSelector_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;
            colorDialog1.ShowHelp = true;
            colorDialog1.Color = btnMaterialColorSelector.ForeColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnMaterialColorSelector.Text = "";
                btnMaterialColorSelector.BackColor = colorDialog1.Color;
            }
        }

        private void btnSaveMaterial_Click(object sender, EventArgs e)
        {
            if (AnyFieldBlank())
            {
                MessageBox.Show("Debe rellenar todos los campos", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AddNewMaterial();
                CleanFields();
            }
        }

        private bool AnyFieldBlank()
        {
            bool isMaterialNameBlank = string.IsNullOrEmpty(txtMaterialName.Text.Trim());
            bool isColorMaterialBlank = string.Equals(btnMaterialColorSelector.Text, "Seleccionar color...");
            if (txtDifuminatedValue.Visible)
            {
                bool isDifuminatedValueBlank = string.IsNullOrEmpty(txtDifuminatedValue.Text.Trim());
                return isMaterialNameBlank || isColorMaterialBlank || isDifuminatedValueBlank;
            }
            else
            {
                return isMaterialNameBlank || isColorMaterialBlank;
            }
        }

        private void CleanFields()
        {
            txtMaterialName.Text = "";
            btnMaterialColorSelector.Text = "Seleccionar color...";
            btnMaterialColorSelector.BackColor = Color.White;
            txtDifuminatedValue.Text = "";
        }

        private void AddNewMaterial()
        {
            if (materialDriver.GetMaterial(ClientPanel.usernameClient, txtMaterialName.Text) == null)
            {
                if (!cbMetalic.Checked)
                {
                    try
                    {
                        LambertianMaterial lambertianMaterial = new LambertianMaterial()
                        {
                            MaterialName = txtMaterialName.Text,
                            Color = colorDialog1.Color,
                            MaterialOwnerId = ClientPanel.usernameClient.Username,
                            MaterialOwner = ClientPanel.usernameClient
                        };
                        materialDriver.AddMaterial(lambertianMaterial);
                        MessageBox.Show("Material lambertiano agregado", "Operacion realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (InvalidMaterialNameException ex)
                    {
                        MessageBox.Show(ex.Message, "Ha ocurrido un error en el nombre del Material", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        MetalicMaterial metalicMaterial = new MetalicMaterial()
                        {
                            MaterialName = txtMaterialName.Text,
                            Color = colorDialog1.Color,
                            MaterialOwnerId = ClientPanel.usernameClient.Username,
                            MaterialOwner = ClientPanel.usernameClient,
                            Difuminated = Double.Parse(txtDifuminatedValue.Text)
                        };
                        materialDriver.AddMaterial(metalicMaterial);
                        MessageBox.Show("Material metalico", "Operacion realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (InvalidMaterialNameException ex)
                    {
                        MessageBox.Show(ex.Message, "Ha ocurrido un error en el nombre del Material", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (InvalidMaterialDifuminatedException ex)
                    {
                        MessageBox.Show(ex.Message, "Ha ocurrido un error en el difuminado del Material", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ya existe un Material con el mismo nombre.", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbMetalic_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMetalic.Checked)
            {
                txtDifuminatedValue.Visible = true;
                lblDifuminatedValue.Visible = true;
            }
            else
            {
                txtDifuminatedValue.Visible = false;
                lblDifuminatedValue.Visible = false;
                txtDifuminatedValue.Text = "";
            }
        }
    }
}
