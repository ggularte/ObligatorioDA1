namespace UI
{
    partial class PositionedModelCustomControl
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
            this.btnDeleteModel = new System.Windows.Forms.Button();
            this.lblCoords = new System.Windows.Forms.Label();
            this.lblModelName = new System.Windows.Forms.Label();
            this.picBoxImage = new System.Windows.Forms.PictureBox();
            this.pbPreviewModel = new System.Windows.Forms.PictureBox();
            this.lblModelID = new System.Windows.Forms.Label();
            this.btnColorModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewModel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteModel
            // 
            this.btnDeleteModel.BackColor = System.Drawing.Color.RosyBrown;
            this.btnDeleteModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteModel.Location = new System.Drawing.Point(159, 24);
            this.btnDeleteModel.Name = "btnDeleteModel";
            this.btnDeleteModel.Size = new System.Drawing.Size(28, 24);
            this.btnDeleteModel.TabIndex = 15;
            this.btnDeleteModel.Text = "X";
            this.btnDeleteModel.UseVisualStyleBackColor = false;
            this.btnDeleteModel.Click += new System.EventHandler(this.btnDeleteModel_Click);
            // 
            // lblCoords
            // 
            this.lblCoords.AutoSize = true;
            this.lblCoords.Location = new System.Drawing.Point(75, 30);
            this.lblCoords.Name = "lblCoords";
            this.lblCoords.Size = new System.Drawing.Size(46, 13);
            this.lblCoords.TabIndex = 14;
            this.lblCoords.Text = "(X, Y, Z)";
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelName.Location = new System.Drawing.Point(74, 3);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(94, 20);
            this.lblModelName.TabIndex = 13;
            this.lblModelName.Text = "ModelName";
            // 
            // picBoxImage
            // 
            this.picBoxImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picBoxImage.Location = new System.Drawing.Point(16, 2);
            this.picBoxImage.Name = "picBoxImage";
            this.picBoxImage.Size = new System.Drawing.Size(53, 49);
            this.picBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxImage.TabIndex = 17;
            this.picBoxImage.TabStop = false;
            this.picBoxImage.Visible = false;
            // 
            // pbPreviewModel
            // 
            this.pbPreviewModel.BackgroundImage = global::UI.Properties.Resources._6703098_3d_shape_3d_sphere_geometric_geometry_round_icon;
            this.pbPreviewModel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPreviewModel.Location = new System.Drawing.Point(4, 2);
            this.pbPreviewModel.Name = "pbPreviewModel";
            this.pbPreviewModel.Size = new System.Drawing.Size(54, 51);
            this.pbPreviewModel.TabIndex = 16;
            this.pbPreviewModel.TabStop = false;
            // 
            // lblModelID
            // 
            this.lblModelID.AutoSize = true;
            this.lblModelID.Location = new System.Drawing.Point(23, 27);
            this.lblModelID.Name = "lblModelID";
            this.lblModelID.Size = new System.Drawing.Size(46, 13);
            this.lblModelID.TabIndex = 19;
            this.lblModelID.Text = "modelID";
            this.lblModelID.Visible = false;
            // 
            // btnColorModel
            // 
            this.btnColorModel.Location = new System.Drawing.Point(45, 0);
            this.btnColorModel.Name = "btnColorModel";
            this.btnColorModel.Size = new System.Drawing.Size(23, 23);
            this.btnColorModel.TabIndex = 18;
            this.btnColorModel.UseVisualStyleBackColor = true;
            // 
            // PositionedModelCustomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picBoxImage);
            this.Controls.Add(this.lblModelID);
            this.Controls.Add(this.btnColorModel);
            this.Controls.Add(this.btnDeleteModel);
            this.Controls.Add(this.lblCoords);
            this.Controls.Add(this.lblModelName);
            this.Controls.Add(this.pbPreviewModel);
            this.Name = "PositionedModelCustomControl";
            this.Size = new System.Drawing.Size(216, 55);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewModel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxImage;
        private System.Windows.Forms.Button btnDeleteModel;
        private System.Windows.Forms.Label lblCoords;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.PictureBox pbPreviewModel;
        private System.Windows.Forms.Label lblModelID;
        private System.Windows.Forms.Button btnColorModel;
    }
}
