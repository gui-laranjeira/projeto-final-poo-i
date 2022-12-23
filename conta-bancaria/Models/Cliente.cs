using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models
{
    internal class Cliente
    {
        // public Cliente() { }

        public Cliente(string nome, string sobrenome, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            DataNascimento= dataNascimento;
        }

        private string _nome;
        private string _sobrenome;
        public string Nome
        {
            get => _nome;

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("O nome não pode ser vazio. Insira um nome.");
                }
                _nome = value;
            }
        }

        private string Sobrenome
        {
            get => _sobrenome;

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("O sobrenome não pode ser vazio. Insira um sobrenome.");
                }
                _sobrenome = value;
            }
        }

        private string Cpf { get; set; }

        private DateTime DataNascimento { get; set; }

        public void ExibirDados()
        {
            Console.WriteLine($"Nome: {Nome} {Sobrenome}");
            Console.WriteLine($"CPF: {Cpf}");
            Console.WriteLine($"Data de nascimento: {DataNascimento}");
        }
    }
}