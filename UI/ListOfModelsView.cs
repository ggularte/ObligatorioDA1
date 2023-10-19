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
    public partial class ListOfModelsView : UserControl
    {
        private ModelDriver modelDriver;
        private FigureDriver figureDriver;
        private MaterialDriver materialDriver;
        private ClientDriver clientDriver;
        private SceneDriver sceneDriver;

        public ListOfModelsView(ModelDriver driverModel, FigureDriver figureDriver, MaterialDriver materialDriver, ClientDriver driverClient, SceneDriver driverScene)
        {
            InitializeComponent();
            this.modelDriver = driverModel;
            this.figureDriver = figureDriver;
            this.materialDriver = materialDriver;
            this.clientDriver = driverClient;
            this.sceneDriver = driverScene;
        }

        private void btnAddNewModel_Click(object sender, EventArgs e)
        {
            LoadAddModel();
        }

        private void LoadAddModel()
        {
            this.Controls.Clear();
            UserControl userControl = new AddNewModelView(modelDriver, figureDriver, materialDriver, clientDriver, sceneDriver);
            this.Controls.Add(userControl);
        }

        private void ListOfModelsView_Load(object sender, EventArgs e)
        {
            LoadModels();
        }

        private void LoadModels()
        {
            List<Model> models = clientDriver.GetModels(ClientPanel.usernameClient);
            int y = 0;
            foreach (Model model in models)
            {
                ModelCustomControl customControl = new ModelCustomControl(modelDriver, materialDriver, sceneDriver, clientDriver);
                customControl.ModelName = model.ModelName;
                customControl.ModelFigure = $"Figura: {model.ModelFigureName}";
                customControl.ModelMaterial = $"Material {model.ModelMaterialName}";
                if (!model.ModelPreviewPath.Equals("none"))
                {
                    string fileName = $"ppmModels\\{model.ModelOwner.Username}-{model.ModelName}-ppm.ppm";
                    customControl.LoadPreview(fileName);
                }
                else
                {
                    customControl.ChangeColor();
                }
                pnlListOfModels.Controls.Add(customControl);
                customControl.Location = new Point(0, y);
                customControl.Width = pnlListOfModels.Width;
                y += customControl.Height;
            }
        }
    }
}
