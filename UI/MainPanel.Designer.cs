namespace UI
{
    partial class MainPanel
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.currentView = new System.Windows.Forms.Panel();
            this.pbUsericon = new System.Windows.Forms.PictureBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.btnScenes = new System.Windows.Forms.Button();
            this.btnModels = new System.Windows.Forms.Button();
            this.btnMaterials = new System.Windows.Forms.Button();
            this.btnFigures = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsericon)).BeginInit();
            this.SuspendLayout();
            // 
            // currentView
            // 
            this.currentView.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.currentView.Location = new System.Drawing.Point(214, -4);
            this.currentView.Name = "currentView";
            this.currentView.Size = new System.Drawing.Size(750, 435);
            this.currentView.TabIndex = 7;
            // 
            // pbUsericon
            // 
            this.pbUsericon.BackgroundImage = global::UI.Properties.Resources._172626_user_male_icon__1_;
            this.pbUsericon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbUsericon.Location = new System.Drawing.Point(5, 11);
            this.pbUsericon.Name = "pbUsericon";
            this.pbUsericon.Size = new System.Drawing.Size(30, 25);
            this.pbUsericon.TabIndex = 15;
            this.pbUsericon.TabStop = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUsuario.Location = new System.Drawing.Point(36, 9);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(172, 31);
            this.lblUsuario.TabIndex = 9;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSignOut
            // 
            this.btnSignOut.Location = new System.Drawing.Point(66, 402);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(75, 23);
            this.btnSignOut.TabIndex = 14;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = true;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // btnScenes
            // 
            this.btnScenes.Location = new System.Drawing.Point(44, 209);
            this.btnScenes.Name = "btnScenes";
            this.btnScenes.Size = new System.Drawing.Size(129, 23);
            this.btnScenes.TabIndex = 13;
            this.btnScenes.Text = "Escenas";
            this.btnScenes.UseVisualStyleBackColor = true;
            this.btnScenes.Click += new System.EventHandler(this.btnScenes_Click);
            // 
            // btnModels
            // 
            this.btnModels.Location = new System.Drawing.Point(44, 170);
            this.btnModels.Name = "btnModels";
            this.btnModels.Size = new System.Drawing.Size(129, 23);
            this.btnModels.TabIndex = 12;
            this.btnModels.Text = "Modelos";
            this.btnModels.UseVisualStyleBackColor = true;
            this.btnModels.Click += new System.EventHandler(this.btnModels_Click);
            // 
            // btnMaterials
            // 
            this.btnMaterials.Location = new System.Drawing.Point(44, 130);
            this.btnMaterials.Name = "btnMaterials";
            this.btnMaterials.Size = new System.Drawing.Size(129, 23);
            this.btnMaterials.TabIndex = 11;
            this.btnMaterials.Text = "Materiales";
            this.btnMaterials.UseVisualStyleBackColor = true;
            this.btnMaterials.Click += new System.EventHandler(this.btnMaterials_Click);
            // 
            // btnFigures
            // 
            this.btnFigures.Location = new System.Drawing.Point(44, 92);
            this.btnFigures.Name = "btnFigures";
            this.btnFigures.Size = new System.Drawing.Size(129, 23);
            this.btnFigures.TabIndex = 10;
            this.btnFigures.Text = "Figuras";
            this.btnFigures.UseVisualStyleBackColor = true;
            this.btnFigures.Click += new System.EventHandler(this.btnFigures_Click);
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 431);
            this.Controls.Add(this.pbUsericon);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnScenes);
            this.Controls.Add(this.btnModels);
            this.Controls.Add(this.btnMaterials);
            this.Controls.Add(this.btnFigures);
            this.Controls.Add(this.currentView);
            this.Name = "MainPanel";
            this.Text = "3D Renderer con Ray Tracing";
            this.Load += new System.EventHandler(this.MainPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbUsericon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel currentView;
        private System.Windows.Forms.PictureBox pbUsericon;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Button btnScenes;
        private System.Windows.Forms.Button btnModels;
        private System.Windows.Forms.Button btnMaterials;
        private System.Windows.Forms.Button btnFigures;
    }
}

