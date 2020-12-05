using ERP.Core.Negocio;
using ERP.Entidades;
using ERP.Entidades.Enums;
using System;
using System.Windows.Forms;

namespace ERP.View.Desktop
{
    public partial class frmCadCliente : Form
    {
        #region Propriedades
        public int Codigo {
            get { return Convert.ToInt32(txtCodigo.Text); }
            set { txtCodigo.Text = value.ToString(); }
        }

        public string Nome {
            get { return txtNome.Text; }
            set { txtNome.Text = value; }
        }

        public DateTime DataNascimento {
            get { return dtpDataNascimento.Value; }
            set { dtpDataNascimento.Value = value; }
        }

        public ESexo Sexo {
            get { return (ESexo)cmbSexo.SelectedIndex; }
            set { cmbSexo.SelectedIndex = (int)value; }
        }

        public decimal LimiteCompra {
            get { return decimal.TryParse(txtLimiteCompra.Text.Replace("R$", ""), out decimal result) ? result : 0; }
            set { txtLimiteCompra.Text = value.ToString("C"); }
        }
        #endregion

        private NCliente nCliente = new NCliente();

        public frmCadCliente(int codigo = 0)
        {
            InitializeComponent();

            cmbSexo.SelectedIndex = 0;

            Codigo = codigo;
        }
        #region Eventos
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var result = new Tuple<int, string>(0, "");

                if (Codigo == 0)
                {
                    result = await nCliente.Inserir(new Cliente
                    (
                        Nome,
                        DataNascimento,
                        Sexo,
                        LimiteCompra
                    ));

                    if (result.Item1 > 0)
                    {
                        Codigo = result.Item1;

                        MessageBox.Show($"Dados salvos com sucesso!",
                                "Sucesso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                        return;
                    }
                }
                else
                {
                    result = await nCliente.Alterar(new Cliente
                    (
                        Codigo,
                        Nome,
                        DataNascimento,
                        Sexo,
                        LimiteCompra
                    ));

                    if (result.Item1 == 0)
                    {
                        MessageBox.Show($"Dados Alterados com sucesso!",
                                "Sucesso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                        return;
                    }
                }


                MessageBox.Show($"Ocorreu um erro ao tentar inserir o registro.\r\n{result.Item2}",
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar inserir o registro.\r\n{ex.Message}",
                                 "Erro",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        private void txtLimiteCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            string campoTratado = txtLimiteCompra.Text.Replace("R$", "");

            if (char.IsNumber(e.KeyChar) || e.KeyChar == '\b')
                return;

            if (e.KeyChar != ',' && e.KeyChar != '.')
                e.Handled = true;

            if ((e.KeyChar == ',') && campoTratado.Contains(","))
                e.Handled = true;
        }

        private void txtLimiteCompra_Leave(object sender, EventArgs e)
        {
            string campoTratado = txtLimiteCompra.Text.Replace("R$", "");

            if (!decimal.TryParse(campoTratado, out _) && campoTratado != "")
            {
                MessageBox.Show("Limite de Compra inválido ou vazio!",
                                "Atenção",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtLimiteCompra.Focus();
            }
        }

        private async void frmCadCliente_Load(object sender, EventArgs e)
        {
            if (Codigo != 0)
            {
                var cliente = await nCliente.SelecionarPorId(Codigo);

                Codigo = cliente.Codigo;
                Nome = cliente.Nome;
                DataNascimento = cliente.DataNascimento;
                Sexo = cliente.Sexo;
                LimiteCompra = cliente.LimiteCompra;
            }
        }
        #endregion
    }
}
