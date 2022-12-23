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
  


        public ContaInvestimento(int numeroConta, Cliente cliente) : base(numeroConta, cliente)
        {
        }


        public string avaliarPerfilInvestidor(double valorDisponivel)
        {
            bool check;

            Console.WriteLine("\nDefina seu perfil de investidor! ");
            Console.WriteLine("Qual valor tem disponível para investimento?");
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


            return investimento;
        }

        public override double CalcularValorTarifaManutencao()
        {
            double tarifa = this.taxaDeManutencao * (Saldo / 100);
            return tarifa;
        }



    }
}
