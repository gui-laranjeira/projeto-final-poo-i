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
        private double taxaDeManutencao = 0.08;
        public int NumeroConta { get; private set; }


        public ContaInvestimento(Cliente cliente) : base(cliente)
        {
            AvaliarPerfilInvestidor();
         
        }

        public string AvaliarPerfilInvestidor()
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
                Console.WriteLine("3 - Você gosta da ideia 'devagar e sempre'?");
                check = int.TryParse(Console.ReadLine(), out respostas[1]);
                Console.WriteLine("4 - Você tem experiência com investimentos?");
                check = int.TryParse(Console.ReadLine(), out respostas[2]);
                Console.WriteLine("5 - Pode se dar ao luxo de perder dinheiro?");
                check = int.TryParse(Console.ReadLine(), out respostas[3]);
            } while (!check);


            foreach (int resposta in respostas)
            {
                if (resposta == 2)
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

            Console.WriteLine("Digite um valor para iniciar o investimento em ações");
          
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
