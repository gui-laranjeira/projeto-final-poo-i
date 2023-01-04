using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models
{
    internal class ContaSalario : Conta
    {
        private double taxaDeSaque { get; set; } = 0.3;
        public TipoConta contaSalario { get; protected set; }
        public string CnpjEmpresa { get; protected set; }
        public Holerite Holerite { get; protected set; }

        public ContaSalario(Cliente cliente, Holerite holerite) : base(cliente)
        {
            this.Holerite = holerite;
            this.TipoDeConta = contaSalario;
            this.CnpjEmpresa = holerite.CnpjEmpresa;
        }

        public void AbrirContaSalario()
        {
            Console.WriteLine("Para criarmos uma conta salário, precisamos das informações do seu empregador.");
            Console.WriteLine("Insira o CNPJ da empresa:");
            string cnpj = Console.ReadLine();

            Console.WriteLine("\nInsira a Razão Social da empresa:");
            string nomeEmpresa = Console.ReadLine();

            Console.WriteLine("\nInsira o endereço da empresa:");
            string enderecoEmpresa = Console.ReadLine();

            Console.WriteLine("\nQual seu cargo na empresa:");
            string cargoFuncionario = Console.ReadLine();

            bool convertSalarioBruto;
            double salarioBruto;
            do
            {
                Console.WriteLine("\nInsira seu salário bruto:");
                convertSalarioBruto = double.TryParse(Console.ReadLine(), out salarioBruto);
            } while (!convertSalarioBruto);
        }


        public void Depositar(string cnpj)
        {
            if (Holerite.CnpjEmpresa == cnpj)
            {
                base.Depositar(Holerite.Salario);
            }
            else
            {
                Console.WriteLine("CNPJ inserido não corresponde ao cnpj da empresa cadastrada");
            }                   
        }

        public override double CalcularValorTarifaManutencao()
        {
                    
            double tarifa = this.taxaDeSaque * (Saldo / 100);
            return tarifa;
        }
    }
}
