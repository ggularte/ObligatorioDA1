namespace UI
{
    partial class SignupView
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
            this.components = new System.ComponentModel.Container();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSignup = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.errorProviderUsername = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderConfirmPassword = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderConfirmPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(58, 131);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(207, 20);
            this.txtConfirmPassword.TabIndex = 13;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);
            this.txtConfirmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmPassword_KeyPress);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(55, 115);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(107, 13);
            this.lblConfirmPassword.TabIndex = 12;
            this.lblConfirmPassword.Text = "Confirmar contraseña";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(171, 160);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(94, 23);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Volver";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSignup
            // 
            this.btnSignup.Enabled = false;
            this.btnSignup.Location = new System.Drawing.Point(58, 160);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(94, 23);
            this.btnSignup.TabIndex = 14;
            this.btnSignup.Text = "Registrarse";
            this.btnSignup.UseVisualStyleBackColor = true;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(58, 92);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(207, 20);
            this.txtPassword.TabIndex = 10;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(58, 53);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(207, 20);
            this.txtUsername.TabIndex = 9;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(55, 76);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "Contraseña";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(55, 37);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(43, 13);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "Usuario";
            // 
            // errorProviderUsername
            // 
            this.errorProviderUsername.ContainerControl = this;
            // 
            // errorProviderPassword
            // 
            this.errorProviderPassword.ContainerControl = this;
            // 
            // errorProviderConfirmPassword
            // 
            this.errorProviderConfirmPassword.ContainerControl = this;
            // 
            // SignupView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Name = "SignupView";
            this.Size = new System.Drawing.Size(320, 220);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderConfirmPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.ErrorProvider errorProviderUsername;
        private System.Windows.Forms.ErrorProvider errorProviderPassword;
        private System.Windows.Forms.ErrorProvider errorProviderConfirmPassword;
    }
}
