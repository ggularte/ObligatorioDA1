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
    public partial class SigninView : UserControl
    {
        private FigureDriver figureDriver;
        private MaterialDriver materialDriver;
        private ModelDriver modelDriver;
        private SceneDriver sceneDriver;
        private ClientDriver clientDriver;

        public SigninView(FigureDriver driverFigure, MaterialDriver driverMaterial, ModelDriver driverModel, SceneDriver driverScene, ClientDriver driverClient)
        {
            InitializeComponent();
            this.figureDriver = driverFigure;
            this.materialDriver = driverMaterial;
            this.modelDriver = driverModel;
            this.sceneDriver = driverScene;
            this.clientDriver = driverClient;
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            if (!AnyFieldBlank())
            {
                try
                {
                    Login(txtUsername.Text, txtPassword.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No puede haber campos vacios", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            LoadSignup();
        }

        private void Login(String username, String password)
        {
            if (clientDriver.VerifyIdentity(username, password))
            {
                Client client = clientDriver.GetClientByUsername(username);
                UI.ClientPanel.usernameClient = client;
                LoadMenu();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos.", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AnyFieldBlank()
        {
            bool isNameBlank = string.IsNullOrEmpty(txtUsername.Text.Trim());
            bool isPasswordBlank = string.IsNullOrEmpty(txtPassword.Text.Trim());

            return isNameBlank || isPasswordBlank;
        }

        private void LoadMenu()
        {
            Form MainPanel = new MainPanel(figureDriver, materialDriver, modelDriver, sceneDriver, clientDriver);
            ParentForm.Hide();
            MainPanel.ShowDialog();
            ParentForm.Close();
        }

        private void LoadSignup()
        {
            this.Controls.Clear();
            UserControl userControl = new SignupView(figureDriver, materialDriver, modelDriver, sceneDriver, clientDriver);
            this.Controls.Add(userControl);
        }
    }
}
