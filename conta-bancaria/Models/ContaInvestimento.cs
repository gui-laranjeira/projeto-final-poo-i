using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models
{
    public class ContaInvestimento : Conta
    {
        public double taxaDeManutencao = 0.08;
        bool check;

        public ContaInvestimento(Cliente cliente) : base(cliente)
        {
        }


        public string AvaliarPerfilInvestidor(double valorDisponivel)
        {
            string[] respostas = new string[5];
            int contador = 0;

            Console.WriteLine("1 - Você gosta de correr riscos? ");
            respostas[0] = Console.ReadLine();
            Console.WriteLine("2 - Você tem interesse por economia?");
            respostas[1] = Console.ReadLine();
            Console.WriteLine("3 - Você gosta da ideia 'devagar e sempre'?");
            respostas[2] = Console.ReadLine();
            Console.WriteLine("4 - Você tem experiência com investimentos?");
            respostas[3] = Console.ReadLine();
            Console.WriteLine("5 - Pode se dar ao luxo de perder dinheiro?");
            respostas[4] = Console.ReadLine();

            foreach (string resposta in respostas)
            {
                if (resposta == "nao")
                    contador++;
            }
            if (contador == 3)
            {
                return "conservador";
            }
            else if (contador == 2)
            {
                return "moderado";
            }
            else
            {
                return"agressivo";
            }
        }
    

    public double InvestirEmAcoes(double investimento)
        {
            double retornoDeInvestimento;
             bool check;

            Console.WriteLine("Defina o valor de investimento: ");
            check = double.TryParse(Console.ReadLine(), out investimento);

            if (investimento > 500)
            {
                retornoDeInvestimento = investimento += (investimento * 10) / 100;
                return retornoDeInvestimento;
            }
            else if (investimento > 1000)
            {
                retornoDeInvestimento = investimento += (investimento * 15) / 100;
                return retornoDeInvestimento;
            }
            else if(investimento > 5000)
            {
                retornoDeInvestimento = investimento += (investimento * 20) / 100;
                return retornoDeInvestimento;
            }
            return investimento;
        }

        public override double CalcularValorTarifaManutencao()
        {
            double tarifa = this.taxaDeManutencao * (Saldo / 100);
            return tarifa;
        }
    }

}


