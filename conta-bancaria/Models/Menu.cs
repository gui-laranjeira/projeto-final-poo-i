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
    public static int MostrarTipoDeConta()
    {
        bool convert;
        int inputAberturaConta;

        do
        {
            Console.WriteLine("\n\nQual tipo de conta deseja abrir?\n");
            Console.WriteLine("(1) - Abrir Conta Salário");
            Console.WriteLine("(2) - Abrir Conta Poupança");
            Console.WriteLine("(3) - Abrir Conta Investimento");
            convert = int.TryParse(Console.ReadLine(), out inputAberturaConta);

        } while (!convert && (inputAberturaConta >= 1 || inputAberturaConta <= 3));
        return inputAberturaConta;
    }
    public static int MostrarOperacoes()
    {
        bool convert;
        int inputUsuario;
        do
        {
            Console.Clear();
            Console.WriteLine("\nQual operação quer realizar?\n");
            Console.WriteLine("(1) - Depositar/Transferência:");
            Console.WriteLine("(2) - Sacar");
            Console.WriteLine("(3) - Emitir extrato");
            Console.WriteLine("(4) - Exibir dados do cliente");
            Console.WriteLine("(9) - Finalizar o programa");
            convert = int.TryParse(Console.ReadLine(), out inputUsuario);
        } while (!convert);
        return inputUsuario;

    }
}
