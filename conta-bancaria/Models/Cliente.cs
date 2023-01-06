using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace conta_bancaria.Models
{
    public class Cliente
    {       
        public string Nome { get; protected set; }
        public string Sobrenome { get; protected set; }
        private int Idade { get; set; }
        public string Cpf { get; private set; }

        public void RegistrarCliente()
        {      
            Console.WriteLine("Complete seu cadastro:\n");
            bool checkNome = false;

            do
            {
                Console.Write("Informe seu nome: ");
                string nome = Console.ReadLine();

                if (!String.IsNullOrEmpty(nome))
                {
                    checkNome = nome.ToLower().All(c => Char.IsLetter(c) || c == ' ');
                    if (checkNome)
                        Nome = nome;
                }
                else
                    Console.WriteLine("Insira um nome válido.");

            } while (!checkNome);

            bool checkSobrenome = false;
            do
            {
                Console.Write("Informe seu sobrenome: ");
                string sobrenome = Console.ReadLine();

                if (!String.IsNullOrEmpty(sobrenome))
                {
                    checkSobrenome = sobrenome.ToLower().All(c => Char.IsLetter(c) || c == ' ');
                    if (checkSobrenome)
                        Sobrenome = sobrenome;
                }
                else
                    Console.WriteLine("Insira um sobrenome válido.");

            } while(!checkSobrenome);

            do
            {
                Console.Write("Informe sua idade: ");
                int.TryParse(Console.ReadLine(), out int idade);
                if(idade < 18)
                {
                    Console.WriteLine("Você precisa ser maior de idade para abrir uma conta no nosso banco!");
                }
                else if(idade > 100)
                {
                    Console.WriteLine("Você precisa ter menos de 100 anos pra ter conta!");
                }
                else 
                { 
                    Idade = idade;
                }
            } while (Idade < 18 || Idade > 100);


            do
            {
                Console.Write("Informe seu CPF (apenas números): ");
                string cpf = Console.ReadLine();
                if (long.TryParse(cpf, out long teste) && cpf.Length == 11)
                {
                    Cpf = cpf;
                }
                else
                    Console.WriteLine("O CPF deve conter somente números e deve ter 11 dígitos. Tente novamente.");

            } while (String.IsNullOrEmpty(Cpf));

            Console.Clear();
        }

        public void VisualizarDados()
        {
            Console.WriteLine("******************************************");
            Console.WriteLine($"Nome do cliente: \t {Nome} {Sobrenome}");
            Console.WriteLine($"Idade: \t {Idade}");
            Console.WriteLine($"Cpf: \t {Cpf}");
            Console.WriteLine("******************************************");
        }

    }

}