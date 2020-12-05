using ERP.Core.Interfaces;
using ERP.Entidades;
using ERP.Entidades.FiltrosDePesquisa;
using ERP.Infraestrutura.Persistencia.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Negocio
{
    public class NCliente : IValidarCampos
    {
        private readonly ClienteRepositorio repositorio = new ClienteRepositorio();
        private StringBuilder retornoValidarCampos = new StringBuilder();

        public async Task<Tuple<int, string>> Inserir(Cliente cliente)
        {
            if (!ValidarCampos(cliente))
            {
                return new Tuple<int, string>(-1, retornoValidarCampos.ToString());
            }

            var result = await repositorio.Inserir(cliente);

            return new Tuple<int, string>(result, "");
        }

        public async Task<Tuple<int, string>> Alterar(Cliente cliente)
        {
            if (!ValidarCampos(cliente))
            {
                return new Tuple<int, string>(0, retornoValidarCampos.ToString());
            }

            var result = await repositorio.Alterar(cliente);

            return new Tuple<int, string>(result, "");
        }

        public async Task<Tuple<bool, string>> Excluir(int id)
        {
            return await repositorio.Excluir(id);
        }

        public async Task<List<Cliente>> SelecionarTodos(FiltroCliente filtro)
        {
            return await repositorio.SelecionarTodos(filtro);
        }

        public async Task<Cliente> SelecionarPorId(int id)
        {
            return await repositorio.SelecionarPorId(id);
        }

        #region ValidarCampos
        public bool ValidarCampos(object entidade)
        {
            var entidadeTratada = (Cliente)entidade;

            retornoValidarCampos.AppendLine("Os seguintes campos são obrigatórios: ");
            bool entidadeValida = true;

            if (string.IsNullOrWhiteSpace(entidadeTratada.Nome))
            {
                retornoValidarCampos.AppendLine("Nome inválido!");
                entidadeValida = false;
            }

            if (entidadeTratada.DataNascimento > DateTime.Now)
            {
                retornoValidarCampos.AppendLine("Data de Nascimento não pode ser maior que a data atual!");
                entidadeValida = false;
            }

            if (entidadeTratada.DataNascimento == null)
            {
                retornoValidarCampos.AppendLine("Data de Nascimento inválida!");
                entidadeValida = false;
            }

            return entidadeValida;
        }
        #endregion
    }
}
