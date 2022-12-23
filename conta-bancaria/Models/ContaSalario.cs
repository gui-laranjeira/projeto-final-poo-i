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
        private TipoConta contaSalario;

        private Holerite Holerite { get; set; }

        public ContaSalario(int numeroConta, Cliente cliente, Holerite holerite) : base(cliente)
        {
            this.Holerite = holerite;
            this.TipoDeConta = contaSalario;
        }

        
        public void Depositar(string cnpj)
        {
            if (Holerite.CnpjEmpresa == cnpj)
            {
                base.Depositar(Holerite.SalarioLiquido);
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
