using ERP.Entidades;
using ERP.Entidades.Enums;
using ERP.Entidades.FiltrosDePesquisa;
using ERP.Infraestrutura.AcessoDados.Configurations;
using ERP.Infraestrutura.Persistencia.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infraestrutura.Persistencia.Repositorios
{
    internal class ClienteRepositorio : IClienteRepositorio
    {
        private readonly AcessoBancoDados acessoDados = new AcessoBancoDados();
        private List<Cliente> clientes = new List<Cliente>();

        public async Task<int> Inserir(Cliente cliente)
        {
            try
            {
                #region sql
                const string sql =
                @"
                INSERT INTO tblCliente
                (
                    Nome,
	                DataNascimento,
	                Sexo,
	                LimiteCompra
                )
                VALUES
                (
                    @Nome,
	                @DataNascimento,
	                @Sexo,
	                @LimiteCompra
                );
                
                select SCOPE_IDENTITY();
                ";
                #endregion

                acessoDados.AdicionarParametro("@Nome", cliente.Nome, SqlDbType.VarChar);
                acessoDados.AdicionarParametro("@DataNascimento", cliente.DataNascimento, SqlDbType.Date);
                acessoDados.AdicionarParametro("@Sexo", cliente.Sexo, SqlDbType.Bit);
                acessoDados.AdicionarParametro("@LimiteCompra", cliente.LimiteCompra, SqlDbType.Decimal);

                return Convert.ToInt32(await acessoDados.Executar(sql));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Alterar(Cliente cliente)
        {
            #region sql
            string sql =
            @"
                UPDATE 
                    tblCliente
                SET
                    Nome            = @Nome,
	                DataNascimento  = @DataNascimento,
	                Sexo            = @Sexo,
	                LimiteCompra    = @LimiteCompra
                WHERE 
                    Codigo = @Codigo
            ";
            #endregion

            acessoDados.AdicionarParametro("@Codigo", cliente.Codigo);
            acessoDados.AdicionarParametro("@Nome", cliente.Nome, SqlDbType.VarChar);
            acessoDados.AdicionarParametro("@DataNascimento", cliente.DataNascimento, SqlDbType.Date);
            acessoDados.AdicionarParametro("@Sexo", cliente.Sexo, SqlDbType.Bit);
            acessoDados.AdicionarParametro("@LimiteCompra", cliente.LimiteCompra, SqlDbType.Decimal);

            return Convert.ToInt32(await acessoDados.Executar(sql));
        }

        public async Task<Tuple<bool, string>> Excluir(int codigo)
        {
            try
            {
                #region sql
                string sql =
                @"
                DELETE FROM 
                    tblCliente
                WHERE 
                    Codigo = @Codigo
                ";
                #endregion

                acessoDados.AdicionarParametro("@Codigo", codigo);

                await acessoDados.Executar(sql);

                return new Tuple<bool, string>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }
        }

        public async Task<List<Cliente>> SelecionarTodos(FiltroCliente filtro)
        {
            #region sql
            string sql =
            @"
                SELECT
                    Codigo,
                    Nome,
	                DataNascimento,
	                Sexo,
	                LimiteCompra
                FROM
                    tblCliente
                {Where}
            ";
            #endregion

            if (!string.IsNullOrWhiteSpace(filtro.Nome))
            {
                acessoDados.AdicionarParametro("@Nome", string.Concat("%", filtro.Nome, "%"));

                sql = sql.Replace("{Where}", "WHERE Nome LIKE @Nome");
            }
            else
                sql = sql.Replace("{Where}", "");

            var result = await acessoDados.ExecutarConsulta(sql);

            return MapearCliente(result);
        }

        public async Task<Cliente> SelecionarPorId(int id)
        {
            #region sql
            string sql =
            @"
                SELECT
                    Codigo,
                    Nome,
	                DataNascimento,
	                Sexo,
	                LimiteCompra
                FROM
                    tblCliente
                WHERE Codigo = @Codigo
            ";
            #endregion

            acessoDados.AdicionarParametro("@Codigo", id);

            var result = await acessoDados.ExecutarConsulta(sql);

            return MapearCliente(result).FirstOrDefault();
        }

        #region Métodos
        private List<Cliente> MapearCliente(SqlDataReader r)
        {
            clientes.Clear();

            while (r.Read())
            {
                clientes.Add(new Cliente(
                    (int)r["Codigo"],
                    (string)r["Nome"],
                    (DateTime)r["DataNascimento"],
                    (bool)r["Sexo"] ? ESexo.Masculino : ESexo.Feminino,
                    (decimal)r["LimiteCompra"]
                ));
            }

            return clientes;
        }
        #endregion
    }
}
