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

        public ContaInvestimento(int numeroConta, Cliente cliente) : base(cliente)
        {
        }


        public string AvaliarPerfilInvestidor(double valorDisponivel)
        {
            Console.WriteLine("\nDefina seu perfil de investidor! ");
            Console.WriteLine("Você gosta de arriscar?");
            check = double.TryParse(Console.ReadLine(), out valorDisponivel);

            if (valorDisponivel > 500)
            {
                return "Conservador";
            }
            else if(valorDisponivel > 1000)
            {
                return "Moderado";
            }
            else
            {
                return "Agressivo";
            }
        }

        public double InvestirEmAcoes(double investimento)
        {
            double retornoDeInvestimento;

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


