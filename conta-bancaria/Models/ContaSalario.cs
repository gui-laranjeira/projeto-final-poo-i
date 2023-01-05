using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models
{
    internal class ContaSalario : Conta
    {
        public double taxaDeSaque { get; } = 0.3;
        public TipoConta contaSalario { get; protected set; }
        public string CnpjEmpresa { get; protected set; }
        public Holerite Holerite { get; protected set; }

        public ContaSalario(Cliente cliente, Holerite holerite) : base(cliente)
        {
            this.Holerite = holerite;
            this.TipoDeConta = contaSalario;
            this.CnpjEmpresa = holerite.CnpjEmpresa;
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
    }
}
