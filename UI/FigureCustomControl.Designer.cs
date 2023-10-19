namespace UI
{
    partial class FigureCustomControl
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
            this.btnDeleteFigure = new System.Windows.Forms.Button();
            this.lblFigureRadio = new System.Windows.Forms.Label();
            this.lblFigureName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteFigure
            // 
            this.btnDeleteFigure.BackColor = System.Drawing.Color.RosyBrown;
            this.btnDeleteFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteFigure.Location = new System.Drawing.Point(287, 24);
            this.btnDeleteFigure.Name = "btnDeleteFigure";
            this.btnDeleteFigure.Size = new System.Drawing.Size(58, 46);
            this.btnDeleteFigure.TabIndex = 6;
            this.btnDeleteFigure.Text = "X";
            this.btnDeleteFigure.UseVisualStyleBackColor = false;
            this.btnDeleteFigure.Click += new System.EventHandler(this.btnDeleteFigure_Click);
            // 
            // lblFigureRadio
            // 
            this.lblFigureRadio.AutoSize = true;
            this.lblFigureRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFigureRadio.Location = new System.Drawing.Point(99, 50);
            this.lblFigureRadio.Name = "lblFigureRadio";
            this.lblFigureRadio.Size = new System.Drawing.Size(47, 16);
            this.lblFigureRadio.TabIndex = 5;
            this.lblFigureRadio.Text = "Radio:";
            // 
            // lblFigureName
            // 
            this.lblFigureName.AutoSize = true;
            this.lblFigureName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFigureName.Location = new System.Drawing.Point(97, 5);
            this.lblFigureName.Name = "lblFigureName";
            this.lblFigureName.Size = new System.Drawing.Size(148, 29);
            this.lblFigureName.TabIndex = 3;
            this.lblFigureName.Text = "FigureName";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::UI.Properties.Resources._6703098_3d_shape_3d_sphere_geometric_geometry_round_icon1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 79);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // FigureCustomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteFigure);
            this.Controls.Add(this.lblFigureRadio);
            this.Controls.Add(this.lblFigureName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FigureCustomControl";
            this.Size = new System.Drawing.Size(349, 88);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteFigure;
        private System.Windows.Forms.Label lblFigureRadio;
        private System.Windows.Forms.Label lblFigureName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
