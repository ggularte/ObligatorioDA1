namespace UI
{
    partial class AddNewMaterialView
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveMaterial = new System.Windows.Forms.Button();
            this.btnMaterialColorSelector = new System.Windows.Forms.Button();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.lblMaterialColor = new System.Windows.Forms.Label();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.lblNewMaterial = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.txtDifuminatedValue = new System.Windows.Forms.TextBox();
            this.lblDifuminatedValue = new System.Windows.Forms.Label();
            this.cbMetalic = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.txtDifuminatedValue);
            this.panel1.Controls.Add(this.lblDifuminatedValue);
            this.panel1.Controls.Add(this.cbMetalic);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSaveMaterial);
            this.panel1.Controls.Add(this.btnMaterialColorSelector);
            this.panel1.Controls.Add(this.txtMaterialName);
            this.panel1.Controls.Add(this.lblMaterialColor);
            this.panel1.Controls.Add(this.lblMaterialName);
            this.panel1.Controls.Add(this.lblNewMaterial);
            this.panel1.Location = new System.Drawing.Point(160, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 254);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(215, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveMaterial
            // 
            this.btnSaveMaterial.Location = new System.Drawing.Point(96, 210);
            this.btnSaveMaterial.Name = "btnSaveMaterial";
            this.btnSaveMaterial.Size = new System.Drawing.Size(99, 23);
            this.btnSaveMaterial.TabIndex = 5;
            this.btnSaveMaterial.Text = "Guardar";
            this.btnSaveMaterial.UseVisualStyleBackColor = true;
            this.btnSaveMaterial.Click += new System.EventHandler(this.btnSaveMaterial_Click);
            // 
            // btnMaterialColorSelector
            // 
            this.btnMaterialColorSelector.Location = new System.Drawing.Point(65, 141);
            this.btnMaterialColorSelector.Name = "btnMaterialColorSelector";
            this.btnMaterialColorSelector.Size = new System.Drawing.Size(149, 23);
            this.btnMaterialColorSelector.TabIndex = 4;
            this.btnMaterialColorSelector.Text = "Seleccionar color...";
            this.btnMaterialColorSelector.UseVisualStyleBackColor = true;
            this.btnMaterialColorSelector.Click += new System.EventHandler(this.btnMaterialColorSelector_Click);
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.Location = new System.Drawing.Point(65, 89);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Size = new System.Drawing.Size(291, 20);
            this.txtMaterialName.TabIndex = 2;
            // 
            // lblMaterialColor
            // 
            this.lblMaterialColor.AutoSize = true;
            this.lblMaterialColor.Location = new System.Drawing.Point(62, 125);
            this.lblMaterialColor.Name = "lblMaterialColor";
            this.lblMaterialColor.Size = new System.Drawing.Size(87, 13);
            this.lblMaterialColor.TabIndex = 3;
            this.lblMaterialColor.Text = "Color del material";
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.AutoSize = true;
            this.lblMaterialName.Location = new System.Drawing.Point(62, 73);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(44, 13);
            this.lblMaterialName.TabIndex = 1;
            this.lblMaterialName.Text = "Nombre";
            // 
            // lblNewMaterial
            // 
            this.lblNewMaterial.AutoSize = true;
            this.lblNewMaterial.Location = new System.Drawing.Point(169, 21);
            this.lblNewMaterial.Name = "lblNewMaterial";
            this.lblNewMaterial.Size = new System.Drawing.Size(79, 13);
            this.lblNewMaterial.TabIndex = 0;
            this.lblNewMaterial.Text = "Nuevo Material";
            // 
            // txtDifuminatedValue
            // 
            this.txtDifuminatedValue.Location = new System.Drawing.Point(227, 141);
            this.txtDifuminatedValue.Name = "txtDifuminatedValue";
            this.txtDifuminatedValue.Size = new System.Drawing.Size(129, 20);
            this.txtDifuminatedValue.TabIndex = 12;
            this.txtDifuminatedValue.Visible = false;
            // 
            // lblDifuminatedValue
            // 
            this.lblDifuminatedValue.AutoSize = true;
            this.lblDifuminatedValue.Location = new System.Drawing.Point(224, 125);
            this.lblDifuminatedValue.Name = "lblDifuminatedValue";
            this.lblDifuminatedValue.Size = new System.Drawing.Size(60, 13);
            this.lblDifuminatedValue.TabIndex = 11;
            this.lblDifuminatedValue.Text = "Difuminado";
            this.lblDifuminatedValue.Visible = false;
            // 
            // cbMetalic
            // 
            this.cbMetalic.AutoSize = true;
            this.cbMetalic.Location = new System.Drawing.Point(65, 174);
            this.cbMetalic.Name = "cbMetalic";
            this.cbMetalic.Size = new System.Drawing.Size(66, 17);
            this.cbMetalic.TabIndex = 10;
            this.cbMetalic.Text = "Metalico";
            this.cbMetalic.UseVisualStyleBackColor = true;
            this.cbMetalic.CheckedChanged += new System.EventHandler(this.cbMetalic_CheckedChanged);
            // 
            // AddNewMaterialView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AddNewMaterialView";
            this.Size = new System.Drawing.Size(750, 435);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveMaterial;
        private System.Windows.Forms.Button btnMaterialColorSelector;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.Label lblMaterialColor;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.Label lblNewMaterial;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox txtDifuminatedValue;
        private System.Windows.Forms.Label lblDifuminatedValue;
        private System.Windows.Forms.CheckBox cbMetalic;
    }
}
