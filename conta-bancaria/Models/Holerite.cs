using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models
{
    public class Holerite
    {
        public Holerite()
        {
            Console.WriteLine("Nos informe os dados do seu Holerite para criação da sua conta salário! ");
            Console.WriteLine("Digite o CNPJ da Empresa: ");
            string cnpjEmpresa = Console.ReadLine();
            Console.WriteLine("Digite a Razão Social: ");
            string nomeEmpresa = Console.ReadLine();
            Console.WriteLine("Digite o Endereço da Empresa: ");
            string endereçoEmpresa = Console.ReadLine();
            Console.WriteLine("Digite o seu Cargo/Função na empresa: ");
            string cargoFuncionario = Console.ReadLine();
            Console.WriteLine("Digite o seu salário Bruto! ");
            decimal salarioBruto = decimal.Parse(Console.ReadLine());
            decimal imposto = salarioBruto * 0.08M;
            CnpjEmpresa = cnpjEmpresa;
            NomeEmpresa = nomeEmpresa;
            EndereçoEmpresa = endereçoEmpresa;
            CargoFuncionario = cargoFuncionario;
            SalarioBruto = salarioBruto;
            Imposto = imposto;
            SalarioLiquido = (salarioBruto - imposto);
        }
        private string CnpjEmpresa { get; set; }
        private string NomeEmpresa { get; set; }
        private string EndereçoEmpresa { get; set; }
        private string CargoFuncionario { get; set; }
        private decimal SalarioBruto { get; set; }
        private decimal Imposto { get; set; }
        public decimal SalarioLiquido { get; set; }



        //Formatação do holerite:
        //o campo (Cliente.Nome) nao esta funcionando! temos que ver como faszer ! kkk 
        public void HoleriteCompleto()
        {
            Console.WriteLine(@$"
        EMPREGADOR                                                    RECIBO DE PAGAMENTO DE SALÁRIO
        {NomeEmpresa}                                              
        ENDEREÇO: {EndereçoEmpresa}
        CNPJ: {CnpjEmpresa}
        
        FUNCIONÁRIO: (NomeCliente)  FUNÇÃO: {CargoFuncionario}
        
        
        SALÁRIO BRUTO                                                              {SalarioBruto}R$
        IMPOSTOS                                                                        {Imposto}R$           
        
        
                                                                SALÁRIO LÍQUIDO: {SalarioLiquido}R$
        ");
        }
    }
}
