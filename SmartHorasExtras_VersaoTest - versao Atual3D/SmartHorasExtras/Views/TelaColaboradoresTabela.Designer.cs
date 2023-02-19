namespace SmartHorasExtras.Views
{
    partial class TelaColaboradoresTabela
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
            this.Paneltabela = new System.Windows.Forms.Panel();
            this.listViewColaboradores = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TipoColab = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TipoColaborador = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Senha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Paneltabela.SuspendLayout();
            this.SuspendLayout();
            // 
            // Paneltabela
            // 
            this.Paneltabela.Controls.Add(this.listViewColaboradores);
            this.Paneltabela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Paneltabela.Location = new System.Drawing.Point(0, 0);
            this.Paneltabela.Name = "Paneltabela";
            this.Paneltabela.Size = new System.Drawing.Size(780, 679);
            this.Paneltabela.TabIndex = 0;
            // 
            // listViewColaboradores
            // 
            this.listViewColaboradores.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewColaboradores.BackColor = System.Drawing.SystemColors.Control;
            this.listViewColaboradores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Nome,
            this.TipoColab,
            this.TipoColaborador,
            this.Senha});
            this.listViewColaboradores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewColaboradores.FullRowSelect = true;
            this.listViewColaboradores.HideSelection = false;
            this.listViewColaboradores.HotTracking = true;
            this.listViewColaboradores.HoverSelection = true;
            this.listViewColaboradores.Location = new System.Drawing.Point(0, 0);
            this.listViewColaboradores.Name = "listViewColaboradores";
            this.listViewColaboradores.Size = new System.Drawing.Size(780, 679);
            this.listViewColaboradores.TabIndex = 0;
            this.listViewColaboradores.UseCompatibleStateImageBehavior = false;
            this.listViewColaboradores.View = System.Windows.Forms.View.Details;
            this.listViewColaboradores.SelectedIndexChanged += new System.EventHandler(this.listViewColaboradores_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // Nome
            // 
            this.Nome.Text = "Nome";
            this.Nome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Nome.Width = 100;
            // 
            // TipoColab
            // 
            this.TipoColab.Text = "Departamento";
            this.TipoColab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TipoColab.Width = 100;
            // 
            // TipoColaborador
            // 
            this.TipoColaborador.Text = "Colaborador";
            this.TipoColaborador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TipoColaborador.Width = 100;
            // 
            // Senha
            // 
            this.Senha.Text = "Senha";
            this.Senha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TelaColaboradoresTabela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 679);
            this.Controls.Add(this.Paneltabela);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaColaboradoresTabela";
            this.Text = "TelaColaboradoresTabela";
            this.Paneltabela.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Paneltabela;
        private System.Windows.Forms.ListView listViewColaboradores;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Nome;
        private System.Windows.Forms.ColumnHeader TipoColab;
        private System.Windows.Forms.ColumnHeader TipoColaborador;
        private System.Windows.Forms.ColumnHeader Senha;
    }
}