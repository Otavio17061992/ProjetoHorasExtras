namespace SmartHorasExtras.Controllers.ControlUcColaborador
{
    partial class ColaboradorUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelNomeColaborador = new System.Windows.Forms.Button();
            this.btnExcluiColaborador = new System.Windows.Forms.Button();
            this.btnFotoColaborador = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNomeColaborador
            // 
            this.labelNomeColaborador.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelNomeColaborador.FlatAppearance.BorderSize = 0;
            this.labelNomeColaborador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelNomeColaborador.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomeColaborador.Location = new System.Drawing.Point(39, 136);
            this.labelNomeColaborador.Name = "labelNomeColaborador";
            this.labelNomeColaborador.Size = new System.Drawing.Size(123, 39);
            this.labelNomeColaborador.TabIndex = 6;
            this.labelNomeColaborador.Text = "Colaborador";
            this.labelNomeColaborador.UseVisualStyleBackColor = false;
            // 
            // btnExcluiColaborador
            // 
            this.btnExcluiColaborador.BackColor = System.Drawing.Color.Crimson;
            this.btnExcluiColaborador.FlatAppearance.BorderSize = 0;
            this.btnExcluiColaborador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluiColaborador.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExcluiColaborador.Location = new System.Drawing.Point(137, 20);
            this.btnExcluiColaborador.Name = "btnExcluiColaborador";
            this.btnExcluiColaborador.Size = new System.Drawing.Size(29, 23);
            this.btnExcluiColaborador.TabIndex = 5;
            this.btnExcluiColaborador.Text = "X";
            this.btnExcluiColaborador.UseVisualStyleBackColor = false;
            // 
            // btnFotoColaborador
            // 
            this.btnFotoColaborador.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFotoColaborador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFotoColaborador.Image = global::SmartHorasExtras.Properties.Resources.usuario_64px_g;
            this.btnFotoColaborador.Location = new System.Drawing.Point(35, 20);
            this.btnFotoColaborador.Name = "btnFotoColaborador";
            this.btnFotoColaborador.Size = new System.Drawing.Size(131, 160);
            this.btnFotoColaborador.TabIndex = 4;
            this.btnFotoColaborador.Text = "\r\n";
            this.btnFotoColaborador.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFotoColaborador.UseVisualStyleBackColor = false;
            // 
            // ColaboradorUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelNomeColaborador);
            this.Controls.Add(this.btnExcluiColaborador);
            this.Controls.Add(this.btnFotoColaborador);
            this.Name = "ColaboradorUC";
            this.Size = new System.Drawing.Size(200, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button labelNomeColaborador;
        private System.Windows.Forms.Button btnExcluiColaborador;
        private System.Windows.Forms.Button btnFotoColaborador;
    }
}
