namespace UI
{
    partial class ListOfFiguresView
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
            this.pnlListOfFigures = new System.Windows.Forms.Panel();
            this.btnAddNewFigure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlListOfFigures
            // 
            this.pnlListOfFigures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlListOfFigures.AutoScroll = true;
            this.pnlListOfFigures.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlListOfFigures.Location = new System.Drawing.Point(165, 70);
            this.pnlListOfFigures.Name = "pnlListOfFigures";
            this.pnlListOfFigures.Size = new System.Drawing.Size(421, 337);
            this.pnlListOfFigures.TabIndex = 3;
            // 
            // btnAddNewFigure
            // 
            this.btnAddNewFigure.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewFigure.Location = new System.Drawing.Point(299, 27);
            this.btnAddNewFigure.Name = "btnAddNewFigure";
            this.btnAddNewFigure.Size = new System.Drawing.Size(165, 37);
            this.btnAddNewFigure.TabIndex = 2;
            this.btnAddNewFigure.Text = "Agregar nueva figura";
            this.btnAddNewFigure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewFigure.UseVisualStyleBackColor = true;
            this.btnAddNewFigure.Click += new System.EventHandler(this.btnAddNewFigure_Click);
            // 
            // ListOfFiguresView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlListOfFigures);
            this.Controls.Add(this.btnAddNewFigure);
            this.Name = "ListOfFiguresView";
            this.Size = new System.Drawing.Size(750, 435);
            this.Load += new System.EventHandler(this.ListOfFiguresView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlListOfFigures;
        private System.Windows.Forms.Button btnAddNewFigure;
    }
}
