namespace UI
{
    partial class ListOfModelsView
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
            this.pnlListOfModels = new System.Windows.Forms.Panel();
            this.btnAddNewModel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlListOfModels
            // 
            this.pnlListOfModels.AutoScroll = true;
            this.pnlListOfModels.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlListOfModels.Location = new System.Drawing.Point(165, 70);
            this.pnlListOfModels.Name = "pnlListOfModels";
            this.pnlListOfModels.Size = new System.Drawing.Size(421, 337);
            this.pnlListOfModels.TabIndex = 3;
            // 
            // btnAddNewModel
            // 
            this.btnAddNewModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewModel.Location = new System.Drawing.Point(298, 27);
            this.btnAddNewModel.Name = "btnAddNewModel";
            this.btnAddNewModel.Size = new System.Drawing.Size(165, 37);
            this.btnAddNewModel.TabIndex = 2;
            this.btnAddNewModel.Text = "Agregar nuevo modelo";
            this.btnAddNewModel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewModel.UseVisualStyleBackColor = true;
            this.btnAddNewModel.Click += new System.EventHandler(this.btnAddNewModel_Click);
            // 
            // ListOfModelsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlListOfModels);
            this.Controls.Add(this.btnAddNewModel);
            this.Name = "ListOfModelsView";
            this.Size = new System.Drawing.Size(750, 435);
            this.Load += new System.EventHandler(this.ListOfModelsView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlListOfModels;
        private System.Windows.Forms.Button btnAddNewModel;
    }
}
