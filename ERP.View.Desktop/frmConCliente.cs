using ERP.Core.Negocio;
using ERP.Entidades.FiltrosDePesquisa;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.View.Desktop
{
    public partial class frmConCliente : Form
    {
        #region Propriedades
        public string NomeCliente {
            get { return txtNome.Text; }
            set { txtNome.Text = value; }
        }
        #endregion

        private NCliente nCliente = new NCliente();

        public frmConCliente()
        {
            InitializeComponent();

            #region Configurar DataGridView
            dgvRegistros.ReadOnly = true;
            dgvRegistros.AllowUserToOrderColumns = true;
            dgvRegistros.MultiSelect = false;
            dgvRegistros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            #endregion Configurar DataGridView

            btnPesquisar_Click(new object(), new EventArgs());
        }

        #region Eventos
        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            await CarregarGrid();
            AjustarNomesColunasDataGrid();
        }

        private async void tsmEditar_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.SelectedRows[0].Index != -1)
            {
                int codigo = Convert.ToInt32(dgvRegistros.SelectedRows[0].Cells[0].Value);

                frmCadCliente frm = new frmCadCliente(codigo);
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.Cancel)
                {
                    await CarregarGrid();
                    AjustarNomesColunasDataGrid();
                }
            }
        }

        private async void tsmExcluir_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.SelectedRows[0].Index != -1)
            {
                int codigo = Convert.ToInt32(dgvRegistros.SelectedRows[0].Cells[0].Value);

                var result = await nCliente.Excluir(codigo);

                if (result.Item1)
                {
                    MessageBox.Show($"Dados Excluídos com sucesso!",
                                "Sucesso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                    await CarregarGrid();
                    AjustarNomesColunasDataGrid();
                }
                else
                {
                    MessageBox.Show($"Ocorreu um erro ao tentar excluir o registro.\r\n{result.Item2}",
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                }
            }
        }
        #endregion Eventos

        #region Métodos
        private async Task CarregarGrid()
        {
            var registros = await nCliente.SelecionarTodos(new FiltroCliente(NomeCliente));

            dgvRegistros.DataSource = null;
            dgvRegistros.DataSource = registros;
        }

        private void AjustarNomesColunasDataGrid()
        {
            dgvRegistros.Columns[0].HeaderText = "Código";
            dgvRegistros.Columns[0].Name = "Codigo";
            dgvRegistros.Columns[0].Frozen = true;
            dgvRegistros.Columns[0].Width = 80;

            dgvRegistros.Columns[1].HeaderText = "Nome";
            dgvRegistros.Columns[1].Name = "Nome";
            dgvRegistros.Columns[1].Frozen = false;
            dgvRegistros.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvRegistros.Columns[2].HeaderText = "Data Nasc.";
            dgvRegistros.Columns[2].Name = "DataNascimento";
            dgvRegistros.Columns[2].Frozen = false;
            dgvRegistros.Columns[2].Width = 100;

            dgvRegistros.Columns[3].HeaderText = "Sexo";
            dgvRegistros.Columns[3].Name = "Sexo";
            dgvRegistros.Columns[3].Frozen = false;
            dgvRegistros.Columns[3].Width = 100;

            dgvRegistros.Columns[4].HeaderText = "Limite de Compra";
            dgvRegistros.Columns[4].Name = "LimiteCompra";
            dgvRegistros.Columns[4].Frozen = false;
            dgvRegistros.Columns[4].Width = 150;
        }
        #endregion
    }
}
