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
        private double taxaDeManutencao = 0.08;


        public ContaInvestimento(Cliente cliente) : base(cliente)
        {
        }


        public string AvaliarPerfilInvestidor()
        {
            string[] respostas = new string[5];
            string perfilInvestidor;
            int contador = 0;

            Console.WriteLine($"Ok, -NomeCliente- , vamos analisar seu perfil!\n Responda SIM OU NÃO");

            Console.WriteLine("1 - Você gosta de correr riscos? ");
            respostas[0] = Console.ReadLine();
            Console.WriteLine("2 - Você tem interesse por econômia?");
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
                perfilInvestidor = "Você tem um perfil CONSERVADOR!";
            }
            else if (contador == 2)
            {
                perfilInvestidor = "Você tem um perfil MODERADOR!";              
            }
            else
            {
                perfilInvestidor = "Você tem um perfil AGRESSIVO!";              
            }
            return perfilInvestidor;
        }


        public decimal InvestirEmAcoes(decimal investimentoInicial)
        {
            decimal retornoDeInvestimento;

            if (investimentoInicial > 500)
            {
                retornoDeInvestimento = investimentoInicial += (investimentoInicial * 10) / 100;
                return retornoDeInvestimento;
            }
            else if (investimentoInicial > 1000)
            {
                retornoDeInvestimento = investimentoInicial += (investimentoInicial * 15) / 100;
                return retornoDeInvestimento;
            }
            else if (investimentoInicial > 5000)
            {
                retornoDeInvestimento = investimentoInicial += (investimentoInicial * 20) / 100;
                return retornoDeInvestimento;
            }
            return investimentoInicial;
        }

        public override double CalcularValorTarifaManutencao()
        {
            double tarifa = this.taxaDeManutencao * (Saldo / 100);
            return tarifa;
        }
    }

}


