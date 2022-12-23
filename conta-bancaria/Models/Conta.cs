using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models;

public abstract class Conta
{
    //construtor
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

    double taxaDeSaque = 0;


    //esse método tem q ser protected pra não ser possivel instanciar uma contaSalario sem inserir o CNPJ,
    //ai é só criar um novo construtor na classe filha, mas público, e chamar o base.Depositar();
    protected virtual void Depositar(double valor)
    {
        Movimentacoes.Add(valor);
        Saldo += valor;
        Console.WriteLine($"Dinheiro em conta: {Saldo}"); 
    }

    public virtual void Sacar(double valor)
    {
        valor *= (-1);
        Movimentacoes.Add(valor);
        if (Saldo >= valor)
        {
            double taxa = CalcularValorTarifaManutencao();
            Saldo += valor;
            Saldo -= taxa;
            Console.WriteLine($"Dinheiro em conta: {Saldo}");
        }
        else
        {
            Console.WriteLine("Não há saldo suficiente em conta!");
        }
        
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
        double tarifa = taxaDeSaque * (Saldo / 100);
        return tarifa;
    }
}
