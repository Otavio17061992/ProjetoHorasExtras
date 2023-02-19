namespace SmartHorasExtras.Controllers.FormMessageBox
{
    partial class FormColaboradorAdd
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
            this.panelTextColaborador = new System.Windows.Forms.Panel();
            this.labelMensageColab = new System.Windows.Forms.Label();
            this.panelLabelTextColab = new System.Windows.Forms.Panel();
            this.comboBoxTipoUser = new System.Windows.Forms.ComboBox();
            this.labelTipoUser = new System.Windows.Forms.Label();
            this.textBoxDepartamento = new System.Windows.Forms.TextBox();
            this.labelLabelDepartamento = new System.Windows.Forms.Label();
            this.textBoxNomeColabador = new System.Windows.Forms.TextBox();
            this.LabelNomeColaborador = new System.Windows.Forms.Label();
            this.panelButtonColab = new System.Windows.Forms.Panel();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.panelTextColaborador.SuspendLayout();
            this.panelLabelTextColab.SuspendLayout();
            this.panelButtonColab.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTextColaborador
            // 
            this.panelTextColaborador.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelTextColaborador.Controls.Add(this.labelMensageColab);
            this.panelTextColaborador.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTextColaborador.Location = new System.Drawing.Point(0, 0);
            this.panelTextColaborador.Name = "panelTextColaborador";
            this.panelTextColaborador.Size = new System.Drawing.Size(484, 52);
            this.panelTextColaborador.TabIndex = 3;
            // 
            // labelMensageColab
            // 
            this.labelMensageColab.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMensageColab.Location = new System.Drawing.Point(1, 10);
            this.labelMensageColab.Name = "labelMensageColab";
            this.labelMensageColab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelMensageColab.Size = new System.Drawing.Size(481, 42);
            this.labelMensageColab.TabIndex = 0;
            this.labelMensageColab.Text = "Entre com as informações do colaborador: ";
            this.labelMensageColab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLabelTextColab
            // 
            this.panelLabelTextColab.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelLabelTextColab.Controls.Add(this.comboBoxTipoUser);
            this.panelLabelTextColab.Controls.Add(this.labelTipoUser);
            this.panelLabelTextColab.Controls.Add(this.textBoxDepartamento);
            this.panelLabelTextColab.Controls.Add(this.labelLabelDepartamento);
            this.panelLabelTextColab.Controls.Add(this.textBoxNomeColabador);
            this.panelLabelTextColab.Controls.Add(this.LabelNomeColaborador);
            this.panelLabelTextColab.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLabelTextColab.Location = new System.Drawing.Point(0, 46);
            this.panelLabelTextColab.Name = "panelLabelTextColab";
            this.panelLabelTextColab.Size = new System.Drawing.Size(484, 205);
            this.panelLabelTextColab.TabIndex = 4;
            // 
            // comboBoxTipoUser
            // 
            this.comboBoxTipoUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipoUser.FormattingEnabled = true;
            this.comboBoxTipoUser.Items.AddRange(new object[] {
            "Colaborador",
            "Admin"});
            this.comboBoxTipoUser.Location = new System.Drawing.Point(33, 37);
            this.comboBoxTipoUser.Name = "comboBoxTipoUser";
            this.comboBoxTipoUser.Size = new System.Drawing.Size(405, 32);
            this.comboBoxTipoUser.TabIndex = 1;
            // 
            // labelTipoUser
            // 
            this.labelTipoUser.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipoUser.Location = new System.Drawing.Point(26, 14);
            this.labelTipoUser.Name = "labelTipoUser";
            this.labelTipoUser.Size = new System.Drawing.Size(458, 19);
            this.labelTipoUser.TabIndex = 4;
            this.labelTipoUser.Text = "Tipo Usuário:";
            // 
            // textBoxDepartamento
            // 
            this.textBoxDepartamento.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBoxDepartamento.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDepartamento.Location = new System.Drawing.Point(32, 166);
            this.textBoxDepartamento.MaxLength = 30;
            this.textBoxDepartamento.Name = "textBoxDepartamento";
            this.textBoxDepartamento.Size = new System.Drawing.Size(406, 30);
            this.textBoxDepartamento.TabIndex = 3;
            // 
            // labelLabelDepartamento
            // 
            this.labelLabelDepartamento.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLabelDepartamento.Location = new System.Drawing.Point(26, 140);
            this.labelLabelDepartamento.Name = "labelLabelDepartamento";
            this.labelLabelDepartamento.Size = new System.Drawing.Size(458, 19);
            this.labelLabelDepartamento.TabIndex = 2;
            this.labelLabelDepartamento.Text = "Departamento:";
            // 
            // textBoxNomeColabador
            // 
            this.textBoxNomeColabador.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBoxNomeColabador.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNomeColabador.Location = new System.Drawing.Point(33, 102);
            this.textBoxNomeColabador.MaxLength = 30;
            this.textBoxNomeColabador.Name = "textBoxNomeColabador";
            this.textBoxNomeColabador.Size = new System.Drawing.Size(405, 30);
            this.textBoxNomeColabador.TabIndex = 2;
            // 
            // LabelNomeColaborador
            // 
            this.LabelNomeColaborador.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNomeColaborador.Location = new System.Drawing.Point(26, 76);
            this.LabelNomeColaborador.Name = "LabelNomeColaborador";
            this.LabelNomeColaborador.Size = new System.Drawing.Size(458, 19);
            this.LabelNomeColaborador.TabIndex = 0;
            this.LabelNomeColaborador.Text = "Nome:";
            // 
            // panelButtonColab
            // 
            this.panelButtonColab.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelButtonColab.Controls.Add(this.buttonCancelar);
            this.panelButtonColab.Controls.Add(this.buttonSalvar);
            this.panelButtonColab.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtonColab.Location = new System.Drawing.Point(0, 251);
            this.panelButtonColab.Name = "panelButtonColab";
            this.panelButtonColab.Size = new System.Drawing.Size(484, 94);
            this.panelButtonColab.TabIndex = 5;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.Crimson;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonCancelar.Location = new System.Drawing.Point(276, 41);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(180, 40);
            this.buttonCancelar.TabIndex = 9;
            this.buttonCancelar.Text = "button1";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            this.buttonCancelar.MouseEnter += new System.EventHandler(this.buttonCancelar_MouseEnter);
            this.buttonCancelar.MouseLeave += new System.EventHandler(this.buttonCancelar_MouseLeave);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalvar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSalvar.Location = new System.Drawing.Point(20, 41);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(180, 40);
            this.buttonSalvar.TabIndex = 8;
            this.buttonSalvar.Text = "button1";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // FormColaboradorAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 345);
            this.Controls.Add(this.panelTextColaborador);
            this.Controls.Add(this.panelLabelTextColab);
            this.Controls.Add(this.panelButtonColab);
            this.Name = "FormColaboradorAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormColaboradorAdd";
            this.panelTextColaborador.ResumeLayout(false);
            this.panelLabelTextColab.ResumeLayout(false);
            this.panelLabelTextColab.PerformLayout();
            this.panelButtonColab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTextColaborador;
        private System.Windows.Forms.Label labelMensageColab;
        private System.Windows.Forms.Panel panelLabelTextColab;
        private System.Windows.Forms.TextBox textBoxDepartamento;
        private System.Windows.Forms.Label labelLabelDepartamento;
        private System.Windows.Forms.TextBox textBoxNomeColabador;
        private System.Windows.Forms.Label LabelNomeColaborador;
        private System.Windows.Forms.Panel panelButtonColab;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.ComboBox comboBoxTipoUser;
        private System.Windows.Forms.Label labelTipoUser;
    }
}