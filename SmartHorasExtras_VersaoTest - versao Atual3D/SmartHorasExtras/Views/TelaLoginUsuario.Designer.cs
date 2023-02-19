namespace SmartHorasExtras.Views
{
    partial class TelaLoginUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelCadastro = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelSenha = new System.Windows.Forms.Label();
            this.comboBoxUsuario = new System.Windows.Forms.ComboBox();
            this.buttonLogar = new System.Windows.Forms.Button();
            this.textBoxSenha = new System.Windows.Forms.TextBox();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelCadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCadastro
            // 
            this.panelCadastro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCadastro.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelCadastro.Controls.Add(this.pictureBox1);
            this.panelCadastro.Controls.Add(this.labelLogin);
            this.panelCadastro.Controls.Add(this.labelSenha);
            this.panelCadastro.Controls.Add(this.comboBoxUsuario);
            this.panelCadastro.Controls.Add(this.buttonLogar);
            this.panelCadastro.Controls.Add(this.textBoxSenha);
            this.panelCadastro.Location = new System.Drawing.Point(107, 147);
            this.panelCadastro.Name = "panelCadastro";
            this.panelCadastro.Size = new System.Drawing.Size(562, 431);
            this.panelCadastro.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::SmartHorasExtras.Properties.Resources.usuario_64px_w;
            this.pictureBox1.Location = new System.Drawing.Point(224, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // labelLogin
            // 
            this.labelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogin.Location = new System.Drawing.Point(132, 170);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(320, 28);
            this.labelLogin.TabIndex = 12;
            this.labelLogin.Text = "Usuário:";
            // 
            // labelSenha
            // 
            this.labelSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSenha.Location = new System.Drawing.Point(130, 252);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(320, 23);
            this.labelSenha.TabIndex = 11;
            this.labelSenha.Text = "Senha:";
            // 
            // comboBoxUsuario
            // 
            this.comboBoxUsuario.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.comboBoxUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUsuario.ForeColor = System.Drawing.SystemColors.MenuText;
            this.comboBoxUsuario.FormattingEnabled = true;
            this.comboBoxUsuario.Location = new System.Drawing.Point(132, 201);
            this.comboBoxUsuario.MaxLength = 30;
            this.comboBoxUsuario.Name = "comboBoxUsuario";
            this.comboBoxUsuario.Size = new System.Drawing.Size(320, 32);
            this.comboBoxUsuario.Sorted = true;
            this.comboBoxUsuario.TabIndex = 10;
            this.comboBoxUsuario.TextUpdate += new System.EventHandler(this.comboBoxUsuario_TextUpdate);
            // 
            // buttonLogar
            // 
            this.buttonLogar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonLogar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonLogar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonLogar.Location = new System.Drawing.Point(192, 344);
            this.buttonLogar.Name = "buttonLogar";
            this.buttonLogar.Size = new System.Drawing.Size(200, 40);
            this.buttonLogar.TabIndex = 9;
            this.buttonLogar.Text = "Entrar";
            this.buttonLogar.UseVisualStyleBackColor = false;
            this.buttonLogar.Click += new System.EventHandler(this.buttonLogar_Click);
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSenha.Location = new System.Drawing.Point(132, 280);
            this.textBoxSenha.MaxLength = 30;
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.PasswordChar = '*';
            this.textBoxSenha.Size = new System.Drawing.Size(320, 29);
            this.textBoxSenha.TabIndex = 1;
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(780, 679);
            this.panelPrincipal.TabIndex = 1;
            // 
            // TelaLoginUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 679);
            this.Controls.Add(this.panelCadastro);
            this.Controls.Add(this.panelPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaLoginUsuario";
            this.Text = "TelaLoginUsuario";
            this.panelCadastro.ResumeLayout(false);
            this.panelCadastro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCadastro;
        private System.Windows.Forms.TextBox textBoxSenha;
        private System.Windows.Forms.ComboBox comboBoxUsuario;
        private System.Windows.Forms.Button buttonLogar;
        private System.Windows.Forms.Label labelSenha;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Panel panelPrincipal;
    }
}