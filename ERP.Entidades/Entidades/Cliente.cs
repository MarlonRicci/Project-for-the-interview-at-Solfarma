using ERP.Entidades.Enums;
using System;

namespace ERP.Entidades
{
    public class Cliente
    {
        public Cliente(int codigo, string nome, DateTime dataNascimento, ESexo sexo, decimal limiteCompra)
        {
            Codigo = codigo;
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            LimiteCompra = limiteCompra;
        }

        public Cliente(string nome, DateTime dataNascimento, ESexo sexo, decimal limiteCompra)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            LimiteCompra = limiteCompra;
        }

        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public ESexo Sexo { get; private set; }
        public decimal LimiteCompra { get; private set; }
    }
}
