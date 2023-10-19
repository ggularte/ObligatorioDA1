using Domain;
using Drivers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class SignupView : UserControl
    {
        private FigureDriver figureDriver;
        private MaterialDriver materialDriver;
        private ModelDriver modelDriver;
        private SceneDriver sceneDriver;
        private ClientDriver clientDriver;

        public SignupView(FigureDriver driverFigure, MaterialDriver driverMaterial, ModelDriver driverModel, SceneDriver driverScene, ClientDriver driverClient)
        {
            InitializeComponent();
            this.figureDriver = driverFigure;
            this.materialDriver = driverMaterial;
            this.modelDriver = driverModel;
            this.sceneDriver = driverScene;
            this.clientDriver = driverClient;
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (!AnyFieldBlank())
            {
                Signup(txtUsername.Text, txtPassword.Text, txtConfirmPassword.Text);
            }
            else
            {
                MessageBox.Show("No puede haber campos vacios", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoadBack();
        }

        private void LoadBack()
        {
            this.Controls.Clear();
            UserControl userControl = new SigninView(figureDriver, materialDriver, modelDriver, sceneDriver, clientDriver);
            this.Controls.Add(userControl);
        }

        private void Signup(string username, string password, string confirmPassword)
        {
            CreateUser(username, password);
        }

        private void CreateUser(string username, string password)
        {
            Client dbClient = clientDriver.GetClientByUsername(username);
            if (dbClient == null || username != dbClient.Username)
            {
                Client client = new Client()
                {
                    Username = username,
                    Password = password,
                    RegisterDate = DateTime.Now,
                };
                clientDriver.AddClient(client);
                MessageBox.Show("Se ha registrado con exito", "Opereacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CleanFields();
            }
            else
            {
                MessageBox.Show("Ya hay un usuario con dicho nombre", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CleanFields()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        private bool AnyFieldBlank()
        {
            bool isNameBlank = string.IsNullOrEmpty(txtUsername.Text.Trim());
            bool isPasswordBlank = string.IsNullOrEmpty(txtPassword.Text.Trim());
            bool isConfirmPasswordBlank = string.IsNullOrEmpty(txtConfirmPassword.Text.Trim());

            return isNameBlank || isPasswordBlank || isConfirmPasswordBlank;
        }

        private void ValidateUserName()
        {
            if (!Regex.IsMatch(txtUsername.Text, "^[a-zA-Z0-9]{3,20}$"))
            {
                errorProviderUsername.SetError(txtUsername, "El nombre de usuario debe ser alfanumérico, tener entre 3 y 20 caracteres y no tener espacios.");
                btnSignup.Enabled = false;
            }
            else
            {
                errorProviderUsername.SetError(txtUsername, "");
                btnSignup.Enabled = true;
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateUserName();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            ValidateUserName();
        }

        private void ValidatePassword()
        {
            if (!Regex.IsMatch(txtPassword.Text, "^(?=.*[A-Z])(?=.*\\d).{5,25}$"))
            {
                errorProviderPassword.SetError(txtPassword, "La contraseña debe contener al menos una mayúscula, un número, tener entre 5 y 25 caracteres y no tener espacios.");
                btnSignup.Enabled = false;
            }
            else
            {
                errorProviderPassword.SetError(txtPassword, "");
                btnSignup.Enabled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidatePassword();
            ValidateConfirmPassword();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            ValidatePassword();
            ValidateConfirmPassword();
        }

        private void ValidateConfirmPassword()
        {
            if (!txtPassword.Text.Equals(txtConfirmPassword.Text))
            {
                errorProviderConfirmPassword.SetError(txtConfirmPassword, "Los contraseñas no coinciden.");
                btnSignup.Enabled = false;
            }
            else
            {
                errorProviderConfirmPassword.SetError(txtConfirmPassword, "");
                btnSignup.Enabled = true;
            }
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateConfirmPassword();
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateConfirmPassword();
        }
    }
}
