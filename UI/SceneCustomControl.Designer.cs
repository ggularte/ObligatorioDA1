namespace UI
{
    partial class SceneCustomControl
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
            this.btnDeleteScene = new System.Windows.Forms.Button();
            this.lblLastModificationDate = new System.Windows.Forms.Label();
            this.lblSceneName = new System.Windows.Forms.Label();
            this.pbPreviewScene = new System.Windows.Forms.PictureBox();
            this.picBoxImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewScene)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteScene
            // 
            this.btnDeleteScene.BackColor = System.Drawing.Color.RosyBrown;
            this.btnDeleteScene.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteScene.Location = new System.Drawing.Point(432, 29);
            this.btnDeleteScene.Name = "btnDeleteScene";
            this.btnDeleteScene.Size = new System.Drawing.Size(58, 46);
            this.btnDeleteScene.TabIndex = 16;
            this.btnDeleteScene.Text = "X";
            this.btnDeleteScene.UseVisualStyleBackColor = false;
            this.btnDeleteScene.Click += new System.EventHandler(this.btnDeleteScene_Click);
            // 
            // lblLastModificationDate
            // 
            this.lblLastModificationDate.AutoSize = true;
            this.lblLastModificationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastModificationDate.Location = new System.Drawing.Point(131, 43);
            this.lblLastModificationDate.Name = "lblLastModificationDate";
            this.lblLastModificationDate.Size = new System.Drawing.Size(218, 16);
            this.lblLastModificationDate.TabIndex = 15;
            this.lblLastModificationDate.Text = "Last modification: 00:00 - 01/01/2023";
            // 
            // lblSceneName
            // 
            this.lblSceneName.AutoSize = true;
            this.lblSceneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSceneName.Location = new System.Drawing.Point(129, 3);
            this.lblSceneName.Name = "lblSceneName";
            this.lblSceneName.Size = new System.Drawing.Size(147, 29);
            this.lblSceneName.TabIndex = 14;
            this.lblSceneName.Text = "SceneName";
            // 
            // pbPreviewScene
            // 
            this.pbPreviewScene.BackgroundImage = global::UI.Properties.Resources._6646203_3d_reality_room_scene_virtual_icon__4_;
            this.pbPreviewScene.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPreviewScene.Location = new System.Drawing.Point(3, 3);
            this.pbPreviewScene.Name = "pbPreviewScene";
            this.pbPreviewScene.Size = new System.Drawing.Size(122, 82);
            this.pbPreviewScene.TabIndex = 18;
            this.pbPreviewScene.TabStop = false;
            // 
            // picBoxImage
            // 
            this.picBoxImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picBoxImage.Location = new System.Drawing.Point(3, 2);
            this.picBoxImage.Name = "picBoxImage";
            this.picBoxImage.Size = new System.Drawing.Size(122, 83);
            this.picBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxImage.TabIndex = 17;
            this.picBoxImage.TabStop = false;
            this.picBoxImage.Visible = false;
            // 
            // SceneCustomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picBoxImage);
            this.Controls.Add(this.pbPreviewScene);
            this.Controls.Add(this.btnDeleteScene);
            this.Controls.Add(this.lblLastModificationDate);
            this.Controls.Add(this.lblSceneName);
            this.Name = "SceneCustomControl";
            this.Size = new System.Drawing.Size(493, 88);
            this.Click += new System.EventHandler(this.SceneCustomControl_Click);
            this.MouseEnter += new System.EventHandler(this.SceneCustomControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.SceneCustomControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewScene)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxImage;
        private System.Windows.Forms.Button btnDeleteScene;
        private System.Windows.Forms.Label lblLastModificationDate;
        private System.Windows.Forms.Label lblSceneName;
        private System.Windows.Forms.PictureBox pbPreviewScene;
    }
}
