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
            
            
            CnpjEmpresa = cnpjEmpresa;
            NomeEmpresa = nomeEmpresa;
            EndereçoEmpresa = endereçoEmpresa;
            CargoFuncionario = cargoFuncionario;
            Salario = salarioB;                    
            NomeCliente = cliente.Nome;
            SobrenomeCliente = cliente.Sobrenome;
        }

        public string CnpjEmpresa { get; protected set; }
        private string NomeEmpresa { get; set; }        
        private string EndereçoEmpresa { get; set; }
        private string CargoFuncionario { get; set; }
        public double Salario { get; protected set; }       
        
        public string NomeCliente { get; set; }
        public string SobrenomeCliente { get; set; }
       

        public void HoleriteCompleto()
        {
        Console.WriteLine(@$"
        EMPREGADOR                                                    RECIBO DE PAGAMENTO DE SALÁRIO
        {NomeEmpresa}                                              
        ENDEREÇO: {EndereçoEmpresa}
        CNPJ: {CnpjEmpresa}
        
        FUNCIONÁRIO: {NomeCliente} {SobrenomeCliente}  FUNÇÃO: {CargoFuncionario}
        
        
        SALÁRIO                                                                         {Salario}R$              
               
             
        ");
        }
    }
}
