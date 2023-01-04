using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models
{
  
   public class ContaPoupanca : Conta
   {
        //Propriedades:
        private double taxaDeSaque { get; set; } = 0.035;

        //Construtor: obrigará o deposito antes da abertura da conta
        public ContaPoupanca(Cliente cliente) : base(cliente)
        {
            depositoInicial();
        }

        public void AbrirContaPoupanca()
        {
            int inputUsuario = MenuDeOperacoes();

            switch (inputUsuario)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Digite o valor que deseja transferir:");
                    double valorTransf = double.Parse(Console.ReadLine());
                    contaP.TransferirParaPoupanca(valorTransf);
                    Console.WriteLine("\nPressione ENTER para continuar!");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Digite o valor que deseja sacar: ");
                    double valorSaq = double.Parse(Console.ReadLine());
                    contaP.Sacar(valorSaq);
                    Console.WriteLine("\nPressione ENTER para continuar!");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    contaP.Extrato();
                    Console.WriteLine("\nPressione ENTER para continuar!");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    cliente.VisualizarDados();
                    Console.WriteLine("\nPressione ENTER para continuar!");
                    Console.ReadKey();
                    break;
                case 9:
                    break;
            }

        }



        // Método privado pois ele será acessado somente na instanciação de um novo cliente
        private void depositoInicial()
        {
            Saldo = 0;
            bool deposito;
            double depositoMinimo;

            Console.WriteLine("\nPara abertura de CONTA POUPANÇA é necessário um depósito inicial!\n*Valor mínimo de R$100,00*\n");
            //validação do depósito:
            do
            {
                Console.WriteLine("\nDigite o valor a ser depositado: ");
                deposito = double.TryParse(Console.ReadLine(), out depositoMinimo);
            } while (depositoMinimo < 100);

            //possuirá a mesma caracteristica do depósito normal (herdado da classe pai)
            base.Depositar(depositoMinimo);
        }

        // por ser poupança, neste método, apenas caso o cliente seja maior de 18 anos ele irá funcionar
        public override void Sacar(double valor)
        {
            base.Sacar(valor);
        }

        // Método especifico de transferência herdará as mesmas características do depósito
        public void TransferirParaPoupanca(double valor)
        {
            base.Depositar(valor);
        }


        //Método da tarifa específica (preciso verificar se o valor da taxa está correto)
        public override double CalcularValorTarifaManutencao()
        {
            double tarifa = this.taxaDeSaque * (Saldo / 100);
            return tarifa;
        }

        public int MenuOpcoes()
        {
            bool verificacao;
            int inputUsuario;
            do
            {
                Console.WriteLine("\n\nQual operação quer realizar\n");
                Console.WriteLine("(1) - Transferir para poupança");
                Console.WriteLine("(2) - Sacar");
                Console.WriteLine("(3) - Extrato");
                Console.WriteLine("(4) - Dados cliente");
                Console.WriteLine("(9) - Finalizar programa");

                verificacao = int.TryParse(Console.ReadLine(), out inputUsuario);

            } while (!verificacao);
            return inputUsuario;
        }
    }

}
