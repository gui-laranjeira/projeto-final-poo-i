using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models
{
    public class ContaInvestimento : Conta
    {
        public double taxaManutencao = 0.08;

        public ContaInvestimento(int numeroConta, Cliente cliente) : base(numeroConta, cliente)
        {
        }

       
    }
}
