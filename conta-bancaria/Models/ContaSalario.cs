using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models
{
    internal class ContaSalario : Conta
    {
        double taxaDeSaque = 0.3;
        private Holerite Holerite { get; set; }

        public ContaSalario(int numeroConta, Cliente cliente, Holerite holerite) : base(numeroConta, cliente)
        {
            this.Holerite = holerite;
        }

        
        public void Depositar(double valor, string cnpj)
        {
            base.Depositar(valor);
            
        }

        public override double CalcularValorTarifaManutencao()
        {
                    
            double tarifa = this.taxaDeSaque * (Saldo / 100);
            return tarifa;
        }
    }
}
