using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conta_bancaria.Models;

public abstract class Conta
{   
    //enum para definir tipo de conta, é definido pela classe filha
    public TipoConta TipoDeConta { get; protected set; }
    public int NumeroConta { get; set; }
    protected double Saldo { get; set; }
    public Cliente Cliente { get; set; }


    public Conta(Cliente cliente)
    {
        NumeroConta = GerarNumeroConta();
        Cliente = cliente;
        Saldo = 0;
    }


    List<double> Movimentacoes = new ();

    //taxa base, na classe abstrata é zero mas cada classe filha (tipo de conta) tem sua própria taxa
    double taxaDeSaque = 0;


    //esse método tem q ser protected pra não ser possivel instanciar uma contaSalario sem inserir o CNPJ
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

    public enum TipoConta 
    {
        contaSalario,
        contaPoupança,
        contaInvestimento
    }

    public int GerarNumeroConta()
    {
        Random r1 = new Random();
        int numeroConta = r1.Next(100000, 999999);
        return numeroConta;
    }
}
