namespace SmartHorasExtras
{
    partial class TelaPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnTable = new System.Windows.Forms.Button();
            this.pictureBox2LogoGestal = new System.Windows.Forms.PictureBox();
            this.btnSobre = new System.Windows.Forms.Button();
            this.btnRestaurar2 = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnConfiguracoes = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.BtnHorasExtras = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnColaboradores = new System.Windows.Forms.Button();
            this.pictureBoxLogoGEstal = new System.Windows.Forms.PictureBox();
            this.MenuHamburguer = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2LogoGestal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogoGEstal)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDesktop
            // 
            this.panelDesktop.AutoSize = true;
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.panelDesktop.Location = new System.Drawing.Point(230, 60);
            this.panelDesktop.MinimumSize = new System.Drawing.Size(778, 679);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(834, 708);
            this.panelDesktop.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxLogoGEstal);
            this.panel1.Controls.Add(this.MenuHamburguer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 60);
            this.panel1.TabIndex = 6;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelTitle.Controls.Add(this.btnList);
            this.panelTitle.Controls.Add(this.btnTable);
            this.panelTitle.Controls.Add(this.pictureBox2LogoGestal);
            this.panelTitle.Controls.Add(this.btnSobre);
            this.panelTitle.Controls.Add(this.panel2);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.ImeMode = System.Windows.Forms.ImeMode.On;
            this.panelTitle.Location = new System.Drawing.Point(230, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(834, 60);
            this.panelTitle.TabIndex = 7;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRestaurar2);
            this.panel2.Controls.Add(this.btnMinimizar);
            this.panel2.Controls.Add(this.btnSair);
            this.panel2.Controls.Add(this.btnRestaurar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(591, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 60);
            this.panel2.TabIndex = 0;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.FlatAppearance.BorderSize = 0;
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRestaurar.Location = new System.Drawing.Point(160, 53);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(75, 55);
            this.btnRestaurar.TabIndex = 1;
            this.btnRestaurar.Text = "[    ]";
            this.btnRestaurar.UseVisualStyleBackColor = true;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelMenu.Controls.Add(this.btnConfiguracoes);
            this.panelMenu.Controls.Add(this.btnLogin);
            this.panelMenu.Controls.Add(this.BtnHorasExtras);
            this.panelMenu.Controls.Add(this.btnUsuarios);
            this.panelMenu.Controls.Add(this.btnColaboradores);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.panelMenu.Size = new System.Drawing.Size(230, 768);
            this.panelMenu.TabIndex = 6;
            // 
            // btnTable
            // 
            this.btnTable.BackColor = System.Drawing.SystemColors.Control;
            this.btnTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTable.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTable.Location = new System.Drawing.Point(346, 29);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(93, 33);
            this.btnTable.TabIndex = 17;
            this.btnTable.Text = "Tabela";
            this.btnTable.UseVisualStyleBackColor = false;
            this.btnTable.Visible = false;
            this.btnTable.Click += new System.EventHandler(this.btnTableList_Click);
            // 
            // pictureBox2LogoGestal
            // 
            this.pictureBox2LogoGestal.Image = global::SmartHorasExtras.Properties.Resources.horas_extras;
            this.pictureBox2LogoGestal.Location = new System.Drawing.Point(19, 13);
            this.pictureBox2LogoGestal.Name = "pictureBox2LogoGestal";
            this.pictureBox2LogoGestal.Size = new System.Drawing.Size(150, 40);
            this.pictureBox2LogoGestal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2LogoGestal.TabIndex = 7;
            this.pictureBox2LogoGestal.TabStop = false;
            // 
            // btnSobre
            // 
            this.btnSobre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSobre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSobre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSobre.FlatAppearance.BorderSize = 0;
            this.btnSobre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSobre.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSobre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnSobre.Image = global::SmartHorasExtras.Properties.Resources.info_32px_w;
            this.btnSobre.Location = new System.Drawing.Point(479, 3);
            this.btnSobre.Name = "btnSobre";
            this.btnSobre.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSobre.Size = new System.Drawing.Size(106, 57);
            this.btnSobre.TabIndex = 16;
            this.btnSobre.Tag = "";
            this.btnSobre.UseVisualStyleBackColor = false;
            this.btnSobre.Click += new System.EventHandler(this.btnSobre_Click);
            // 
            // btnRestaurar2
            // 
            this.btnRestaurar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRestaurar2.FlatAppearance.BorderSize = 0;
            this.btnRestaurar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRestaurar2.Image = global::SmartHorasExtras.Properties.Resources.restaurar_32px_w;
            this.btnRestaurar2.Location = new System.Drawing.Point(75, 0);
            this.btnRestaurar2.Name = "btnRestaurar2";
            this.btnRestaurar2.Size = new System.Drawing.Size(90, 60);
            this.btnRestaurar2.TabIndex = 3;
            this.btnRestaurar2.UseVisualStyleBackColor = true;
            this.btnRestaurar2.Click += new System.EventHandler(this.btnRestaurar2_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMinimizar.Image = global::SmartHorasExtras.Properties.Resources.minimizar_32px_w;
            this.btnMinimizar.Location = new System.Drawing.Point(0, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(75, 60);
            this.btnMinimizar.TabIndex = 2;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSair.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnSair.Image = global::SmartHorasExtras.Properties.Resources.fechar_32px_w;
            this.btnSair.Location = new System.Drawing.Point(165, 0);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(78, 60);
            this.btnSair.TabIndex = 0;
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseEnter += new System.EventHandler(this.btnSair_MouseEnter);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            // 
            // btnConfiguracoes
            // 
            this.btnConfiguracoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConfiguracoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConfiguracoes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConfiguracoes.FlatAppearance.BorderSize = 0;
            this.btnConfiguracoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracoes.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnConfiguracoes.Image = global::SmartHorasExtras.Properties.Resources.configuracao_32px_w;
            this.btnConfiguracoes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracoes.Location = new System.Drawing.Point(0, 234);
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnConfiguracoes.Size = new System.Drawing.Size(230, 58);
            this.btnConfiguracoes.TabIndex = 20;
            this.btnConfiguracoes.Tag = "Configurações";
            this.btnConfiguracoes.Text = "Configurações";
            this.btnConfiguracoes.UseCompatibleTextRendering = true;
            this.btnConfiguracoes.UseVisualStyleBackColor = true;
            this.btnConfiguracoes.Click += new System.EventHandler(this.btnConfiguracoes_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnLogin.Image = global::SmartHorasExtras.Properties.Resources.chave_32px_w;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(0, 176);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnLogin.Size = new System.Drawing.Size(230, 58);
            this.btnLogin.TabIndex = 15;
            this.btnLogin.Tag = "Login";
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // BtnHorasExtras
            // 
            this.BtnHorasExtras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnHorasExtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnHorasExtras.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnHorasExtras.FlatAppearance.BorderSize = 0;
            this.BtnHorasExtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnHorasExtras.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHorasExtras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.BtnHorasExtras.Image = global::SmartHorasExtras.Properties.Resources.hora_extra_32px_w;
            this.BtnHorasExtras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHorasExtras.Location = new System.Drawing.Point(0, 118);
            this.BtnHorasExtras.Name = "BtnHorasExtras";
            this.BtnHorasExtras.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.BtnHorasExtras.Size = new System.Drawing.Size(230, 58);
            this.BtnHorasExtras.TabIndex = 18;
            this.BtnHorasExtras.Tag = "Horas Extras";
            this.BtnHorasExtras.Text = "Horas Extras";
            this.BtnHorasExtras.UseVisualStyleBackColor = false;
            this.BtnHorasExtras.Visible = false;
            this.BtnHorasExtras.Click += new System.EventHandler(this.btnColaborador_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnUsuarios.Image = global::SmartHorasExtras.Properties.Resources.usuario_32px_w;
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 695);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnUsuarios.Size = new System.Drawing.Size(230, 58);
            this.btnUsuarios.TabIndex = 17;
            this.btnUsuarios.Tag = "Usuario";
            this.btnUsuarios.Text = "Usuario";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Visible = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnColaboradores
            // 
            this.btnColaboradores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnColaboradores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnColaboradores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnColaboradores.FlatAppearance.BorderSize = 0;
            this.btnColaboradores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColaboradores.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColaboradores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnColaboradores.Image = global::SmartHorasExtras.Properties.Resources.usuarios_32px_w;
            this.btnColaboradores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnColaboradores.Location = new System.Drawing.Point(0, 60);
            this.btnColaboradores.Name = "btnColaboradores";
            this.btnColaboradores.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnColaboradores.Size = new System.Drawing.Size(230, 58);
            this.btnColaboradores.TabIndex = 14;
            this.btnColaboradores.Tag = "Colaboradores";
            this.btnColaboradores.Text = "Colaboradores";
            this.btnColaboradores.UseVisualStyleBackColor = false;
            this.btnColaboradores.Visible = false;
            this.btnColaboradores.Click += new System.EventHandler(this.btnColaboradores_Click);
            // 
            // pictureBoxLogoGEstal
            // 
            this.pictureBoxLogoGEstal.Image = global::SmartHorasExtras.Properties.Resources.horas_extras;
            this.pictureBoxLogoGEstal.Location = new System.Drawing.Point(12, 13);
            this.pictureBoxLogoGEstal.Name = "pictureBoxLogoGEstal";
            this.pictureBoxLogoGEstal.Size = new System.Drawing.Size(150, 40);
            this.pictureBoxLogoGEstal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogoGEstal.TabIndex = 6;
            this.pictureBoxLogoGEstal.TabStop = false;
            // 
            // MenuHamburguer
            // 
            this.MenuHamburguer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuHamburguer.FlatAppearance.BorderSize = 0;
            this.MenuHamburguer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuHamburguer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MenuHamburguer.Image = global::SmartHorasExtras.Properties.Resources.hamburger_32px_w;
            this.MenuHamburguer.Location = new System.Drawing.Point(170, 12);
            this.MenuHamburguer.Name = "MenuHamburguer";
            this.MenuHamburguer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.MenuHamburguer.Size = new System.Drawing.Size(48, 45);
            this.MenuHamburguer.TabIndex = 5;
            this.MenuHamburguer.UseVisualStyleBackColor = true;
            this.MenuHamburguer.Click += new System.EventHandler(this.MenuHamburguer_Click);
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.SystemColors.Control;
            this.btnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnList.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(247, 29);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(93, 33);
            this.btnList.TabIndex = 18;
            this.btnList.Text = "Lista";
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Visible = false;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 768);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1058, 807);
            this.Name = "TelaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PainelPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2LogoGestal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogoGEstal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Button btnSobre;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxLogoGEstal;
        private System.Windows.Forms.Button MenuHamburguer;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.PictureBox pictureBox2LogoGestal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRestaurar2;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnColaboradores;
        private System.Windows.Forms.Button BtnHorasExtras;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnConfiguracoes;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Button btnList;
    }
}

