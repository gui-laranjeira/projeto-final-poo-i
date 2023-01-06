using conta_bancaria.Models;
using System;

internal class Menu
{
    public static void MensagemBoasVindas()
    {
        Console.WriteLine("*************************************************");
        Console.WriteLine("*                                               *");
        Console.WriteLine("*     Bem vindo ao sistema do Banco Sinqia!     *");
        Console.WriteLine("*                                               *");
        Console.WriteLine("*************************************************\n");
    }
    public static string TipoDeConta()
    {
        bool convert;
        int inputAberturaConta;
        string tipoConta = "";

        do
        {
            Console.WriteLine("\n\nQual tipo de conta deseja abrir?\n");
            Console.WriteLine("(1) - Abrir Conta Salário");
            Console.WriteLine("(2) - Abrir Conta Poupança");
            Console.WriteLine("(3) - Abrir Conta Investimento");
            convert = int.TryParse(Console.ReadLine(), out inputAberturaConta);

        } while (!convert && (inputAberturaConta >= 1 || inputAberturaConta <= 3));
        
        switch(inputAberturaConta)
        {
            case 1:
                tipoConta = "Conta Salário";
                break;
            case 2:
                tipoConta = "Conta Poupança";
                break;
            case 3:
                tipoConta = "Conta Investimento";
                break;
        }             
        return tipoConta;
    }
    public static int MostrarOperacoes(string nome, string tipo, int numero, string depositar, string sacar)
    {
        bool convert;
        int inputUsuario;
        do
        {
            Console.Clear();
            Console.WriteLine($"\nCLIENTE: {nome.ToUpper()}\t TIPO DE CONTA: {tipo.ToUpper()}\t NÚMERO DE CONTA: {numero}\n");
            Console.WriteLine("\nQual operação quer realizar?\n");
            Console.WriteLine("(1) - " + depositar);
            Console.WriteLine("(2) - " + sacar);
            Console.WriteLine("(3) - Emitir extrato");
            Console.WriteLine("(4) - Exibir dados do cliente");
            Console.WriteLine("(9) - Finalizar o programa");
            convert = int.TryParse(Console.ReadLine(), out inputUsuario);
        } while (!convert);
        return inputUsuario;

    }
}
