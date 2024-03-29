﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace conta_bancaria.Models
{
    public class Holerite 
    {
        public Holerite(Cliente cliente)
        {                                  
            NomeCliente = cliente.Nome;
            SobrenomeCliente = cliente.Sobrenome;
        }

        public string CnpjEmpresa { get; private set; }
        private string NomeEmpresa { get; set; }        
        private string EnderecoEmpresa { get; set; }
        private string CargoFuncionario { get; set; }
        public double Salario { get; protected set; }               
        public string NomeCliente { get; private set; }
        public string SobrenomeCliente { get; private set; }
       

        public void AbrirHolerite()
        {
            Console.WriteLine("Para criarmos uma conta salário, precisamos das informações do seu empregador.");

            do
            {
                Console.Write("Informe o CNPJ da empresa (apenas números): ");
                string cnpj = Console.ReadLine();
                if (long.TryParse(cnpj, out long teste))
                {
                    this.CnpjEmpresa = cnpj;
                }

            } while (String.IsNullOrEmpty(CnpjEmpresa));

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
                Console.WriteLine("\nInsira seu salário :");
                convertSalarioBruto = double.TryParse(Console.ReadLine(), out salarioBruto);
            } while (!convertSalarioBruto);
            if (salarioBruto < 0)
                this.Salario = - salarioBruto;
            else
                this.Salario = salarioBruto;
            this.NomeEmpresa = nomeEmpresa;
            this.EnderecoEmpresa = enderecoEmpresa;
            this.CargoFuncionario = cargoFuncionario;
           

        }


        public void HoleriteCompleto()
        {
            Console.Clear();
        Console.WriteLine(@$" 

        HOLERITE

        __________________________________________________________________________________________________
        EMPREGADOR                                                          RECIBO DE PAGAMENTO DE SALÁRIO
        {NomeEmpresa.ToUpper()}   

        ENDEREÇO: {EnderecoEmpresa.ToUpper()}           CNPJ: {CnpjEmpresa}
        
        __________________________________________________________________________________________________
        FUNCIONÁRIO: {NomeCliente.ToUpper()} {SobrenomeCliente.ToUpper()}       FUNÇÃO: {CargoFuncionario.ToUpper()}
        
        
        __________________________________________________________________________________________________
        SALÁRIO                                                                {Salario.ToString("0.00")} R$              
               
        __________________________________________________________________________________________________
        ");
            Console.WriteLine("\n\nPressione ENTER para seguir");
            Console.ReadKey();
        }
    }
}
