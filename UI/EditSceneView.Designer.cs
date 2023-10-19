namespace UI
{
    partial class EditSceneView
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
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pnlPosciosionedModels = new System.Windows.Forms.Panel();
            this.pnlDisponibleModels = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLookAtZ = new System.Windows.Forms.TextBox();
            this.txtLookAtY = new System.Windows.Forms.TextBox();
            this.txtLookAtX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLookFromZ = new System.Windows.Forms.TextBox();
            this.txtLookFromY = new System.Windows.Forms.TextBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.lblLastRender = new System.Windows.Forms.Label();
            this.btnRender = new System.Windows.Forms.Button();
            this.lblPositionedModels = new System.Windows.Forms.Label();
            this.lblScene = new System.Windows.Forms.Label();
            this.lblDisponibleModels = new System.Windows.Forms.Label();
            this.txtFoV = new System.Windows.Forms.TextBox();
            this.txtLookFromX = new System.Windows.Forms.TextBox();
            this.lblFoV = new System.Windows.Forms.Label();
            this.lblLookAt = new System.Windows.Forms.Label();
            this.lblLookFrom = new System.Windows.Forms.Label();
            this.lblLeastModification = new System.Windows.Forms.Label();
            this.txtSceneName = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.pbWarning = new System.Windows.Forms.PictureBox();
            this.picBoxImage = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbBlur = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtLensRadius = new System.Windows.Forms.TextBox();
            this.lblLensRadius = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(220, 384);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(300, 10);
            this.progressBar1.TabIndex = 58;
            // 
            // pnlPosciosionedModels
            // 
            this.pnlPosciosionedModels.AutoScroll = true;
            this.pnlPosciosionedModels.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlPosciosionedModels.Location = new System.Drawing.Point(535, 176);
            this.pnlPosciosionedModels.Name = "pnlPosciosionedModels";
            this.pnlPosciosionedModels.Size = new System.Drawing.Size(184, 208);
            this.pnlPosciosionedModels.TabIndex = 57;
            this.pnlPosciosionedModels.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlPosciosionedModels_ControlAdded);
            this.pnlPosciosionedModels.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlPosciosionedModels_ControlRemoved);
            // 
            // pnlDisponibleModels
            // 
            this.pnlDisponibleModels.AutoScroll = true;
            this.pnlDisponibleModels.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlDisponibleModels.Location = new System.Drawing.Point(24, 176);
            this.pnlDisponibleModels.Name = "pnlDisponibleModels";
            this.pnlDisponibleModels.Size = new System.Drawing.Size(183, 208);
            this.pnlDisponibleModels.TabIndex = 56;
            this.pnlDisponibleModels.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlDisponibleModels_ControlRemoved);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Z:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(231, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "X:";
            // 
            // txtLookAtZ
            // 
            this.txtLookAtZ.Location = new System.Drawing.Point(383, 108);
            this.txtLookAtZ.Name = "txtLookAtZ";
            this.txtLookAtZ.Size = new System.Drawing.Size(35, 20);
            this.txtLookAtZ.TabIndex = 50;
            this.txtLookAtZ.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtLookAtZ_MouseClick);
            this.txtLookAtZ.TextChanged += new System.EventHandler(this.txtLookAtZ_TextChanged);
            this.txtLookAtZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLookAtZ_KeyPress);
            this.txtLookAtZ.Leave += new System.EventHandler(this.txtLookAtZ_Leave);
            // 
            // txtLookAtY
            // 
            this.txtLookAtY.Location = new System.Drawing.Point(316, 108);
            this.txtLookAtY.Name = "txtLookAtY";
            this.txtLookAtY.Size = new System.Drawing.Size(35, 20);
            this.txtLookAtY.TabIndex = 48;
            this.txtLookAtY.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtLookAtY_MouseClick);
            this.txtLookAtY.TextChanged += new System.EventHandler(this.txtLookAtY_TextChanged);
            this.txtLookAtY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLookAtY_KeyPress);
            this.txtLookAtY.Leave += new System.EventHandler(this.txtLookAtY_Leave);
            // 
            // txtLookAtX
            // 
            this.txtLookAtX.Location = new System.Drawing.Point(254, 108);
            this.txtLookAtX.Name = "txtLookAtX";
            this.txtLookAtX.Size = new System.Drawing.Size(35, 20);
            this.txtLookAtX.TabIndex = 46;
            this.txtLookAtX.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtLookAtX_MouseClick);
            this.txtLookAtX.TextChanged += new System.EventHandler(this.txtLookAtX_TextChanged);
            this.txtLookAtX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLookAtX_KeyPress);
            this.txtLookAtX.Leave += new System.EventHandler(this.txtLookAtX_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Z:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "X:";
            // 
            // txtLookFromZ
            // 
            this.txtLookFromZ.Location = new System.Drawing.Point(172, 108);
            this.txtLookFromZ.Name = "txtLookFromZ";
            this.txtLookFromZ.Size = new System.Drawing.Size(35, 20);
            this.txtLookFromZ.TabIndex = 44;
            this.txtLookFromZ.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtLookFromZ_MouseClick);
            this.txtLookFromZ.TextChanged += new System.EventHandler(this.txtLookFromZ_TextChanged);
            this.txtLookFromZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLookFromZ_KeyPress);
            this.txtLookFromZ.Leave += new System.EventHandler(this.txtLookFromZ_Leave);
            // 
            // txtLookFromY
            // 
            this.txtLookFromY.Location = new System.Drawing.Point(105, 108);
            this.txtLookFromY.Name = "txtLookFromY";
            this.txtLookFromY.Size = new System.Drawing.Size(35, 20);
            this.txtLookFromY.TabIndex = 42;
            this.txtLookFromY.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtLookFromY_MouseClick);
            this.txtLookFromY.TextChanged += new System.EventHandler(this.txtLookFromY_TextChanged);
            this.txtLookFromY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLookFromY_KeyPress);
            this.txtLookFromY.Leave += new System.EventHandler(this.txtLookFromY_Leave);
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Location = new System.Drawing.Point(547, 395);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(183, 13);
            this.lblWarning.TabIndex = 60;
            this.lblWarning.Text = "AVISO IMAGEN DESACTUALIZADA";
            this.lblWarning.Visible = false;
            // 
            // lblLastRender
            // 
            this.lblLastRender.AutoSize = true;
            this.lblLastRender.Location = new System.Drawing.Point(217, 397);
            this.lblLastRender.Name = "lblLastRender";
            this.lblLastRender.Size = new System.Drawing.Size(194, 13);
            this.lblLastRender.TabIndex = 59;
            this.lblLastRender.Text = "Último renderizado: 00:00 - 01/01/2023";
            // 
            // btnRender
            // 
            this.btnRender.Location = new System.Drawing.Point(445, 155);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(75, 23);
            this.btnRender.TabIndex = 54;
            this.btnRender.Text = "Renderizar";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // lblPositionedModels
            // 
            this.lblPositionedModels.AutoSize = true;
            this.lblPositionedModels.Location = new System.Drawing.Point(532, 160);
            this.lblPositionedModels.Name = "lblPositionedModels";
            this.lblPositionedModels.Size = new System.Drawing.Size(112, 13);
            this.lblPositionedModels.TabIndex = 55;
            this.lblPositionedModels.Text = "Modelos posicionados";
            // 
            // lblScene
            // 
            this.lblScene.AutoSize = true;
            this.lblScene.Location = new System.Drawing.Point(217, 160);
            this.lblScene.Name = "lblScene";
            this.lblScene.Size = new System.Drawing.Size(43, 13);
            this.lblScene.TabIndex = 53;
            this.lblScene.Text = "Escena";
            // 
            // lblDisponibleModels
            // 
            this.lblDisponibleModels.AutoSize = true;
            this.lblDisponibleModels.Location = new System.Drawing.Point(21, 160);
            this.lblDisponibleModels.Name = "lblDisponibleModels";
            this.lblDisponibleModels.Size = new System.Drawing.Size(102, 13);
            this.lblDisponibleModels.TabIndex = 52;
            this.lblDisponibleModels.Text = "Modelos disponibles";
            // 
            // txtFoV
            // 
            this.txtFoV.Location = new System.Drawing.Point(449, 108);
            this.txtFoV.Name = "txtFoV";
            this.txtFoV.Size = new System.Drawing.Size(75, 20);
            this.txtFoV.TabIndex = 51;
            this.txtFoV.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtFoV_MouseClick);
            this.txtFoV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFoV_KeyPress);
            this.txtFoV.Leave += new System.EventHandler(this.txtFoV_Leave);
            // 
            // txtLookFromX
            // 
            this.txtLookFromX.Location = new System.Drawing.Point(43, 108);
            this.txtLookFromX.Name = "txtLookFromX";
            this.txtLookFromX.Size = new System.Drawing.Size(35, 20);
            this.txtLookFromX.TabIndex = 40;
            this.txtLookFromX.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtLookFromX_MouseClick);
            this.txtLookFromX.TextChanged += new System.EventHandler(this.txtLookFromX_TextChanged);
            this.txtLookFromX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLookFromX_KeyPress);
            this.txtLookFromX.Leave += new System.EventHandler(this.txtLookFromX_Leave);
            // 
            // lblFoV
            // 
            this.lblFoV.AutoSize = true;
            this.lblFoV.Location = new System.Drawing.Point(446, 81);
            this.lblFoV.Name = "lblFoV";
            this.lblFoV.Size = new System.Drawing.Size(26, 13);
            this.lblFoV.TabIndex = 38;
            this.lblFoV.Text = "FoV";
            // 
            // lblLookAt
            // 
            this.lblLookAt.AutoSize = true;
            this.lblLookAt.Location = new System.Drawing.Point(231, 81);
            this.lblLookAt.Name = "lblLookAt";
            this.lblLookAt.Size = new System.Drawing.Size(44, 13);
            this.lblLookAt.TabIndex = 37;
            this.lblLookAt.Text = "Look At";
            // 
            // lblLookFrom
            // 
            this.lblLookFrom.AutoSize = true;
            this.lblLookFrom.Location = new System.Drawing.Point(21, 81);
            this.lblLookFrom.Name = "lblLookFrom";
            this.lblLookFrom.Size = new System.Drawing.Size(57, 13);
            this.lblLookFrom.TabIndex = 36;
            this.lblLookFrom.Text = "Look From";
            // 
            // lblLeastModification
            // 
            this.lblLeastModification.AutoSize = true;
            this.lblLeastModification.Location = new System.Drawing.Point(533, 29);
            this.lblLeastModification.Name = "lblLeastModification";
            this.lblLeastModification.Size = new System.Drawing.Size(186, 13);
            this.lblLeastModification.TabIndex = 35;
            this.lblLeastModification.Text = "Última modificación: 00:00 - 01/01/23";
            // 
            // txtSceneName
            // 
            this.txtSceneName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSceneName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSceneName.Location = new System.Drawing.Point(118, 26);
            this.txtSceneName.Name = "txtSceneName";
            this.txtSceneName.Size = new System.Drawing.Size(270, 13);
            this.txtSceneName.TabIndex = 34;
            this.txtSceneName.Text = "Nombre de la escena";
            this.txtSceneName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSceneName_MouseClick);
            this.txtSceneName.Leave += new System.EventHandler(this.txtSceneName_Leave);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(24, 24);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 33;
            this.btnBack.Text = "Atras";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pbWarning
            // 
            this.pbWarning.BackgroundImage = global::UI.Properties.Resources._2682803_attention_erro_exclamation_mark_warn_icon__1_;
            this.pbWarning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbWarning.Location = new System.Drawing.Point(526, 390);
            this.pbWarning.Name = "pbWarning";
            this.pbWarning.Size = new System.Drawing.Size(23, 20);
            this.pbWarning.TabIndex = 62;
            this.pbWarning.TabStop = false;
            this.pbWarning.Visible = false;
            // 
            // picBoxImage
            // 
            this.picBoxImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picBoxImage.BackColor = System.Drawing.Color.White;
            this.picBoxImage.Location = new System.Drawing.Point(220, 184);
            this.picBoxImage.Name = "picBoxImage";
            this.picBoxImage.Size = new System.Drawing.Size(300, 200);
            this.picBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxImage.TabIndex = 61;
            this.picBoxImage.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cbBlur
            // 
            this.cbBlur.AutoSize = true;
            this.cbBlur.Location = new System.Drawing.Point(650, 110);
            this.cbBlur.Name = "cbBlur";
            this.cbBlur.Size = new System.Drawing.Size(84, 17);
            this.cbBlur.TabIndex = 70;
            this.cbBlur.Text = "Desenfoque";
            this.cbBlur.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(445, 397);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 69;
            this.btnExport.Text = "Exportar";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtLensRadius
            // 
            this.txtLensRadius.Location = new System.Drawing.Point(550, 108);
            this.txtLensRadius.Name = "txtLensRadius";
            this.txtLensRadius.Size = new System.Drawing.Size(88, 20);
            this.txtLensRadius.TabIndex = 68;
            this.txtLensRadius.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtLensRadius_MouseClick);
            this.txtLensRadius.TextChanged += new System.EventHandler(this.txtLensRadius_TextChanged);
            this.txtLensRadius.Leave += new System.EventHandler(this.txtLensRadius_Leave);
            // 
            // lblLensRadius
            // 
            this.lblLensRadius.AutoSize = true;
            this.lblLensRadius.Location = new System.Drawing.Point(547, 81);
            this.lblLensRadius.Name = "lblLensRadius";
            this.lblLensRadius.Size = new System.Drawing.Size(90, 13);
            this.lblLensRadius.TabIndex = 67;
            this.lblLensRadius.Text = "Apertura del lente";
            // 
            // EditSceneView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbBlur);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.txtLensRadius);
            this.Controls.Add(this.lblLensRadius);
            this.Controls.Add(this.pbWarning);
            this.Controls.Add(this.picBoxImage);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pnlPosciosionedModels);
            this.Controls.Add(this.pnlDisponibleModels);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLookAtZ);
            this.Controls.Add(this.txtLookAtY);
            this.Controls.Add(this.txtLookAtX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLookFromZ);
            this.Controls.Add(this.txtLookFromY);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.lblLastRender);
            this.Controls.Add(this.btnRender);
            this.Controls.Add(this.lblPositionedModels);
            this.Controls.Add(this.lblScene);
            this.Controls.Add(this.lblDisponibleModels);
            this.Controls.Add(this.txtFoV);
            this.Controls.Add(this.txtLookFromX);
            this.Controls.Add(this.lblFoV);
            this.Controls.Add(this.lblLookAt);
            this.Controls.Add(this.lblLookFrom);
            this.Controls.Add(this.lblLeastModification);
            this.Controls.Add(this.txtSceneName);
            this.Controls.Add(this.btnBack);
            this.Name = "EditSceneView";
            this.Size = new System.Drawing.Size(750, 435);
            this.Load += new System.EventHandler(this.EditSceneView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbWarning;
        private System.Windows.Forms.PictureBox picBoxImage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel pnlPosciosionedModels;
        private System.Windows.Forms.Panel pnlDisponibleModels;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLookAtZ;
        private System.Windows.Forms.TextBox txtLookAtY;
        private System.Windows.Forms.TextBox txtLookAtX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLookFromZ;
        private System.Windows.Forms.TextBox txtLookFromY;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label lblLastRender;
        private System.Windows.Forms.Button btnRender;
        private System.Windows.Forms.Label lblPositionedModels;
        private System.Windows.Forms.Label lblScene;
        private System.Windows.Forms.Label lblDisponibleModels;
        private System.Windows.Forms.TextBox txtFoV;
        private System.Windows.Forms.TextBox txtLookFromX;
        private System.Windows.Forms.Label lblFoV;
        private System.Windows.Forms.Label lblLookAt;
        private System.Windows.Forms.Label lblLookFrom;
        private System.Windows.Forms.Label lblLeastModification;
        private System.Windows.Forms.TextBox txtSceneName;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox cbBlur;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtLensRadius;
        private System.Windows.Forms.Label lblLensRadius;
    }
}
