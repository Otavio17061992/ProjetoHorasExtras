namespace SmartHorasExtras.Views
{
    partial class TelaConfiguracoes
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
            this.labelBancoDados = new System.Windows.Forms.Label();
            this.textBoxCaminho = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCaminho = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelBancoDados
            // 
            this.labelBancoDados.AutoSize = true;
            this.labelBancoDados.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBancoDados.Location = new System.Drawing.Point(14, 29);
            this.labelBancoDados.Name = "labelBancoDados";
            this.labelBancoDados.Size = new System.Drawing.Size(170, 25);
            this.labelBancoDados.TabIndex = 0;
            this.labelBancoDados.Text = "Banco de Dados:";
            // 
            // textBoxCaminho
            // 
            this.textBoxCaminho.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCaminho.Location = new System.Drawing.Point(18, 60);
            this.textBoxCaminho.Name = "textBoxCaminho";
            this.textBoxCaminho.Size = new System.Drawing.Size(488, 30);
            this.textBoxCaminho.TabIndex = 1;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::SmartHorasExtras.Properties.Resources.salvar_32px_g;
            this.btnSalvar.Location = new System.Drawing.Point(631, 38);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(55, 55);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCaminho
            // 
            this.btnCaminho.Image = global::SmartHorasExtras.Properties.Resources.diretorio_32px_g;
            this.btnCaminho.Location = new System.Drawing.Point(561, 38);
            this.btnCaminho.Name = "btnCaminho";
            this.btnCaminho.Size = new System.Drawing.Size(55, 55);
            this.btnCaminho.TabIndex = 2;
            this.btnCaminho.UseVisualStyleBackColor = true;
            this.btnCaminho.Click += new System.EventHandler(this.btnCaminho_Click);
            // 
            // TelaConfiguracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 708);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCaminho);
            this.Controls.Add(this.textBoxCaminho);
            this.Controls.Add(this.labelBancoDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaConfiguracoes";
            this.Text = "TelaConfiguracoes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBancoDados;
        private System.Windows.Forms.TextBox textBoxCaminho;
        private System.Windows.Forms.Button btnCaminho;
        private System.Windows.Forms.Button btnSalvar;

    }
}