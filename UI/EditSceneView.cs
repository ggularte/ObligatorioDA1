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
using System.Globalization;
using System.Drawing.Imaging;

namespace UI
{
    public partial class EditSceneView : UserControl
    {
        private SceneDriver sceneDriver;
        private ModelDriver modelDriver;
        private ClientDriver clientDriver;
        private MaterialDriver materialDriver;
        private Scene scene;
        private MainPanel mainPanel;

        string load = "on";
        List<List<Vector3D>> savedPixels = new List<List<Vector3D>>();

        public EditSceneView(SceneDriver driverScene, ModelDriver driverModel, ClientDriver driverClient, MaterialDriver driverMaterial, Scene aScene, MainPanel panelMain)
        {
            InitializeComponent();
            this.sceneDriver = driverScene;
            this.modelDriver = driverModel;
            this.clientDriver = driverClient;
            this.materialDriver = driverMaterial;
            this.scene = aScene;
            this.mainPanel = panelMain;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoadScenes();
        }

        private void LoadScenes()
        {
            this.Controls.Clear();
            UserControl userControl = new ListOfScenesView(sceneDriver, modelDriver, clientDriver, materialDriver, mainPanel);
            this.Controls.Add(userControl);
        }

        private void btnRender_Click(object sender, EventArgs e)
        {
            if (AnyFieldBlank())
            {
                MessageBox.Show("Debe rellenar todos los campos", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                List<PositionatedModel> positionedModels = sceneDriver.GetPositionedModels(scene);
                if (positionedModels == null)
                {
                    MessageBox.Show("No puede renderizar una escena si no tiene modelos posicionados", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    RenderScene();
                }
            }
        }

        private bool AnyFieldBlank()
        {
            bool isNameSceneBlank = string.IsNullOrEmpty(txtSceneName.Text.Trim());
            bool isLookFromX = string.IsNullOrEmpty(txtLookFromX.Text.Trim());
            bool isLookFromY = string.IsNullOrEmpty(txtLookFromY.Text.Trim());
            bool isLookFromZ = string.IsNullOrEmpty(txtLookFromZ.Text.Trim());
            bool isLookAtX = string.IsNullOrEmpty(txtLookAtX.Text.Trim());
            bool isLookAtY = string.IsNullOrEmpty(txtLookAtY.Text.Trim());
            bool isLookAtZ = string.IsNullOrEmpty(txtLookAtZ.Text.Trim());
            bool isTxtFoV = string.IsNullOrEmpty(txtFoV.Text.Trim());
            bool isLensRadius = string.IsNullOrEmpty(txtLensRadius.Text.Trim());

            return isNameSceneBlank || isLookFromX || isLookFromY || isLookFromZ || isLookAtX || isLookAtY || isLookAtZ || isTxtFoV || isLensRadius;
        }

        private void RenderScene()
        {
            int progress = 0;
            int resolutionX = 300;
            int resolutionY = 200;

            savedPixels = RenderGraphicEngine();

            Directory.CreateDirectory("ppmScenes");
            string fileName = $"ppmScenes\\{scene.SceneOwner.Username}-{scene.SceneName}-ppm.ppm";
            scene.ScenePreviewPath = fileName;
            string imageString = "P3\n" + resolutionX + " " + resolutionY + "\n255\n";

            for (int j = 0; j < resolutionY; j++)
            {
                for (int i = 0; i < resolutionX; i++)
                {
                    Vector3D color = savedPixels[j][i];
                    imageString += color.Red + " " + color.Green + " " + color.Blue + "\n";

                    progressBar1.PerformStep();
                    progress++;
                }
            }

            File.WriteAllText(fileName, imageString);
            progressBar1.Value = progressBar1.Maximum;
            progressBar1.Value = 0;

            var fileContents = File.ReadLines(fileName).ToArray();
            var resolution = fileContents[1].Trim().Split(' ');
            var width = int.Parse(resolution[0]);
            var height = int.Parse(resolution[1]);
            var bitmap = new Bitmap(width, height);
            for (int i = 3; i < fileContents.Length; i++)
            {
                var rgbValues = fileContents[i].Split(' ').Select(value => int.Parse(value)).ToArray();
                var r = rgbValues[0];
                var g = rgbValues[1];
                var b = rgbValues[2];
                var lineNumber = i - 3;
                var pixelColumn = lineNumber % width;
                var pixelRow = lineNumber / width;
                bitmap.SetPixel(pixelColumn, pixelRow, Color.FromArgb(r, g, b));
            }
            this.picBoxImage.Image = bitmap;
            Refresh();

            lblWarning.Visible = false;
            pbWarning.Visible = false;

            scene.LastRender = DateTime.Now.ToString("HH:mm - dd/MM/yyyy");
            lblLastRender.Text = $"Último renderizado: {scene.LastRender}";

            scene.ModifiedDate = DateTime.Now;
            lblLeastModification.Text = $"Última modificación: {scene.ModifiedDate.ToString("HH:mm - dd/MM/yyyy")}";

            sceneDriver.UpdateScene(scene, txtSceneName.Text);
            scene = sceneDriver.GetScene(ClientPanel.usernameClient, txtSceneName.Text);
            LoadModels();
        }

        private List<List<Vector3D>> RenderGraphicEngine()
        {
            Random random = new Random();
            RandomProvider randomProvider = new RandomProvider(false, random);
            GraphicEngine graphicEngine = new GraphicEngine(randomProvider);

            int resolutionX = 300;
            int resolutionY = 200;
            float aspectRatio = resolutionX / resolutionY;

            scene.LookAtX = double.Parse(txtLookAtX.Text);
            scene.LookAtY = double.Parse(txtLookAtY.Text);
            scene.LookAtZ = double.Parse(txtLookAtZ.Text);
            scene.LookFromX = double.Parse(txtLookFromX.Text);
            scene.LookFromY = double.Parse(txtLookFromY.Text);
            scene.LookFromZ = double.Parse(txtLookFromZ.Text);
            scene.FoV = int.Parse(txtFoV.Text);
            scene.LensRadius = double.Parse(txtLensRadius.Text);
            List<List<Vector3D>> pixels = new List<List<Vector3D>>();
            Vector3D lookAt = new Vector3D(double.Parse(txtLookAtX.Text), double.Parse(txtLookAtY.Text), double.Parse(txtLookAtZ.Text));
            Vector3D vectorUp = new Vector3D(0, 1, 0);
            Vector3D origin = new Vector3D(double.Parse(txtLookFromX.Text), double.Parse(txtLookFromY.Text), double.Parse(txtLookFromZ.Text));

            Camera camera = null;
            if (cbBlur.Checked)
            {
                scene.Blur = true;
                double focalDistance = origin.Subtract(lookAt).Length();
                double aperture = double.Parse(txtLensRadius.Text);
                camera = new Camera(origin, lookAt, vectorUp, int.Parse(txtFoV.Text), aspectRatio, "new", aperture, focalDistance);
            }
            else
            {
                scene.Blur = false;
                camera = new Camera(origin, lookAt, vectorUp, int.Parse(txtFoV.Text), aspectRatio, "old");
            }

            List<Sphere> elements = new List<Sphere>();

            List<PositionatedModel> positionedModels = sceneDriver.GetPositionedModels(scene);
            foreach (PositionatedModel positionedModel in positionedModels)
            {
                Model model = modelDriver.GetModel(ClientPanel.usernameClient, positionedModel.ModelName);
                Vector3D positionSphere = new Vector3D(positionedModel.PositionX, positionedModel.PositionY, positionedModel.PositionZ);
                double radioSphere = model.ModelFigure.Radio;
                Vector3D colorSphere = new Vector3D((double)model.ModelMaterial.Color.R / 255, (double)model.ModelMaterial.Color.G / 255, (double)model.ModelMaterial.Color.B / 255);
                string typeMaterial = "";
                if (model.ModelMaterial is LambertianMaterial)
                {
                    typeMaterial = "lambertian";
                    Sphere sphere = new Sphere(positionSphere, radioSphere, colorSphere, typeMaterial);
                    elements.Add(sphere);
                }
                else if (model.ModelMaterial is MetalicMaterial)
                {
                    typeMaterial = "metalic";
                    double roughness = ((MetalicMaterial)model.ModelMaterial).Difuminated;
                    Sphere sphere = new Sphere(positionSphere, radioSphere, colorSphere, typeMaterial, roughness);
                    elements.Add(sphere);
                }
            }

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

            load = "on";

            return pixels;
        }

        private void EditSceneView_Load(object sender, EventArgs e)
        {
            ChangeTxtSceneNameProperties();
            LoadModels();
            LoadValues();
            LoadPreview();
            VerifyUpdated();
        }

        private void ChangeTxtSceneNameProperties()
        {
            txtSceneName.ReadOnly = true;
            txtSceneName.BackColor = Color.White;
            txtSceneName.BorderStyle = BorderStyle.FixedSingle;
            txtSceneName.Cursor = Cursors.IBeam;
            txtSceneName.MouseClick += txtSceneName_MouseClick;
        }

        private void LoadPreview()
        {
            if (!scene.ScenePreviewPath.Equals("none"))
            {
                string fileName = scene.ScenePreviewPath;
                var fileContents = File.ReadLines(fileName).ToArray();
                var resolution = fileContents[1].Trim().Split(' ');
                var width = int.Parse(resolution[0]);
                var height = int.Parse(resolution[1]);
                var bitmap = new Bitmap(width, height);
                for (int i = 3; i < fileContents.Length; i++)
                {
                    var rgbValues = fileContents[i].Split(' ').Select(value => int.Parse(value)).ToArray();
                    var r = rgbValues[0];
                    var g = rgbValues[1];
                    var b = rgbValues[2];
                    var lineNumber = i - 3;
                    var pixelColumn = lineNumber % width;
                    var pixelRow = lineNumber / width;
                    bitmap.SetPixel(pixelColumn, pixelRow, Color.FromArgb(r, g, b));
                }
                this.picBoxImage.Image = bitmap;
                Refresh();

                if (scene.ModifiedDate.ToString("HH:mm - dd/MM/yyyy") != scene.LastRender)
                {
                    lblWarning.Visible = true;
                    pbWarning.Visible = true;
                }
                else
                {
                    lblWarning.Visible = false;
                    pbWarning.Visible = false;
                }
            }
        }

        private void LoadValues()
        {
            txtSceneName.Text = scene.SceneName;
            lblLeastModification.Text = $"Última modificación: {scene.ModifiedDate.ToString("HH:mm - dd/MM/yyyy")}";
            txtLookFromX.Text = scene.LookFromX.ToString();
            txtLookFromY.Text = scene.LookFromY.ToString();
            txtLookFromZ.Text = scene.LookFromZ.ToString();
            txtLookAtX.Text = scene.LookAtX.ToString();
            txtLookAtY.Text = scene.LookAtY.ToString();
            txtLookAtZ.Text = scene.LookAtZ.ToString();
            txtFoV.Text = scene.FoV.ToString();
            txtLensRadius.Text = scene.LensRadius.ToString();
            if (scene.LastRender == null)
            {
                lblLastRender.Text = "Último renderizado: NUNCA";
            }
            else
            {
                lblLastRender.Text = $"Último renderizado: {scene.LastRender}";
            }
            if (scene.Blur)
            {
                cbBlur.Checked = true;
            }
            else
            {
                cbBlur.Checked = false;
            }
        }

        private void LoadModels()
        {
            pnlPosciosionedModels.Controls.Clear();

            List<Model> models = clientDriver.GetModels(ClientPanel.usernameClient);
            int y1 = 0;
            foreach (Model model in models)
            {
                DisponibleModelCustomControl customControl = new DisponibleModelCustomControl(modelDriver, materialDriver, sceneDriver, scene);
                customControl.ModelName = model.ModelName;
                if (!model.ModelPreviewPath.Equals("none"))
                {
                    string fileName = $"ppmModels\\{model.ModelOwner.Username}-{model.ModelName}-ppm.ppm";
                    customControl.LoadPreview(fileName);
                }
                else
                {
                    customControl.ChangeColor();
                }
                pnlDisponibleModels.Controls.Add(customControl);
                customControl.Location = new Point(0, y1);
                customControl.Width = pnlDisponibleModels.Width;
                y1 += customControl.Height;
            }

            List<PositionatedModel> positionedModels = sceneDriver.GetPositionedModels(scene);
            int y2 = 0;
            foreach (PositionatedModel positionedModel in positionedModels)
            {
                PositionedModelCustomControl customControl = new PositionedModelCustomControl(modelDriver, materialDriver, sceneDriver, scene)
                {
                    ModelName = positionedModel.ModelName,
                    ModelCoords = $"({positionedModel.PositionX} | {positionedModel.PositionY} | {positionedModel.PositionZ})",
                    ModelId = positionedModel.PositionatedModelId.ToString()
                };
                Model model = modelDriver.GetModel(ClientPanel.usernameClient, positionedModel.ModelName);
                if (!model.ModelPreviewPath.Equals("none"))
                {
                    string fileName = $"ppmModels\\{model.ModelOwner.Username}-{positionedModel.ModelName}-ppm.ppm";
                    customControl.LoadPreview(fileName);
                }
                else
                {
                    customControl.ChangeColor();
                }
                pnlPosciosionedModels.Controls.Add(customControl);
                customControl.Location = new Point(0, y2);
                customControl.Width = pnlPosciosionedModels.Width;
                y2 += customControl.Height;
            }
            load = "off";
        }

        private void txtLookFromX_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFormat(sender, e);
        }

        private void txtLookFromY_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFormat(sender, e);
        }

