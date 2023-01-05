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
        private string Cpf { get; set; }

        public void RegistrarCliente()
        {      
            Console.WriteLine("Complete seu cadastro:\n");
            bool checkNome;
            do
            {
                Console.Write("Informe seu nome: ");
                string nome = Console.ReadLine();
                checkNome = nome.ToLower().All(c => Char.IsLetter(c) || c == ' ');
                if (checkNome)
                {
                    Nome = nome;             
                }    
            } while (!checkNome);

            bool checkSobrenome;
            do
            {
                Console.Write("Informe seu sobrenome: ");
                string sobrenome = Console.ReadLine();
                checkSobrenome = sobrenome.ToLower().All(c => Char.IsLetter(c) || c == ' ');
                if (checkSobrenome)
                {
                    Sobrenome = sobrenome;
                }                
            } while(!checkSobrenome);

            do
            {
                Console.Write("Informe sua idade: ");
                int.TryParse(Console.ReadLine(), out int idade);
                Idade = idade;       
            } while (Idade < 18 || Idade > 100);

            bool checkCpf;
            do
            {
                Console.Write("Informe seu CPF: ");
                string cpf = Console.ReadLine();
                checkCpf = Regex.IsMatch(cpf, @"^([0-9]{2}[.]?[0-9]{3}[.]?[0-9]{3}[/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[.]?[0-9]{3}[.]?[0-9]{3}[-]?[0-9]{2})+$");
                if (checkCpf)
                {
                    Cpf = cpf;
                }                    
            }while(!checkCpf);

            Console.Clear();
        }

        public void VisualizarDados()
        {
            Console.WriteLine("************************************");
            Console.WriteLine($"Nome do cliente:\t{Nome} {Sobrenome}.");
            Console.WriteLine($"Idade:\t {Idade}.");
            Console.WriteLine($"Cpf:\t {Cpf}.");
            Console.WriteLine("************************************");
        }

    }

}