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
    public partial class FigureCustomControl : UserControl
    {
        private FigureDriver figureDriver;
        private ClientDriver clientDriver;
        private ModelDriver modelDriver;

        public FigureCustomControl(FigureDriver driverFigure, ClientDriver driverClient, ModelDriver driverModel)
        {
            InitializeComponent();
            this.figureDriver = driverFigure;
            this.clientDriver = driverClient;
            this.modelDriver = driverModel;
        }

        public string FigureName
        {
            get { return lblFigureName.Text; }
            set { lblFigureName.Text = value; }
        }

        public string FigureRadio
        {
            get { return lblFigureRadio.Text; }
            set { lblFigureRadio.Text = value; }
        }

        private void btnDeleteFigure_Click(object sender, EventArgs e)
        {
            Figure figure = figureDriver.GetFigure(ClientPanel.usernameClient, FigureName);
            if (modelDriver.ExistFigureInModel(ClientPanel.usernameClient, figure))
            {
                MessageBox.Show("No se puede eliminar esta figura debido a que forma parte de un modelo.", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DeleteFigure();
            }
        }

        private void DeleteFigure()
        {
            Figure figure = figureDriver.GetFigure(ClientPanel.usernameClient, FigureName);
            figureDriver.DeleteFigure(figure);
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
