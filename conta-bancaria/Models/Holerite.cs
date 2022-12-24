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
            Console.WriteLine("\nPara criarmos uma conta salário, precisamos das informações do seu empregador.");
            Console.WriteLine("Digite o CNPJ da Empresa: ");
            string cnpjEmpresa = Console.ReadLine();
            Console.WriteLine("Digite a Razão Social: ");
            string nomeEmpresa = Console.ReadLine();
            Console.WriteLine("Digite o Endereço da Empresa: ");
            string endereçoEmpresa = Console.ReadLine();
            Console.WriteLine("Digite o seu Cargo/Função na empresa: ");
            string cargoFuncionario = Console.ReadLine();
            Console.WriteLine("Digite o seu salário Bruto! ");
            double salarioBruto = double.Parse(Console.ReadLine());
            double imposto = salarioBruto * 0.08;
            CnpjEmpresa = cnpjEmpresa;
            NomeEmpresa = nomeEmpresa;
            EndereçoEmpresa = endereçoEmpresa;
            CargoFuncionario = cargoFuncionario;
            SalarioBruto = salarioBruto;
            Imposto = imposto;
            SalarioLiquido = (salarioBruto - imposto);
            NomeCliente = cliente.Nome;
        }
        public string CnpjEmpresa { get; protected set; }
        private string NomeEmpresa { get; set; }
        private string EndereçoEmpresa { get; set; }
        private string CargoFuncionario { get; set; }
        private double SalarioBruto { get; set; }
        private double Imposto { get; set; }
        public double SalarioLiquido { get; set; }
        public string NomeCliente { get; set; }



        //Formatação do holerite:
        //o campo (Cliente.Nome) nao esta funcionando! temos que ver como faszer ! kkk 
        public void HoleriteCompleto()
        {
            Console.WriteLine(@$"
        EMPREGADOR                                                    RECIBO DE PAGAMENTO DE SALÁRIO
        {NomeEmpresa}                                              
        ENDEREÇO: {EndereçoEmpresa}
        CNPJ: {CnpjEmpresa}
        
        FUNCIONÁRIO: {NomeCliente}  FUNÇÃO: {CargoFuncionario}
        
        
        SALÁRIO BRUTO                                                              {SalarioBruto}R$
        IMPOSTOS                                                                        {Imposto}R$           
        
        
                                                                SALÁRIO LÍQUIDO: {SalarioLiquido}R$
        ");
        }
    }
}
