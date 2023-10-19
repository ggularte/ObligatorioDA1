namespace UI
{
    partial class ListOfMaterialsView
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
            this.pnlListOfMaterials = new System.Windows.Forms.Panel();
            this.btnAddNewMaterial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlListOfMaterials
            // 
            this.pnlListOfMaterials.AutoScroll = true;
            this.pnlListOfMaterials.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlListOfMaterials.Location = new System.Drawing.Point(165, 70);
            this.pnlListOfMaterials.Name = "pnlListOfMaterials";
            this.pnlListOfMaterials.Size = new System.Drawing.Size(421, 337);
            this.pnlListOfMaterials.TabIndex = 3;
            // 
            // btnAddNewMaterial
            // 
            this.btnAddNewMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewMaterial.Location = new System.Drawing.Point(295, 27);
            this.btnAddNewMaterial.Name = "btnAddNewMaterial";
            this.btnAddNewMaterial.Size = new System.Drawing.Size(165, 37);
            this.btnAddNewMaterial.TabIndex = 2;
            this.btnAddNewMaterial.Text = "Agregar nuevo material";
            this.btnAddNewMaterial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewMaterial.UseVisualStyleBackColor = true;
            this.btnAddNewMaterial.Click += new System.EventHandler(this.btnAddNewMaterial_Click);
            // 
            // ListOfMaterialsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlListOfMaterials);
            this.Controls.Add(this.btnAddNewMaterial);
            this.Name = "ListOfMaterialsView";
            this.Size = new System.Drawing.Size(750, 435);
            this.Load += new System.EventHandler(this.ListOfMaterialsView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlListOfMaterials;
        private System.Windows.Forms.Button btnAddNewMaterial;
    }
}
