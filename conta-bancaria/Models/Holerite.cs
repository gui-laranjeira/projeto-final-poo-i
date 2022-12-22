using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models
{
    internal class Holerite
    {
        public Holerite(string nomeEmpresa, int cnpjEmpresa, string endereçoEmpresa, string cargoEmpresa)
        {
            Console.WriteLine("Nos informe o Holerite para criação da sua conta salário! ");
            Console.WriteLine("Digite o CNPJ da Empresa: ");
            cnpjEmpresa = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Razão Social: ");
            nomeEmpresa = Console.ReadLine();
            Console.WriteLine("Digite o Endereço da Empresa: ");
            endereçoEmpresa = Console.ReadLine();
            Console.WriteLine("Digite o seu Cargo/Função na empresa: ");
            cargoEmpresa = Console.ReadLine();
        }
        //Formatação do holerite:
        //string holeriteCompleto = @$"
        //EMPREGADOR                                                    RECIBO DE PAGAMENTO DE SALÁRIO
        //{nomeEmpresa}                                              
        //ENDEREÇO: {endereçoEmpresa}
        //CNPJ: {cnpjEmpresa}
        //
        //FUNCIONÁRIO: {nomeFuncionario}  FUNÇÃO: {cargoEmpresa}
        //
        //
        //SALÁRIO BASE                                                                             R$
        //IMPOSTOS                                                                                 R$
        //
        //
        //                                                              SALÁRIO LÍQUIDO:           R$
        //";
    }
}
