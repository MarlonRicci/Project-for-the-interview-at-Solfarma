using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ERP.Infraestrutura.AcessoDados.Configurations
{
    internal class AcessoBancoDados
    {
        #region Objetos Estáticos
        internal static SqlConnection sqlconnection = new SqlConnection();
        internal static SqlParameter parametro = new SqlParameter();
        internal static SqlCommand comando = new SqlCommand();
        #endregion

        #region Obter SqlConnection
        internal static SqlConnection GetConexao()
        {
            try
            {
                string dadosConexao = ConfigurationManager.ConnectionStrings["ERP"].ConnectionString;

                sqlconnection = new SqlConnection(dadosConexao);

                if (sqlconnection.State == ConnectionState.Closed)
                    AbrirConexao();

                return sqlconnection;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Abrir Conexão
        internal static void AbrirConexao()
        {
            sqlconnection.Open();
        }
        #endregion

        #region Fechar Conexão
        internal static void FecharConexao()
        {
            sqlconnection.Close();
        }
        #endregion

        #region Adicionar Parâmetros
        internal void AdicionarParametro(string nome, object valor, SqlDbType tipo = SqlDbType.NVarChar, ParameterDirection direcao = ParameterDirection.Input)
        {
            parametro = new SqlParameter();

            parametro.ParameterName = nome;
            parametro.Value = valor;
            parametro.SqlDbType = tipo;
            parametro.Direction = direcao;

            comando.Parameters.Add(parametro);
        }
        #endregion

        #region Limpar Parâmetros
        internal void LimparParametros()
        {
            comando.Parameters.Clear();
        }
        #endregion

        #region Executar Consulta SQL
        internal async Task<SqlDataReader> ExecutarConsulta(string sql)
        {
            try
            {
                comando.Connection = GetConexao();

                comando.CommandText = sql;

                return await comando.ExecuteReaderAsync(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LimparParametros();
            }
        }
        #endregion

        #region Executa uma instrução SQL: INSERT, UPDATE e DELETE
        internal async Task<object> Executar(string sql)
        {
            try
            {
                comando.Connection = GetConexao();
                comando.CommandText = sql;

                var result = await comando.ExecuteScalarAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconnection.Close();

                LimparParametros();
            }
        }
        #endregion
    }
}
