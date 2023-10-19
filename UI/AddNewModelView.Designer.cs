namespace UI
{
    partial class AddNewModelView
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveModel = new System.Windows.Forms.Button();
            this.cbGeneratePreview = new System.Windows.Forms.CheckBox();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.cmbModelMaterial = new System.Windows.Forms.ComboBox();
            this.cmbModelFigure = new System.Windows.Forms.ComboBox();
            this.lblModelMaterial = new System.Windows.Forms.Label();
            this.lblModelFigure = new System.Windows.Forms.Label();
            this.lblModelName = new System.Windows.Forms.Label();
            this.lblNewModel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.btnColor);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSaveModel);
            this.panel1.Controls.Add(this.cbGeneratePreview);
            this.panel1.Controls.Add(this.txtModelName);
            this.panel1.Controls.Add(this.cmbModelMaterial);
            this.panel1.Controls.Add(this.cmbModelFigure);
            this.panel1.Controls.Add(this.lblModelMaterial);
            this.panel1.Controls.Add(this.lblModelFigure);
            this.panel1.Controls.Add(this.lblModelName);
            this.panel1.Controls.Add(this.lblNewModel);
            this.panel1.Location = new System.Drawing.Point(165, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 296);
            this.panel1.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 284);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(420, 12);
            this.progressBar1.TabIndex = 11;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(328, 185);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(25, 23);
            this.btnColor.TabIndex = 7;
            this.btnColor.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(223, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveModel
            // 
            this.btnSaveModel.Location = new System.Drawing.Point(104, 257);
            this.btnSaveModel.Name = "btnSaveModel";
            this.btnSaveModel.Size = new System.Drawing.Size(99, 23);
            this.btnSaveModel.TabIndex = 9;
            this.btnSaveModel.Text = "Guardar";
            this.btnSaveModel.UseVisualStyleBackColor = true;
            this.btnSaveModel.Click += new System.EventHandler(this.btnSaveModel_Click);
            // 
            // cbGeneratePreview
            // 
            this.cbGeneratePreview.AutoSize = true;
            this.cbGeneratePreview.Checked = true;
            this.cbGeneratePreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGeneratePreview.Location = new System.Drawing.Point(84, 224);
            this.cbGeneratePreview.Name = "cbGeneratePreview";
            this.cbGeneratePreview.Size = new System.Drawing.Size(154, 17);
            this.cbGeneratePreview.TabIndex = 8;
            this.cbGeneratePreview.Text = "Generar preview al guardar";
            this.cbGeneratePreview.UseVisualStyleBackColor = true;
            // 
            // txtModelName
            // 
            this.txtModelName.Location = new System.Drawing.Point(84, 79);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(238, 20);
            this.txtModelName.TabIndex = 2;
            // 
            // cmbModelMaterial
            // 
            this.cmbModelMaterial.FormattingEnabled = true;
            this.cmbModelMaterial.Location = new System.Drawing.Point(84, 185);
            this.cmbModelMaterial.Name = "cmbModelMaterial";
            this.cmbModelMaterial.Size = new System.Drawing.Size(238, 21);
            this.cmbModelMaterial.TabIndex = 6;
            this.cmbModelMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbModelMaterial_SelectedIndexChanged);
            // 
            // cmbModelFigure
            // 
            this.cmbModelFigure.FormattingEnabled = true;
            this.cmbModelFigure.Location = new System.Drawing.Point(84, 131);
            this.cmbModelFigure.Name = "cmbModelFigure";
            this.cmbModelFigure.Size = new System.Drawing.Size(238, 21);
            this.cmbModelFigure.TabIndex = 4;
            // 
            // lblModelMaterial
            // 
            this.lblModelMaterial.AutoSize = true;
            this.lblModelMaterial.Location = new System.Drawing.Point(81, 169);
            this.lblModelMaterial.Name = "lblModelMaterial";
            this.lblModelMaterial.Size = new System.Drawing.Size(44, 13);
            this.lblModelMaterial.TabIndex = 5;
            this.lblModelMaterial.Text = "Material";
            // 
            // lblModelFigure
            // 
            this.lblModelFigure.AutoSize = true;
            this.lblModelFigure.Location = new System.Drawing.Point(81, 115);
            this.lblModelFigure.Name = "lblModelFigure";
            this.lblModelFigure.Size = new System.Drawing.Size(36, 13);
            this.lblModelFigure.TabIndex = 3;
            this.lblModelFigure.Text = "Figura";
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Location = new System.Drawing.Point(81, 63);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(44, 13);
            this.lblModelName.TabIndex = 1;
            this.lblModelName.Text = "Nombre";
            // 
            // lblNewModel
            // 
            this.lblNewModel.AutoSize = true;
            this.lblNewModel.Location = new System.Drawing.Point(168, 16);
            this.lblNewModel.Name = "lblNewModel";
            this.lblNewModel.Size = new System.Drawing.Size(77, 13);
            this.lblNewModel.TabIndex = 0;
            this.lblNewModel.Text = "Nuevo Modelo";
            // 
            // AddNewModelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AddNewModelView";
            this.Size = new System.Drawing.Size(750, 435);
            this.Load += new System.EventHandler(this.AddNewModelView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveModel;
        private System.Windows.Forms.CheckBox cbGeneratePreview;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.ComboBox cmbModelMaterial;
        private System.Windows.Forms.ComboBox cmbModelFigure;
        private System.Windows.Forms.Label lblModelMaterial;
        private System.Windows.Forms.Label lblModelFigure;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.Label lblNewModel;
    }
}
