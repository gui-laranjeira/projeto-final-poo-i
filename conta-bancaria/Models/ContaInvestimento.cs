using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models
{
    public class ContaInvestimento : Conta
    {
        public double taxaDeManutencao { get;} = 0.8;


        public ContaInvestimento(Cliente cliente) : base(cliente)
        {
            
         
        }

        public void AvaliarPerfilInvestidor()
        {
            int[] respostas = new int[5];
            string perfilInvestidor;
            int contador = 0;
            bool check; 

            Console.WriteLine($"\nOk, vamos analisar seu perfil!\n\nResponda (1) para sim ou (2) para não");
            do
            {
                Console.WriteLine("1 - Você gosta de correr riscos? ");
                check = int.TryParse(Console.ReadLine(), out respostas[0]);
            } while (!check || respostas[0] != 2 && respostas[0] != 1);
            do
            {
                Console.WriteLine("2 - Você gosta da ideia 'devagar e sempre'?");
                check = int.TryParse(Console.ReadLine(), out respostas[1]);
            } while (!check || respostas[1] != 2 && respostas[1] != 1);
            do
            {
                Console.WriteLine("3 - Você tem experiência com investimentos?");
                check = int.TryParse(Console.ReadLine(), out respostas[2]);
            } while (!check || respostas[2] != 2 && respostas[2] != 1);
            do
            {
                Console.WriteLine("4 - Pode se dar ao luxo de perder dinheiro?");
                check = int.TryParse(Console.ReadLine(), out respostas[3]);
            } while (!check || respostas[3] != 2 && respostas[3] != 1);

    
            foreach (int resposta in respostas)
            {
                if (resposta == 1)
                    contador++;
            }
            if (contador < 1)
            {
                perfilInvestidor = "CONSERVADOR!";
            }
            else if (contador < 3)
            {
                perfilInvestidor = "MODERADOR!";              
            }
            else
            {
                perfilInvestidor = "AGRESSIVO!";              
            }
            Console.Clear();
            Console.WriteLine($"Seu perfil é {perfilInvestidor}");
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadKey();
        }
     
        public void InvestirEmAcoes(double investimentoInicial)
        {
            double retorno = 0;            

            if (investimentoInicial < 500)
            {
                retorno = investimentoInicial + investimentoInicial * 10 / 100;
            }
            else if (investimentoInicial < 1000)
            {
                retorno = investimentoInicial + investimentoInicial * 15 / 100;
            }
            else
            {
                retorno = investimentoInicial + investimentoInicial * 20 / 100;
            }

            Console.WriteLine($"\nSua valor de deposito é: R${investimentoInicial.ToString("0.00")}");
            Console.WriteLine($"No final do mês seu dinheiro renderá para: R${retorno.ToString("0.00")}");
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadKey();
            base.Depositar(investimentoInicial);
        }

        public override void Sacar(double valor, double taxaDeSaque)
        {
            base.Sacar(valor, taxaDeSaque);
        }

       
        public void Transferir(double valor)
        {
            base.Depositar(valor);
        }

         public void OperacoesInvestimento(int inputUsuario)
        {
            switch (inputUsuario)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Digite o valor que deseja depositar:");
                    double valorTransf = double.Parse(Console.ReadLine());
                    if (valorTransf < 0)
                        valorTransf *= -1;
                    Transferir(valorTransf);
                    Console.WriteLine("\nPressione ENTER para continuar!");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Digite o valor que deseja sacar: ");
                    double valorSaq = double.Parse(Console.ReadLine());
                    if (valorSaq < 0)
                        valorSaq *= -1;
                    Sacar(valorSaq, taxaDeManutencao);
                    Console.WriteLine("\nPressione ENTER para continuar!");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Extrato();
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
