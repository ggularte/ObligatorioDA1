namespace UI
{
    partial class ListOfScenesView
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
            this.pnlListOfScnenes = new System.Windows.Forms.Panel();
            this.btnAddNewScene = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlListOfScnenes
            // 
            this.pnlListOfScnenes.AutoScroll = true;
            this.pnlListOfScnenes.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlListOfScnenes.Location = new System.Drawing.Point(129, 70);
            this.pnlListOfScnenes.Name = "pnlListOfScnenes";
            this.pnlListOfScnenes.Size = new System.Drawing.Size(493, 337);
            this.pnlListOfScnenes.TabIndex = 3;
            // 
            // btnAddNewScene
            // 
            this.btnAddNewScene.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewScene.Location = new System.Drawing.Point(290, 27);
            this.btnAddNewScene.Name = "btnAddNewScene";
            this.btnAddNewScene.Size = new System.Drawing.Size(165, 37);
            this.btnAddNewScene.TabIndex = 2;
            this.btnAddNewScene.Text = "Nueva escena en blanco";
            this.btnAddNewScene.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewScene.UseVisualStyleBackColor = true;
            this.btnAddNewScene.Click += new System.EventHandler(this.btnAddNewScene_Click);
            // 
            // ListOfScenesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlListOfScnenes);
            this.Controls.Add(this.btnAddNewScene);
            this.Name = "ListOfScenesView";
            this.Size = new System.Drawing.Size(750, 435);
            this.Load += new System.EventHandler(this.ListOfScenesView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlListOfScnenes;
        private System.Windows.Forms.Button btnAddNewScene;
    }
}
