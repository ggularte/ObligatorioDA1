namespace UI
{
    partial class DisponibleModelCustomControl
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
            this.lblModelName = new System.Windows.Forms.Label();
            this.picBoxImage = new System.Windows.Forms.PictureBox();
            this.pbPreviewModel = new System.Windows.Forms.PictureBox();
            this.btnColorModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewModel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelName.Location = new System.Drawing.Point(72, 18);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(94, 20);
            this.lblModelName.TabIndex = 10;
            this.lblModelName.Text = "ModelName";
            // 
            // picBoxImage
            // 
            this.picBoxImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picBoxImage.Location = new System.Drawing.Point(12, 3);
            this.picBoxImage.Name = "picBoxImage";
            this.picBoxImage.Size = new System.Drawing.Size(54, 49);
            this.picBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxImage.TabIndex = 11;
            this.picBoxImage.TabStop = false;
            this.picBoxImage.Visible = false;
            // 
            // pbPreviewModel
            // 
            this.pbPreviewModel.BackgroundImage = global::UI.Properties.Resources._6703098_3d_shape_3d_sphere_geometric_geometry_round_icon;
            this.pbPreviewModel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPreviewModel.Location = new System.Drawing.Point(2, 3);
            this.pbPreviewModel.Name = "pbPreviewModel";
            this.pbPreviewModel.Size = new System.Drawing.Size(54, 51);
            this.pbPreviewModel.TabIndex = 9;
            this.pbPreviewModel.TabStop = false;
            // 
            // btnColorModel
            // 
            this.btnColorModel.Location = new System.Drawing.Point(43, 0);
            this.btnColorModel.Name = "btnColorModel";
            this.btnColorModel.Size = new System.Drawing.Size(23, 23);
            this.btnColorModel.TabIndex = 12;
            this.btnColorModel.UseVisualStyleBackColor = true;
            // 
            // DisponibleModelCustomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picBoxImage);
            this.Controls.Add(this.btnColorModel);
            this.Controls.Add(this.lblModelName);
            this.Controls.Add(this.pbPreviewModel);
            this.Name = "DisponibleModelCustomControl";
            this.Size = new System.Drawing.Size(191, 55);
            this.Click += new System.EventHandler(this.DisponibleModelCustomControl_Click);
            this.MouseEnter += new System.EventHandler(this.DisponibleModelCustomControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.DisponibleModelCustomControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewModel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxImage;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.PictureBox pbPreviewModel;
        private System.Windows.Forms.Button btnColorModel;
    }
}
