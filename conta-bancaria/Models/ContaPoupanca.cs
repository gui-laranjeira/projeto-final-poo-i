using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models
{
  
   public class ContaPoupanca : Conta
   {
        //Propriedades:
        public double taxaDeSaque { get; } = 0.35;

        public ContaPoupanca(Cliente cliente) : base(cliente)
        {
                        
        }

        public void AbrirContaPoupanca()
        {
            Saldo = 0;
            bool deposito;
            double depositoMinimo;

            Console.WriteLine("\nPara abertura de CONTA POUPANÇA é necessário um depósito inicial!\n\n*Valor mínimo de R$100,00*\n");
            //validação do depósito:
            do
            {
                Console.WriteLine("\nDigite o valor a ser depositado: ");
                deposito = double.TryParse(Console.ReadLine(), out depositoMinimo);
            } while (depositoMinimo < 100);

            //possuirá a mesma caracteristica do depósito normal (herdado da classe pai)
            base.Depositar(depositoMinimo);
        }

      
        // Método especifico de transferência herdará as mesmas características do depósito
        public void TransferirParaPoupanca(double valor)
        {
            base.Depositar(valor);
        }

          public void OperacoesPoupanca(int inputUsuario)
        {
            bool check;
            switch (inputUsuario)
            {
                case 1:
                    Console.Clear();
                    double valorTransf;
                    do
                    {
                        Console.WriteLine("Digite o valor que deseja transferir para poupança:");
                        check = double.TryParse(Console.ReadLine(), out valorTransf);
                    } while (!check);
                    if (valorTransf < 0)
                        valorTransf *= -1;
                    TransferirParaPoupanca(valorTransf);
                    Console.WriteLine("\nPressione ENTER para continuar!");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Para concluir o Saque, digite os 3 primeiros digitos do seu CPF");
                    string senhaCPF = Console.ReadLine();
                    if (Cliente.Cpf.StartsWith(senhaCPF) && senhaCPF.Length == 3)
                    {
                        double valorSaque;
                        do
                        {
                            Console.WriteLine("Digite o valor que deseja sacar: ");
                            check = double.TryParse(Console.ReadLine(), out valorSaque);
                        } while (!check);
                        if (valorSaque < 0)
                            valorSaque *= -1;
                        Sacar(valorSaque, taxaDeSaque);
                    }
                    else
                    {
                        Console.WriteLine("Senha inválida");
                    }
                    
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
                    Cliente.VisualizarDados();
                    Console.WriteLine("\nPressione ENTER para continuar!");
                    Console.ReadKey();
                    break;
            }

        }


    }

}
