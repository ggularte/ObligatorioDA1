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
    public partial class ListOfFiguresView : UserControl
    {
        private FigureDriver figureDriver;
        private ClientDriver clientDriver;
        private ModelDriver modelDriver;

        public ListOfFiguresView(FigureDriver driverFigure, ClientDriver driverClient, ModelDriver driverModel)
        {
            InitializeComponent();
            this.figureDriver = driverFigure;
            this.clientDriver = driverClient;
            this.modelDriver = driverModel;
        }

        private void btnAddNewFigure_Click(object sender, EventArgs e)
        {
            LoadAddFigure();
        }

        private void LoadAddFigure()
        {
            this.Controls.Clear();
            UserControl userControl = new AddNewFigureView(figureDriver, clientDriver, modelDriver);
            this.Controls.Add(userControl);
        }

        private void ListOfFiguresView_Load(object sender, EventArgs e)
        {
            LoadFigures();
        }

        private void LoadFigures()
        {
            List<Figure> figures = clientDriver.GetFigures(ClientPanel.usernameClient);
            int y = 0;
            foreach (Figure figure in figures)
            {
                FigureCustomControl customControl = new FigureCustomControl(figureDriver, clientDriver, modelDriver);
                customControl.FigureName = figure.FigureName;
                customControl.FigureRadio = "Radio: " + figure.Radio.ToString();
                pnlListOfFigures.Controls.Add(customControl);
                customControl.Location = new Point(0, y);
                customControl.Width = pnlListOfFigures.Width;
                y += customControl.Height;
            }
        }
    }
}
