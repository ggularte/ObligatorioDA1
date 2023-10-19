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
    public partial class AddNewFigureView : UserControl
    {
        private FigureDriver figureDriver;
        private ClientDriver clientDriver;
        private ModelDriver modelDriver;

        public AddNewFigureView(FigureDriver driverFigure, ClientDriver driverClient, ModelDriver driverModel)
        {
            InitializeComponent();
            this.figureDriver = driverFigure;
            this.clientDriver = driverClient;
            this.modelDriver = driverModel;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadFigures();
        }

        private void LoadFigures()
        {
            this.Controls.Clear();
            UserControl userControl = new ListOfFiguresView(figureDriver, clientDriver, modelDriver);
            this.Controls.Add(userControl);
        }

        private void btnSaveFigure_Click(object sender, EventArgs e)
        {
            if (AnyFieldBlank())
            {
                MessageBox.Show("Debe rellenar todos los campos", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AddNewFigure();
                CleanFields();
            }
        }
        private bool AnyFieldBlank()
        {
            bool isNameFigureBlank = string.IsNullOrEmpty(txtFigureName.Text.Trim());
            bool isFigureRadioBlank = string.IsNullOrEmpty(txtFigureRadio.Text.Trim());

            return isNameFigureBlank || isFigureRadioBlank;
        }

        private void CleanFields()
        {
            txtFigureName.Text = "";
            txtFigureRadio.Text = "";
        }

        private void AddNewFigure()
        {
            if (figureDriver.GetFigure(ClientPanel.usernameClient,txtFigureName.Text) == null)
            {
                try
                {
                    Figure figure = new Figure()
                    {
                        FigureName = txtFigureName.Text,
                        Radio = Double.Parse(txtFigureRadio.Text),
                        FigureOwnerId = ClientPanel.usernameClient.Username,
                        FigureOwner = ClientPanel.usernameClient
                    };
                    figureDriver.AddFigure(figure);
                    MessageBox.Show("Figura agregada", "Operacion realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (InvalidFigureNameException ex)
                {
                    MessageBox.Show(ex.Message, "Ha ocurrido un error en el nombre de la figura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (InvalidFigureRadioException ex)
                {
                    MessageBox.Show(ex.Message, "Ha ocurrido un error en el radio de la figura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ya existe una figura con el mismo nombre.", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFigureRadio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && ((sender as TextBox).Text.IndexOf(',') > -1 || (sender as TextBox).TextLength == 0))
            {
                e.Handled = true;
            }
        }
    }
}
