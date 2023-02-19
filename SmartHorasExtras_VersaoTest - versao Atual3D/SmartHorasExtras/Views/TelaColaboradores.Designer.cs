namespace SmartHorasExtras.Views
{
    partial class TelaColaboradores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaColaboradores));
            this.painelPrincipalColaboradores = new System.Windows.Forms.Panel();
            this.flowPainelColaboradores = new System.Windows.Forms.FlowLayoutPanel();
            this.AdicionarColaborador = new SmartHorasExtras.Controllers.ControlUcColaborador.ColaboradorUC();
            this.painelPrincipalColaboradores.SuspendLayout();
            this.flowPainelColaboradores.SuspendLayout();
            this.SuspendLayout();
            // 
            // painelPrincipalColaboradores
            // 
            this.painelPrincipalColaboradores.Controls.Add(this.flowPainelColaboradores);
            this.painelPrincipalColaboradores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painelPrincipalColaboradores.Location = new System.Drawing.Point(0, 0);
            this.painelPrincipalColaboradores.Name = "painelPrincipalColaboradores";
            this.painelPrincipalColaboradores.Size = new System.Drawing.Size(780, 679);
            this.painelPrincipalColaboradores.TabIndex = 2;
            // 
            // flowPainelColaboradores
            // 
            this.flowPainelColaboradores.AutoScroll = true;
            this.flowPainelColaboradores.Controls.Add(this.AdicionarColaborador);
            this.flowPainelColaboradores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPainelColaboradores.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.flowPainelColaboradores.Location = new System.Drawing.Point(0, 0);
            this.flowPainelColaboradores.Name = "flowPainelColaboradores";
            this.flowPainelColaboradores.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowPainelColaboradores.Size = new System.Drawing.Size(780, 679);
            this.flowPainelColaboradores.TabIndex = 1;
            // 
            // AdicionarColaborador
            // 
            this.AdicionarColaborador.FotoColaborador = ((System.Drawing.Image)(resources.GetObject("AdicionarColaborador.FotoColaborador")));
            this.AdicionarColaborador.Location = new System.Drawing.Point(3, 3);
            this.AdicionarColaborador.Name = "AdicionarColaborador";
            this.AdicionarColaborador.NomeColaborador = "Colaborador";
            this.AdicionarColaborador.Size = new System.Drawing.Size(200, 200);
            this.AdicionarColaborador.TabIndex = 1;
            this.AdicionarColaborador.Load += new System.EventHandler(this.AdicionarColaborador_Load);
            // 
            // TelaColaboradores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 679);
            this.Controls.Add(this.painelPrincipalColaboradores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaColaboradores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaColaboradores";
            this.painelPrincipalColaboradores.ResumeLayout(false);
            this.flowPainelColaboradores.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel painelPrincipalColaboradores;
        private System.Windows.Forms.FlowLayoutPanel flowPainelColaboradores;
        private Controllers.ControlUcColaborador.ColaboradorUC AdicionarColaborador;
    }
}