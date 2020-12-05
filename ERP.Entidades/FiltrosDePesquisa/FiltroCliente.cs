namespace ERP.Entidades.FiltrosDePesquisa
{
    public class FiltroCliente
    {
        public FiltroCliente(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; private set; }
    }
}
