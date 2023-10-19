using Domain.Exceptions;
using Domain;
using Drivers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Domain.GraphicEngine;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class AddNewModelView : UserControl
    {
        private ModelDriver modelDriver;
        private FigureDriver figureDriver;
        private MaterialDriver materialDriver;
        private ClientDriver clientDriver;
        private SceneDriver sceneDriver;

        public AddNewModelView(ModelDriver driverModel, FigureDriver driverFigure, MaterialDriver driverMaterial, ClientDriver driverClient, SceneDriver driverScene)
        {
            InitializeComponent();
            this.modelDriver = driverModel;
            this.figureDriver = driverFigure;
            this.materialDriver = driverMaterial;
            this.clientDriver = driverClient;
            this.sceneDriver = driverScene;

            cmbModelFigure.DataSource = clientDriver.GetFigures(ClientPanel.usernameClient);
            cmbModelMaterial.DataSource = clientDriver.GetMaterials(ClientPanel.usernameClient);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadModels();
        }

        private void LoadModels()
        {
            this.Controls.Clear();
            UserControl userControl = new ListOfModelsView(modelDriver, figureDriver, materialDriver, clientDriver, sceneDriver);
            this.Controls.Add(userControl);
        }

        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            if (AnyFieldBlank())
            {
                MessageBox.Show("Debe rellenar todos los campos", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AddNewModel();
                CleanFields();
            }
        }

        private bool AnyFieldBlank()
        {
            bool isNameModelBlank = string.IsNullOrEmpty(txtModelName.Text.Trim());
            bool isCmbFigureBlank = cmbModelFigure.SelectedIndex == -1;
            bool isCmbMaterialBlank = cmbModelMaterial.SelectedIndex == -1;

            return isNameModelBlank || isCmbFigureBlank || isCmbMaterialBlank;
        }

        private void CleanFields()
        {
            txtModelName.Text = "";
            cmbModelFigure.SelectedIndex = -1;
            cmbModelMaterial.SelectedIndex = -1;
            btnColor.BackColor = Color.Silver;
        }

        private void AddNewModel()
        {
            if (modelDriver.GetModel(ClientPanel.usernameClient, txtModelName.Text) == null)
            {
                try
                {
                    Model model = new Model()
                    {
                        ModelName = txtModelName.Text,
                        ModelFigureName = ((Figure)cmbModelFigure.SelectedItem).FigureName,
                        ModelFigureOwnerId = ClientPanel.usernameClient.Username,
                        ModelFigure = (Figure)cmbModelFigure.SelectedItem,
                        ModelMaterialName = ((Material)cmbModelMaterial.SelectedItem).MaterialName,
                        ModelMaterialOwnerId = ClientPanel.usernameClient.Username,
                        ModelMaterial = (Material)cmbModelMaterial.SelectedItem,
                        ModelOwnerId = ClientPanel.usernameClient.Username,
                        ModelOwner = ClientPanel.usernameClient,
                        ModelPreviewPath = "none"
                    };

                    if (cbGeneratePreview.Checked)
                    {
                        Random random = new Random();
                        RandomProvider randomProvider = new RandomProvider(false, random);
                        GraphicEngine graphicEngine = new GraphicEngine(randomProvider);

                        int resolutionX = 100;
                        int resolutionY = 100;
                        float aspectRatio = resolutionX / resolutionY;

                        List<List<Vector3D>> pixels = new List<List<Vector3D>>();
                        Vector3D lookAt = new Vector3D(0, 2, 5);
                        Vector3D vectorUp = new Vector3D(0, 1, 0);
                        Vector3D origin = new Vector3D(0, 3, -5);
                        double focalDistance = origin.Subtract(lookAt).Length();
                        double aperture = 0.2;
                        Camera camera = new Camera(origin, lookAt, vectorUp, 30, aspectRatio, "new", aperture, focalDistance);

                        Color materialColor = model.ModelMaterial.Color;
                        string typeMaterial = "";
                        double roughness = 0;

                        List<Sphere> elements = new List<Sphere>();

                        if ((Material)cmbModelMaterial.SelectedItem is LambertianMaterial)
                        {
                            typeMaterial = "lambertian";
                            Sphere sphere = new Sphere(new Vector3D(0, 2, 5), 2, new Vector3D((double)materialColor.R / 255, (double)materialColor.G / 255, (double)materialColor.B / 255), typeMaterial);
                            elements.Add(sphere);
                        }
                        else if ((Material)cmbModelMaterial.SelectedItem is MetalicMaterial)
                        {
                            typeMaterial = "metalic";
                            roughness = ((MetalicMaterial)cmbModelMaterial.SelectedItem).Difuminated;
                            Sphere sphere = new Sphere(new Vector3D(0, 2, 5), 2, new Vector3D((double)materialColor.R / 255, (double)materialColor.G / 255, (double)materialColor.B / 255), typeMaterial, roughness);
                            elements.Add(sphere);
                        }
                        Sphere terrain = new Sphere(new Vector3D(0, -2000, -1), 2000, new Vector3D(0.7, 0.7, 0.1), "lambertian");
                        elements.Add(terrain);

                        int samplesPerPixel = 50;
                        int maxDepth = 20;

                        progressBar1.Maximum = resolutionX * resolutionY * samplesPerPixel;
                        progressBar1.Step = 1;

                        int progress = 0;
                        for (int row = resolutionY - 1; row >= 0; row--)
                        {
                            for (int column = 0; column < resolutionX; column++)
                            {
                                Vector3D pixelColor = new Vector3D(0, 0, 0);
                                for (int sample = 0; sample < samplesPerPixel; sample++)
                                {
                                    float u = (float)(column + randomProvider.getRandom()) / resolutionX;
                                    float v = (float)(row + randomProvider.getRandom()) / resolutionY;
                                    Ray ray = camera.GetRay(u, v, graphicEngine);
                                    pixelColor.AddTo(graphicEngine.ShootRay(ray, maxDepth, elements));

                                    progressBar1.PerformStep();
                                    progress++;
                                }
                                pixelColor = pixelColor.Divide(samplesPerPixel);
                                pixels = graphicEngine.SavePixel(row, column, pixelColor, resolutionY, pixels);
                            }
                        }

                        progressBar1.Value = progressBar1.Maximum;
                        progressBar1.Value = 0;
                        progressBar1.Maximum = resolutionX * resolutionY;
                        progress = 0;

                        Directory.CreateDirectory("ppmModels");
                        string fileName = $"ppmModels\\{model.ModelOwner.Username}-{model.ModelName}-ppm.ppm";
                        model.ModelPreviewPath = fileName;
                        string imageString = "P3\n" + resolutionX + " " + resolutionY + "\n255\n";

                        for (int j = 0; j < resolutionY; j++)
                        {
                            for (int i = 0; i < resolutionX; i++)
                            {
                                Vector3D color = pixels[j][i];
                                imageString += color.Red + " " + color.Green + " " + color.Blue + "\n";

                                progressBar1.PerformStep();
                                progress++;
                            }
                        }

                        File.WriteAllText(fileName, imageString);
                        progressBar1.Value = progressBar1.Maximum;
                        progressBar1.Value = 0;

                    }
                    modelDriver.AddModel(model);
                    MessageBox.Show("Modelo creado.", "Operacion realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (InvalidModelNameException ex)
                {
                    MessageBox.Show(ex.Message, "Ha ocurrido un error en el nombre del modelo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ya existe un Modelo con el mismo nombre.", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbModelMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cmbModelMaterial.SelectedIndex == -1))
            {
                btnColor.BackColor = ((Material)cmbModelMaterial.SelectedItem).Color;
            }
        }

        private void AddNewModelView_Load(object sender, EventArgs e)
        {
            cmbModelMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModelFigure.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
