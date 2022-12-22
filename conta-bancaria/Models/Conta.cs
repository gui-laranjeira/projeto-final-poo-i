using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models;

internal abstract class Conta
{
    public Conta(int numeroConta, Cliente cliente)
    {
        NumeroConta = numeroConta;
        Cliente = cliente;
        Saldo = 0;
    }

    public int NumeroConta { get; set; }
    protected double Saldo { get; set; }
    public Cliente Cliente { get; set; }

    List<double> Movimentacoes = new ();

    public void Depositar(double valor)
    {
        Movimentacoes.Add(valor);
        Saldo += valor;
        Console.WriteLine($"Dinheiro em conta: {Saldo}"); 
    }

    public void Sacar(double valor)
    {
        valor *= (-1);
        Movimentacoes.Add(valor);
        Saldo += valor;
        Console.WriteLine($"Dinheiro em conta: {Saldo}"); 
    }

    public void Extrato()
    {
        Console.WriteLine("Extrato: \n");
        foreach(var item in Movimentacoes)
        {
            Console.WriteLine(item + "R$");
        }
        Console.WriteLine($"\nSaldo total: {Saldo}R$");
    }

    public virtual double CalcularValorTarifaManutencao()
    {
        double taxa = 1;
        double tarifa = taxa * (Saldo / 100);
        return tarifa;
    }
}
