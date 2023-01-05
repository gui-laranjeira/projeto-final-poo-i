using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models
{
    public class Holerite 
    {
        public Holerite(Cliente cliente)
        {                  
            //CnpjEmpresa = cnpjEmpresa;
            //NomeEmpresa = nomeEmpresa;
            //EndereçoEmpresa = endereçoEmpresa;
            //CargoFuncionario = cargoFuncionario;
            //Salario = salarioB;                    
            NomeCliente = cliente.Nome;
            SobrenomeCliente = cliente.Sobrenome;
        }



        public string CnpjEmpresa { get; protected set; }
        private string NomeEmpresa { get; set; }        
        private string EnderecoEmpresa { get; set; }
        private string CargoFuncionario { get; set; }
        public double Salario { get; protected set; }               
        public string NomeCliente { get; set; }
        public string SobrenomeCliente { get; set; }
       

        public void AbrirHolerite()
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

            this.CnpjEmpresa = cnpj;
            this.NomeEmpresa = nomeEmpresa;
            this.EnderecoEmpresa = enderecoEmpresa;
            this.CargoFuncionario = cargoFuncionario;
            this.Salario = salarioBruto;
        }


        public void HoleriteCompleto()
        {
        Console.WriteLine(@$" 

        HOLERITE

        ____________________________________________________________________________________________________________
        EMPREGADOR                                                                    RECIBO DE PAGAMENTO DE SALÁRIO
        {NomeEmpresa.ToUpper()}   

        ENDEREÇO: {EnderecoEmpresa.ToUpper()}           CNPJ: {CnpjEmpresa}
        
        ____________________________________________________________________________________________________________
        FUNCIONÁRIO: {NomeCliente.ToUpper()} {SobrenomeCliente.ToUpper()}       FUNÇÃO: {CargoFuncionario.ToUpper()}
        
        
        ____________________________________________________________________________________________________________
        SALÁRIO                                                                    {Salario.ToString("0.00")} R$              
               
        ____________________________________________________________________________________________________________
        ");
            Console.WriteLine("Pressione enter para seguir");
            Console.ReadKey();
        }
    }
}
