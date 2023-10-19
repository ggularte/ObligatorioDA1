namespace UI
{
    partial class AddNewFigureView
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
            this.txtFigureRadio = new System.Windows.Forms.TextBox();
            this.txtFigureName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveFigure = new System.Windows.Forms.Button();
            this.lblFigureRadio = new System.Windows.Forms.Label();
            this.lblFigureName = new System.Windows.Forms.Label();
            this.lblNewFigure = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtFigureRadio);
            this.panel1.Controls.Add(this.txtFigureName);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSaveFigure);
            this.panel1.Controls.Add(this.lblFigureRadio);
            this.panel1.Controls.Add(this.lblFigureName);
            this.panel1.Controls.Add(this.lblNewFigure);
            this.panel1.Location = new System.Drawing.Point(168, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 212);
            this.panel1.TabIndex = 2;
            // 
            // txtFigureRadio
            // 
            this.txtFigureRadio.Location = new System.Drawing.Point(39, 126);
            this.txtFigureRadio.Name = "txtFigureRadio";
            this.txtFigureRadio.Size = new System.Drawing.Size(92, 20);
            this.txtFigureRadio.TabIndex = 4;
            this.txtFigureRadio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFigureRadio_KeyPress);
            // 
            // txtFigureName
            // 
            this.txtFigureName.Location = new System.Drawing.Point(39, 71);
            this.txtFigureName.Name = "txtFigureName";
            this.txtFigureName.Size = new System.Drawing.Size(338, 20);
            this.txtFigureName.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(221, 171);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveFigure
            // 
            this.btnSaveFigure.Location = new System.Drawing.Point(102, 171);
            this.btnSaveFigure.Name = "btnSaveFigure";
            this.btnSaveFigure.Size = new System.Drawing.Size(99, 23);
            this.btnSaveFigure.TabIndex = 5;
            this.btnSaveFigure.Text = "Guardar";
            this.btnSaveFigure.UseVisualStyleBackColor = true;
            this.btnSaveFigure.Click += new System.EventHandler(this.btnSaveFigure_Click);
            // 
            // lblFigureRadio
            // 
            this.lblFigureRadio.AutoSize = true;
            this.lblFigureRadio.Location = new System.Drawing.Point(36, 110);
            this.lblFigureRadio.Name = "lblFigureRadio";
            this.lblFigureRadio.Size = new System.Drawing.Size(35, 13);
            this.lblFigureRadio.TabIndex = 3;
            this.lblFigureRadio.Text = "Radio";
            // 
            // lblFigureName
            // 
            this.lblFigureName.AutoSize = true;
            this.lblFigureName.Location = new System.Drawing.Point(36, 55);
            this.lblFigureName.Name = "lblFigureName";
            this.lblFigureName.Size = new System.Drawing.Size(44, 13);
            this.lblFigureName.TabIndex = 1;
            this.lblFigureName.Text = "Nombre";
            // 
            // lblNewFigure
            // 
            this.lblNewFigure.AutoSize = true;
            this.lblNewFigure.Location = new System.Drawing.Point(176, 13);
            this.lblNewFigure.Name = "lblNewFigure";
            this.lblNewFigure.Size = new System.Drawing.Size(71, 13);
            this.lblNewFigure.TabIndex = 0;
            this.lblNewFigure.Text = "Nueva Figura";
            // 
            // AddNewFigureView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AddNewFigureView";
            this.Size = new System.Drawing.Size(750, 435);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFigureRadio;
        private System.Windows.Forms.TextBox txtFigureName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveFigure;
        private System.Windows.Forms.Label lblFigureRadio;
        private System.Windows.Forms.Label lblFigureName;
        private System.Windows.Forms.Label lblNewFigure;
    }
}
