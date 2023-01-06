using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models
{
    internal class ContaSalario : Conta
    {
        public double taxaDeSaque { get; } = 0.3;
        public string CnpjEmpresa { get; protected set; }
        public Holerite Holerite { get; protected set; }

        public ContaSalario(Cliente cliente, Holerite holerite) : base(cliente)
        {
            this.Holerite = holerite;
            this.CnpjEmpresa = holerite.CnpjEmpresa;
        }


        public void Depositar(string cnpj)  
        {
            Console.WriteLine("Para concluir o Deposito, digite os 3 primeiros digitos do CNPJ da Empresa");
            string senhaCNPJ = Console.ReadLine();
            if (Holerite.CnpjEmpresa.StartsWith(senhaCNPJ) && senhaCNPJ.Length == 3)
            {
                Console.WriteLine($"Salário depositado com sucesso: R${Holerite.Salario.ToString("0.00")}");
                base.Depositar(Holerite.Salario);
            }
            else
            {
                Console.WriteLine("CNPJ inserido não corresponde ao cnpj da empresa cadastrada");
            }                   
        }

         public void OperacoesSalario(int inputUsuario)
        {
            bool check;
            switch (inputUsuario)
            {   
                case 1:
                    Console.Clear();
                    Depositar(CnpjEmpresa);
                    Console.WriteLine("\nPressione ENTER para continuar!");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    double valorSaque;
                    do
                    {
                        Console.WriteLine("\nInsira o valor que quer sacar:");
                        check = double.TryParse(Console.ReadLine(), out valorSaque);
                    } while (!check);
                    if (valorSaque < 0)
                        valorSaque *= -1;
                    Sacar(valorSaque, taxaDeSaque);
                    Console.WriteLine("\nPressione ENTER para continuar!");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Extrato();
                    Console.WriteLine("Valores positivos para depósito\nValores negativos para saque e taxas de manutenção");
                    Console.WriteLine("\nPressione ENTER para continuar!");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine();
                    Cliente.VisualizarDados();
                    Console.WriteLine("\nPressione ENTER para continuar!");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
