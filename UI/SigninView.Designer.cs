namespace UI
{
    partial class SigninView
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
            this.btnSignup = new System.Windows.Forms.Button();
            this.btnSignin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSignup
            // 
            this.btnSignup.Location = new System.Drawing.Point(171, 151);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(94, 23);
            this.btnSignup.TabIndex = 11;
            this.btnSignup.Text = "Registrarse";
            this.btnSignup.UseVisualStyleBackColor = true;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // btnSignin
            // 
            this.btnSignin.Location = new System.Drawing.Point(58, 151);
            this.btnSignin.Name = "btnSignin";
            this.btnSignin.Size = new System.Drawing.Size(94, 23);
            this.btnSignin.TabIndex = 10;
            this.btnSignin.Text = "Entrar";
            this.btnSignin.UseVisualStyleBackColor = true;
            this.btnSignin.Click += new System.EventHandler(this.btnSignin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(58, 113);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(207, 20);
            this.txtPassword.TabIndex = 9;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(58, 63);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(207, 20);
            this.txtUsername.TabIndex = 7;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(55, 97);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Contraseña";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(55, 47);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(43, 13);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "Usuario";
            // 
            // SigninView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.btnSignin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Name = "SigninView";
            this.Size = new System.Drawing.Size(320, 220);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.Button btnSignin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
    }
}
