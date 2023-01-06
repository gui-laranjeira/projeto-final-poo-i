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
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        private int Idade { get; set; }
        public string Cpf { get; private set; }

        public void RegistrarCliente()
        {      
            Console.WriteLine("\nComplete seu cadastro:\n");
            bool checkNome = false;

            do
            {
                Console.Write("\nInforme seu nome: ");
                string nome = Console.ReadLine();

                if (!String.IsNullOrEmpty(nome))
                {
                    checkNome = nome.ToLower().All(c => Char.IsLetter(c) || c == ' ');
                    if (checkNome)
                        Nome = nome;
                }
                else
                    Console.WriteLine("\nInsira um nome válido.");

            } while (!checkNome);

            bool checkSobrenome = false;
            do
            {
                Console.Write("\nInforme seu sobrenome: ");
                string sobrenome = Console.ReadLine();

                if (!String.IsNullOrEmpty(sobrenome))
                {
                    checkSobrenome = sobrenome.ToLower().All(c => Char.IsLetter(c) || c == ' ');
                    if (checkSobrenome)
                        Sobrenome = sobrenome;
                }
                else
                    Console.WriteLine("\nInsira um sobrenome válido.");

            } while(!checkSobrenome);

            do
            {
                Console.Write("\nInforme sua idade: ");
                int.TryParse(Console.ReadLine(), out int idade);
                if(idade < 18)
                {
                    Console.WriteLine("\nVocê precisa ser maior de idade para abrir uma conta no nosso banco!");
                }
                else if(idade > 100)
                {
                    Console.WriteLine("\nVocê precisa ter menos de 100 anos pra ter conta!");
                }
                else 
                { 
                    Idade = idade;
                }
            } while (Idade < 18 || Idade > 100);


            do
            {
                Console.Write("\nInforme seu CPF (apenas números): ");
                string cpf = Console.ReadLine();
                if (long.TryParse(cpf, out long teste) && cpf.Length == 11)
                {
                    Cpf = cpf;
                }
                else
                    Console.WriteLine("\nO CPF deve conter somente números e deve ter 11 dígitos. Tente novamente.");

            } while (String.IsNullOrEmpty(Cpf));

            Console.Clear();
        }

        public void VisualizarDados()
        {
            Console.WriteLine("******************************************");
            Console.WriteLine($"Nome do cliente: \t {Nome.ToUpper()} {Sobrenome.ToUpper()}");
            Console.WriteLine($"Idade: \t {Idade}");
            Console.WriteLine($"Cpf: \t {Cpf}");
            Console.WriteLine("******************************************");
        }

    }

}