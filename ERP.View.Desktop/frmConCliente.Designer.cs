namespace ERP.View.Desktop
{
    partial class frmConCliente
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
            this.components = new System.ComponentModel.Container();
            this.dgvRegistros = new System.Windows.Forms.DataGridView();
            this.cmsMenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tsmEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExcluir = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).BeginInit();
            this.cmsMenuGrid.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRegistros
            // 
            this.dgvRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistros.ContextMenuStrip = this.cmsMenuGrid;
            this.dgvRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegistros.Location = new System.Drawing.Point(0, 127);
            this.dgvRegistros.Name = "dgvRegistros";
            this.dgvRegistros.Size = new System.Drawing.Size(1300, 583);
            this.dgvRegistros.TabIndex = 13;
            // 
            // cmsMenuGrid
            // 
            this.cmsMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEditar,
            this.tsmExcluir});
            this.cmsMenuGrid.Name = "cmsMenuGrid";
            this.cmsMenuGrid.Size = new System.Drawing.Size(110, 48);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpFiltros);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 127);
            this.panel1.TabIndex = 14;
            // 
            // grpFiltros
            // 
            this.grpFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFiltros.Controls.Add(this.lblNome);
            this.grpFiltros.Controls.Add(this.btnPesquisar);
            this.grpFiltros.Controls.Add(this.txtNome);
            this.grpFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltros.Location = new System.Drawing.Point(536, 8);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(752, 113);
            this.grpFiltros.TabIndex = 14;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(25, 20);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(41, 15);
            this.lblNome.TabIndex = 18;
            this.lblNome.Text = "Nome";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(605, 79);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(141, 28);
            this.btnPesquisar.TabIndex = 17;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(28, 38);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(718, 21);
            this.txtNome.TabIndex = 16;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(5, 28);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(182, 24);
            this.lblTitulo.TabIndex = 13;
            this.lblTitulo.Text = "Consulta de Clientes";
            // 
            // tsmEditar
            // 
            this.tsmEditar.Name = "tsmEditar";
            this.tsmEditar.Size = new System.Drawing.Size(180, 22);
            this.tsmEditar.Text = "Editar";
            this.tsmEditar.Click += new System.EventHandler(this.tsmEditar_Click);
            // 
            // tsmExcluir
            // 
            this.tsmExcluir.Name = "tsmExcluir";
            this.tsmExcluir.Size = new System.Drawing.Size(180, 22);
            this.tsmExcluir.Text = "Excluir";
            this.tsmExcluir.Click += new System.EventHandler(this.tsmExcluir_Click);
            // 
            // frmConCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 710);
            this.Controls.Add(this.dgvRegistros);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "frmConCliente";
            this.Text = "Consulta de Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();
            this.cmsMenuGrid.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRegistros;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ContextMenuStrip cmsMenuGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmEditar;
        private System.Windows.Forms.ToolStripMenuItem tsmExcluir;
    }
}