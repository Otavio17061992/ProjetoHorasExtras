namespace SmartHorasExtras.Controllers.FormMessageBox
{
    partial class FormMessage
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
            this.panelbuttons = new System.Windows.Forms.Panel();
            this.buttonSim = new System.Windows.Forms.Button();
            this.buttonNão = new System.Windows.Forms.Button();
            this.labelMensagem = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.ImagemLogo = new System.Windows.Forms.PictureBox();
            this.panelbuttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagemLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelbuttons
            // 
            this.panelbuttons.Controls.Add(this.buttonSim);
            this.panelbuttons.Controls.Add(this.buttonNão);
            this.panelbuttons.Location = new System.Drawing.Point(-1, 223);
            this.panelbuttons.Name = "panelbuttons";
            this.panelbuttons.Size = new System.Drawing.Size(512, 68);
            this.panelbuttons.TabIndex = 9;
            // 
            // buttonSim
            // 
            this.buttonSim.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonSim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSim.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSim.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSim.Location = new System.Drawing.Point(63, 15);
            this.buttonSim.Name = "buttonSim";
            this.buttonSim.Size = new System.Drawing.Size(180, 40);
            this.buttonSim.TabIndex = 7;
            this.buttonSim.Text = "button1";
            this.buttonSim.UseVisualStyleBackColor = false;
            // 
            // buttonNão
            // 
            this.buttonNão.BackColor = System.Drawing.Color.Crimson;
            this.buttonNão.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNão.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNão.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonNão.Location = new System.Drawing.Point(280, 15);
            this.buttonNão.Name = "buttonNão";
            this.buttonNão.Size = new System.Drawing.Size(180, 40);
            this.buttonNão.TabIndex = 6;
            this.buttonNão.Text = "button3";
            this.buttonNão.UseVisualStyleBackColor = false;
            // 
            // labelMensagem
            // 
            this.labelMensagem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMensagem.ForeColor = System.Drawing.Color.Gray;
            this.labelMensagem.Location = new System.Drawing.Point(2, 160);
            this.labelMensagem.Name = "labelMensagem";
            this.labelMensagem.Size = new System.Drawing.Size(509, 62);
            this.labelMensagem.TabIndex = 8;
            this.labelMensagem.Text = "Deseja realmente Sair ?";
            this.labelMensagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(-1, 119);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(512, 25);
            this.labelTitulo.TabIndex = 7;
            this.labelTitulo.Text = "ATENÇÃO";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImagemLogo
            // 
            this.ImagemLogo.Image = global::SmartHorasExtras.Properties.Resources.atencao;
            this.ImagemLogo.Location = new System.Drawing.Point(211, 10);
            this.ImagemLogo.Name = "ImagemLogo";
            this.ImagemLogo.Size = new System.Drawing.Size(90, 90);
            this.ImagemLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagemLogo.TabIndex = 6;
            this.ImagemLogo.TabStop = false;
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(510, 300);
            this.Controls.Add(this.panelbuttons);
            this.Controls.Add(this.labelMensagem);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.ImagemLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMessage";
            this.panelbuttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagemLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelbuttons;
        private System.Windows.Forms.Button buttonSim;
        private System.Windows.Forms.Button buttonNão;
        private System.Windows.Forms.Label labelMensagem;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.PictureBox ImagemLogo;
    }
}