using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            do
            {
                Console.Write("Informe seu nome: ");
                string nome = Console.ReadLine();
                Nome = nome;
            } while (Nome == string.Empty);
            do
            {
                Console.Write("Informe seu sobrenome: ");
                string sobrenome = Console.ReadLine();
                Sobrenome = sobrenome;
            } while(Sobrenome == string.Empty);
            do
            {
                Console.Write("Informe sua idade: ");
                int.TryParse(Console.ReadLine(), out int idade);
                Idade = idade;       
            } while (Idade < 18 || Idade > 100);

            do
            {
                Console.Write("Informe seu CPF: ");
                string cpf = Console.ReadLine();
                Cpf = cpf;
            }while(Cpf == string.Empty);

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