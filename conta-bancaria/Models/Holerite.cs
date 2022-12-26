using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models
{
    public class Holerite
    {
        public Holerite(Cliente cliente, string cnpjEmpresa, string nomeEmpresa, string endereçoEmpresa, string cargoFuncionario, double salarioB)
        {
            
            double imposto = salarioB * 0.08;
            CnpjEmpresa = cnpjEmpresa;
            NomeEmpresa = nomeEmpresa;
            EndereçoEmpresa = endereçoEmpresa;
            CargoFuncionario = cargoFuncionario;
            SalarioBruto = salarioB;
            Imposto = imposto;
            SalarioLiquido = (salarioB - imposto);
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
