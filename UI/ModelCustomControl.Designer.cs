namespace UI
{
    partial class ModelCustomControl
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
            this.picBoxImage = new System.Windows.Forms.PictureBox();
            this.btnDeleteModel = new System.Windows.Forms.Button();
            this.lblModelMaterial = new System.Windows.Forms.Label();
            this.lblModelFigure = new System.Windows.Forms.Label();
            this.lblModelName = new System.Windows.Forms.Label();
            this.btnColorModel = new System.Windows.Forms.Button();
            this.pbPreviewModel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewModel)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxImage
            // 
            this.picBoxImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picBoxImage.Location = new System.Drawing.Point(-33, 4);
            this.picBoxImage.Name = "picBoxImage";
            this.picBoxImage.Size = new System.Drawing.Size(88, 83);
            this.picBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxImage.TabIndex = 14;
            this.picBoxImage.TabStop = false;
            this.picBoxImage.Visible = false;
            // 
            // btnDeleteModel
            // 
            this.btnDeleteModel.BackColor = System.Drawing.Color.RosyBrown;
            this.btnDeleteModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteModel.Location = new System.Drawing.Point(288, 35);
            this.btnDeleteModel.Name = "btnDeleteModel";
            this.btnDeleteModel.Size = new System.Drawing.Size(58, 46);
            this.btnDeleteModel.TabIndex = 13;
            this.btnDeleteModel.Text = "X";
            this.btnDeleteModel.UseVisualStyleBackColor = false;
            this.btnDeleteModel.Click += new System.EventHandler(this.btnDeleteModel_Click);
            // 
            // lblModelMaterial
            // 
            this.lblModelMaterial.AutoSize = true;
            this.lblModelMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelMaterial.Location = new System.Drawing.Point(110, 60);
            this.lblModelMaterial.Name = "lblModelMaterial";
            this.lblModelMaterial.Size = new System.Drawing.Size(61, 16);
            this.lblModelMaterial.TabIndex = 12;
            this.lblModelMaterial.Text = "Material: ";
            // 
            // lblModelFigure
            // 
            this.lblModelFigure.AutoSize = true;
            this.lblModelFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelFigure.Location = new System.Drawing.Point(110, 38);
            this.lblModelFigure.Name = "lblModelFigure";
            this.lblModelFigure.Size = new System.Drawing.Size(51, 16);
            this.lblModelFigure.TabIndex = 11;
            this.lblModelFigure.Text = "Figure: ";
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelName.Location = new System.Drawing.Point(108, 9);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(146, 29);
            this.lblModelName.TabIndex = 9;
            this.lblModelName.Text = "ModelName";
            // 
            // btnColorModel
            // 
            this.btnColorModel.Location = new System.Drawing.Point(65, 2);
            this.btnColorModel.Name = "btnColorModel";
            this.btnColorModel.Size = new System.Drawing.Size(37, 36);
            this.btnColorModel.TabIndex = 8;
            this.btnColorModel.UseVisualStyleBackColor = true;
            // 
            // pbPreviewModel
            // 
            this.pbPreviewModel.BackgroundImage = global::UI.Properties.Resources._6703098_3d_shape_3d_sphere_geometric_geometry_round_icon;
            this.pbPreviewModel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPreviewModel.Location = new System.Drawing.Point(3, 5);
            this.pbPreviewModel.Name = "pbPreviewModel";
            this.pbPreviewModel.Size = new System.Drawing.Size(88, 82);
            this.pbPreviewModel.TabIndex = 10;
            this.pbPreviewModel.TabStop = false;
            // 
            // ModelCustomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picBoxImage);
            this.Controls.Add(this.btnDeleteModel);
            this.Controls.Add(this.lblModelMaterial);
            this.Controls.Add(this.lblModelFigure);
            this.Controls.Add(this.lblModelName);
            this.Controls.Add(this.btnColorModel);
            this.Controls.Add(this.pbPreviewModel);
            this.Name = "ModelCustomControl";
            this.Size = new System.Drawing.Size(349, 88);
            this.Load += new System.EventHandler(this.ModelCustomControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewModel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxImage;
        private System.Windows.Forms.Button btnDeleteModel;
        private System.Windows.Forms.Label lblModelMaterial;
        private System.Windows.Forms.Label lblModelFigure;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.Button btnColorModel;
        private System.Windows.Forms.PictureBox pbPreviewModel;
    }
}
