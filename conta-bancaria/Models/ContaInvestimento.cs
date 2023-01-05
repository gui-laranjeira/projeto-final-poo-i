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

            Console.WriteLine($"Ok, vamos analisar seu perfil!\nResponda (1) para sim ou (2) para não");
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
            Console.WriteLine("Pressione enter para continuar...");
            Console.ReadKey();
        }
     
        public void InvestirEmAcoes(double investimentoInicial)
        {
            double retorno = 0;
            double investimentoFinal = 0;

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

            Console.WriteLine($"Sua valor de deposito é: {investimentoInicial}");
            Console.WriteLine($"Sua rentabilidade mensal será de {retorno}");
            Console.WriteLine("Pressione enter para continuar...");
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
    }
}
