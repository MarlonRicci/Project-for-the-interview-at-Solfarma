using ERP.Entidades;
using ERP.Entidades.FiltrosDePesquisa;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Infraestrutura.Persistencia.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<int> Inserir(Cliente cliente);
        Task<int> Alterar(Cliente cliente);
        Task<Cliente> SelecionarPorId(int id);
        Task<List<Cliente>> SelecionarTodos(FiltroCliente filtro);
        Task<Tuple<bool, string>> Excluir(int codigo);
    }
}
