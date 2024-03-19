﻿namespace Commerce.Domain.Entitie
{
    public class Produto : Entity
    {
        public Produto(string nome, double valor, int estoque, int id)
        {
            Nome = nome;
            Valor = valor;
            Estoque = estoque;
            Id = id;
        }

        public Produto(string nome, double valor, int estoque)
        {
            Nome = nome;
            Valor = valor;
            Estoque = estoque;
        }

        public string Nome { get; private set; }
        public double Valor { get; private set; }
        public int Estoque { get; private set; }

        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public void SetValor(double valor)
        {
            Valor = valor;
        }

        public void SetEstoque(int estoque)
        {
            Estoque = estoque;
        }
    }
}
