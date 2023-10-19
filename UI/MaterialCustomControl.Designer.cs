namespace UI
{
    partial class MaterialCustomControl
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
            this.btnDeleteMaterial = new System.Windows.Forms.Button();
            this.lblMaterialColor = new System.Windows.Forms.Label();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.btnColorMaterial = new System.Windows.Forms.Button();
            this.lblMaterialType = new System.Windows.Forms.Label();
            this.lblDifuminatedValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDeleteMaterial
            // 
            this.btnDeleteMaterial.BackColor = System.Drawing.Color.RosyBrown;
            this.btnDeleteMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteMaterial.Location = new System.Drawing.Point(288, 35);
            this.btnDeleteMaterial.Name = "btnDeleteMaterial";
            this.btnDeleteMaterial.Size = new System.Drawing.Size(58, 46);
            this.btnDeleteMaterial.TabIndex = 7;
            this.btnDeleteMaterial.Text = "X";
            this.btnDeleteMaterial.UseVisualStyleBackColor = false;
            this.btnDeleteMaterial.Click += new System.EventHandler(this.btnDeleteMaterial_Click);
            // 
            // lblMaterialColor
            // 
            this.lblMaterialColor.AutoSize = true;
            this.lblMaterialColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialColor.Location = new System.Drawing.Point(109, 65);
            this.lblMaterialColor.Name = "lblMaterialColor";
            this.lblMaterialColor.Size = new System.Drawing.Size(51, 16);
            this.lblMaterialColor.TabIndex = 6;
            this.lblMaterialColor.Text = "R: G: B:";
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.AutoSize = true;
            this.lblMaterialName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialName.Location = new System.Drawing.Point(105, 3);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(164, 29);
            this.lblMaterialName.TabIndex = 5;
            this.lblMaterialName.Text = "MaterialName";
            // 
            // btnColorMaterial
            // 
            this.btnColorMaterial.Location = new System.Drawing.Point(3, 3);
            this.btnColorMaterial.Name = "btnColorMaterial";
            this.btnColorMaterial.Size = new System.Drawing.Size(96, 82);
            this.btnColorMaterial.TabIndex = 4;
            this.btnColorMaterial.UseVisualStyleBackColor = true;
            // 
            // lblMaterialType
            // 
            this.lblMaterialType.AutoSize = true;
            this.lblMaterialType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialType.Location = new System.Drawing.Point(107, 29);
            this.lblMaterialType.Name = "lblMaterialType";
            this.lblMaterialType.Size = new System.Drawing.Size(68, 13);
            this.lblMaterialType.TabIndex = 10;
            this.lblMaterialType.Text = "TypeMaterial";
            // 
            // lblDifuminatedValue
            // 
            this.lblDifuminatedValue.AutoSize = true;
            this.lblDifuminatedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifuminatedValue.Location = new System.Drawing.Point(109, 49);
            this.lblDifuminatedValue.Name = "lblDifuminatedValue";
            this.lblDifuminatedValue.Size = new System.Drawing.Size(116, 16);
            this.lblDifuminatedValue.TabIndex = 11;
            this.lblDifuminatedValue.Text = "DifuminatedValue:";
            this.lblDifuminatedValue.Visible = false;
            // 
            // MaterialCustomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDifuminatedValue);
            this.Controls.Add(this.lblMaterialType);
            this.Controls.Add(this.btnDeleteMaterial);
            this.Controls.Add(this.lblMaterialColor);
            this.Controls.Add(this.lblMaterialName);
            this.Controls.Add(this.btnColorMaterial);
            this.Name = "MaterialCustomControl";
            this.Size = new System.Drawing.Size(349, 88);
            this.Load += new System.EventHandler(this.MaterialCustomControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteMaterial;
        private System.Windows.Forms.Label lblMaterialColor;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.Button btnColorMaterial;
        private System.Windows.Forms.Label lblMaterialType;
        private System.Windows.Forms.Label lblDifuminatedValue;
    }
}