        private void txtLookFromZ_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFormat(sender, e);
        }

        private void txtLookAtX_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFormat(sender, e);
        }

        private void txtLookAtY_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFormat(sender, e);
        }

        private void txtLookAtZ_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFormat(sender, e);
        }

        private void keyPressFormat(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '-' && e.KeyChar != '\b')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == ',' && ((sender as System.Windows.Forms.TextBox).Text.IndexOf(',') > -1 || (sender as System.Windows.Forms.TextBox).SelectionStart == 0))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '-' && (sender as System.Windows.Forms.TextBox).SelectionStart != 0)
            {
                e.Handled = true;
                return;
            }

            if ((sender as System.Windows.Forms.TextBox).Text.IndexOf('-') == 0 && (sender as System.Windows.Forms.TextBox).SelectionStart == 1 && e.KeyChar == ',')
            {
                e.Handled = true;
                return;
            }
        }

        private void pnlDisponibleModels_ControlRemoved(object sender, ControlEventArgs e)
        {
            LoadModels();
        }

        private void pnlPosciosionedModels_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (load == "off")
            {
                lblWarning.Visible = true;
                lblWarning.Text = "IMAGEN DESACTUALIZADA.";
                pbWarning.Visible = true;
                scene.ModifiedDate = DateTime.Now;
                lblLeastModification.Text = $"Última modificación: {scene.ModifiedDate.ToString("HH:mm - dd/MM/yyyy")}";
            }
        }

        private void txtFoV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar))
            {
                int num = int.Parse(txtFoV.Text + e.KeyChar);
                if (num < 1 || num > 160)
                {
                    e.Handled = true;
                }
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
        }

        private void pnlPosciosionedModels_ControlAdded(object sender, ControlEventArgs e)
        {
            if (load == "off")
            {
                lblWarning.Visible = true;
                lblWarning.Text = "IMAGEN DESACTUALIZADA.";
                pbWarning.Visible = true;
                scene.ModifiedDate = DateTime.Now;
                lblLeastModification.Text = $"Última modificación: {scene.ModifiedDate.ToString("HH:mm - dd/MM/yyyy")}";
            }
        }

        private void txtSceneName_MouseClick(object sender, MouseEventArgs e)
        {
            txtSceneName.ReadOnly = false;
            txtSceneName.Focus();
        }

        private void txtSceneName_Leave(object sender, EventArgs e)
        {
            string name = txtSceneName.Text;
            if (sceneDriver.GetScene(ClientPanel.usernameClient, txtSceneName.Text) == null)
            {
                try
                {
                    UpdateScene(scene.SceneName);
                }
                catch (InvalidSceneNameException ex)
                {
                    MessageBox.Show(ex.Message, "Ha ocurrido un error en el nombre de la escena", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSceneName.Text = scene.SceneName;
                }
            }
            else if ((sceneDriver.GetScene(ClientPanel.usernameClient, txtSceneName.Text) == null) && !name.Equals(scene.SceneName))
            {
                MessageBox.Show("Ya existe una escena con el mismo nombre.", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSceneName.Text = scene.SceneName;
            }
        }

        private void txtLookFromX_TextChanged(object sender, EventArgs e)
        {
            sameCoords();
        }

        private void txtLookFromY_TextChanged(object sender, EventArgs e)
        {
            sameCoords();
        }

        private void txtLookFromZ_TextChanged(object sender, EventArgs e)
        {
            sameCoords();
        }

        private void txtLookAtX_TextChanged(object sender, EventArgs e)
        {
            sameCoords();
        }

        private void txtLookAtY_TextChanged(object sender, EventArgs e)
        {
            sameCoords();
        }

        private void txtLookAtZ_TextChanged(object sender, EventArgs e)
        {
            sameCoords();
        }

        private void sameCoords()
        {
            if (txtLookAtX.Text.Equals(txtLookFromX.Text) && txtLookAtY.Text.Equals(txtLookFromY.Text) && txtLookAtZ.Text.Equals(txtLookFromZ.Text))
            {
                errorProvider1.SetError(btnRender, "Las coordenadas de 'Look At' y 'Look From' no pueden ser las mismas.");
                btnRender.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(btnRender, "");
                btnRender.Enabled = true;
            }
        }

        private void txtLensRadius_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtLensRadius.Text.Replace(',', '.'), out double valor))
            {
                if (valor > 0.0 && valor <= 3.0)
                {
                    btnRender.Enabled = true;
                    btnExport.Enabled = true;
                    errorProvider1.SetError(btnRender, "");
                }
                else
                {
                    errorProvider1.SetError(btnRender, "El valor de la apertua del lentre debe ser mayor estricto a 0.0 y menor o igual a 3.0");
                    btnRender.Enabled = false;
                    btnExport.Enabled = false;
                }
            }
            else
            {
                errorProvider1.SetError(btnRender, "El valor de la apertua del lentre debe ser mayor estricto a 0.0 y menor o igual a 3.0");
                btnRender.Enabled = false;
                btnExport.Enabled = false;
            }
        }

        private void txtLookFromX_MouseClick(object sender, MouseEventArgs e)
        {
            txtLookFromX.ReadOnly = false;
            txtLookFromX.Focus();
        }

        private void txtLookFromY_MouseClick(object sender, MouseEventArgs e)
        {
            txtLookFromY.ReadOnly = false;
            txtLookFromY.Focus();
        }

        private void txtLookFromZ_MouseClick(object sender, MouseEventArgs e)
        {
            txtLookFromZ.ReadOnly = false;
            txtLookFromZ.Focus();
        }

        private void txtLookAtX_MouseClick(object sender, MouseEventArgs e)
        {
            txtLookAtX.ReadOnly = false;
            txtLookAtX.Focus();
        }

        private void txtLookAtY_MouseClick(object sender, MouseEventArgs e)
        {
            txtLookAtY.ReadOnly = false;
            txtLookAtY.Focus();
        }

        private void txtLookAtZ_MouseClick(object sender, MouseEventArgs e)
        {
            txtLookAtZ.ReadOnly = false;
            txtLookAtZ.Focus();
        }

        private void txtFoV_MouseClick(object sender, MouseEventArgs e)
        {
            txtFoV.ReadOnly = false;
            txtFoV.Focus();
        }

        private void txtLensRadius_MouseClick(object sender, MouseEventArgs e)
        {
            txtLensRadius.ReadOnly = false;
            txtLensRadius.Focus();
        }

        private void txtLookFromX_Leave(object sender, EventArgs e)
        {
            scene.LookFromX = double.Parse(txtLookFromX.Text);
            Scene aScene = sceneDriver.GetScene(ClientPanel.usernameClient, txtSceneName.Text);
            if (aScene.LookFromX != scene.LookFromX)
            {
                UpdateScene();
                ChangeUpdateStatus();
            }
        }

        private void txtLookFromY_Leave(object sender, EventArgs e)
        {
            scene.LookFromY = double.Parse(txtLookFromY.Text);
            Scene aScene = sceneDriver.GetScene(ClientPanel.usernameClient, txtSceneName.Text);
            if (aScene.LookFromY != scene.LookFromY)
            {
                UpdateScene();
                ChangeUpdateStatus();
            }
        }

        private void txtLookFromZ_Leave(object sender, EventArgs e)
        {
            scene.LookFromZ = double.Parse(txtLookFromZ.Text);
            Scene aScene = sceneDriver.GetScene(ClientPanel.usernameClient, txtSceneName.Text);
            if (aScene.LookFromZ != scene.LookFromZ)
            {
                UpdateScene();
                ChangeUpdateStatus();
            }
        }

        private void txtLookAtX_Leave(object sender, EventArgs e)
        {
            scene.LookAtX = double.Parse(txtLookAtX.Text);
            Scene aScene = sceneDriver.GetScene(ClientPanel.usernameClient, txtSceneName.Text);
            if (aScene.LookAtX != scene.LookAtX)
            {
                UpdateScene();
                ChangeUpdateStatus();
            }
        }

        private void txtLookAtY_Leave(object sender, EventArgs e)
        {
            scene.LookAtY = double.Parse(txtLookAtY.Text);
            Scene aScene = sceneDriver.GetScene(ClientPanel.usernameClient, txtSceneName.Text);
            if (aScene.LookAtY != scene.LookAtY)
            {
                UpdateScene();
                ChangeUpdateStatus();
            }
        }

        private void txtLookAtZ_Leave(object sender, EventArgs e)
        {
            scene.LookAtZ = double.Parse(txtLookAtZ.Text);
            Scene aScene = sceneDriver.GetScene(ClientPanel.usernameClient, txtSceneName.Text);
            if (aScene.LookAtZ != scene.LookAtZ)
            {
                UpdateScene();
                ChangeUpdateStatus();
            }
        }

        private void txtFoV_Leave(object sender, EventArgs e)
        {
            scene.FoV = int.Parse(txtFoV.Text);
            Scene aScene = sceneDriver.GetScene(ClientPanel.usernameClient, txtSceneName.Text);
            if (aScene.FoV != scene.FoV)
            {
                UpdateScene();
                ChangeUpdateStatus();
            }
        }

        private void txtLensRadius_Leave(object sender, EventArgs e)
        {
            scene.LensRadius = double.Parse(txtLensRadius.Text);
            Scene aScene = sceneDriver.GetScene(ClientPanel.usernameClient, txtSceneName.Text);
            if (aScene.LensRadius != scene.LensRadius)
            {
                UpdateScene();
                ChangeUpdateStatus();
            }
        }

        private void UpdateScene(string oldName="none")
        {
            scene.ModifiedDate = DateTime.Now;
            lblLeastModification.Text = $"Última modificación: {scene.ModifiedDate.ToString("HH:mm - dd/MM/yyyy")}";
            if(oldName == "none")
            {
                sceneDriver.UpdateScene(scene, txtSceneName.Text);
            }
            else
            {
                scene.SceneName=txtSceneName.Text;
                sceneDriver.UpdateScene(scene, oldName);
            }
            scene = sceneDriver.GetScene(ClientPanel.usernameClient, txtSceneName.Text);
        }

        private void VerifyUpdated()
        {
            string dateTimeFormat = "HH:mm - dd/MM/yyyy";

            string dateTimeStr1 = lblLeastModification.Text.Substring(lblLeastModification.Text.IndexOf(':') + 2);
            DateTime date1 = DateTime.ParseExact(dateTimeStr1, dateTimeFormat, CultureInfo.InvariantCulture);

            if (scene.LastRender != null)
            {
                string dateTimeStr2 = lblLastRender.Text.Substring(lblLastRender.Text.IndexOf(':') + 2);
                DateTime date2 = DateTime.ParseExact(dateTimeStr2, dateTimeFormat, CultureInfo.InvariantCulture);

                bool isEqual = date1.Date == date2.Date && date1.TimeOfDay == date2.TimeOfDay;

                if (isEqual)
                {
                    pbWarning.Visible = false;
                    lblWarning.Visible = false;
                }
                else
                {
                    ChangeUpdateStatus();
                }
            }
            else
            {
                if (sceneDriver.GetPositionedModels(scene) != null)
                {
                    ChangeUpdateStatus();
                }
            }
        }

        private void ChangeUpdateStatus()
        {
            lblWarning.Text = "IMAGEN DESACTUALIZADA.";
            lblWarning.Visible = true;
            pbWarning.Visible = true;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo PNG|*.png|Archivo JPG|*.jpg|Archivo PPM|*.ppm";
            saveFileDialog.Title = "Exportar imagen";
            saveFileDialog.FileName = "imagen";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                string extension = System.IO.Path.GetExtension(fileName).ToLower();

                ImageFormat format;

                switch (extension)
                {
                    case ".png":
                        format = ImageFormat.Png;
                        IsRendered();
                        ExportPNGJPG(fileName, format);
                        break;
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        IsRendered();
                        ExportPNGJPG(fileName, format);
                        break;
                    case ".ppm":
                        IsRendered();
                        ExportPPM(fileName);
                        return;
                    default:
                        MessageBox.Show("Formato de archivo no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

            }
        }

        private void IsRendered()
        {
            if (savedPixels.Count == 0)
            {
                savedPixels = RenderGraphicEngine();
            }
        }

        private void ExportPNGJPG(string fileName, ImageFormat format)
        {
            int resolutionX = 300;
            int resolutionY = 200;

            Bitmap image = new Bitmap(resolutionX, resolutionY);

            progressBar1.Value = 0;
            progressBar1.Maximum = resolutionX * resolutionY;
            progressBar1.Step = 1;
            int progress = 0;

            float maxColorValue = float.MinValue;
            for (int j = 0; j < resolutionY; j++)
            {
                for (int i = 0; i < resolutionX; i++)
                {

                    Vector3D color = savedPixels[j][i];
                    maxColorValue = Math.Max(maxColorValue, Math.Max(color.Red, Math.Max(color.Green, color.Blue)));
                    progressBar1.PerformStep();
                    progress++;
                }
            }

            progressBar1.Value = progressBar1.Maximum;
            progressBar1.Value = 0;

            for (int j = 0; j < resolutionY; j++)
            {
                for (int i = 0; i < resolutionX; i++)
                {
                    Vector3D color = savedPixels[j][i];
                    int red = (int)(color.Red * 255 / maxColorValue);
                    int green = (int)(color.Green * 255 / maxColorValue);
                    int blue = (int)(color.Blue * 255 / maxColorValue);
                    Color pixelColor = Color.FromArgb(red, green, blue);
                    image.SetPixel(i, j, pixelColor);
                    progressBar1.PerformStep();
                    progress++;
                }
            }

            if (format == ImageFormat.Png)
            {
                image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
            }
            else if (format == ImageFormat.Jpeg)
            {
                image.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            progressBar1.Value = progressBar1.Maximum;
            progressBar1.Value = 0;

            MessageBox.Show("Imagen exportada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportPPM(string fileName)
        {
            int resolutionX = 300;
            int resolutionY = 200;

            progressBar1.Value = 0;
            progressBar1.Maximum = resolutionX * resolutionY;
            progressBar1.Step = 1;
            int progress = 0;

            string imageString = "P3\n" + resolutionX + " " + resolutionY + "\n255\n";

            for (int j = 0; j < resolutionY; j++)
            {
                for (int i = 0; i < resolutionX; i++)
                {
                    Vector3D color = savedPixels[j][i];
                    imageString += color.Red + " " + color.Green + " " + color.Blue + "\n";

                    progressBar1.PerformStep();
                    progress++;
                }
            }

            File.WriteAllText(fileName, imageString);
            progressBar1.Value = progressBar1.Maximum;
            progressBar1.Value = 0;
            MessageBox.Show("Imagen exportada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
