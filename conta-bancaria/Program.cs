using conta_bancaria.Models;

Console.WriteLine("*************************************************");
Console.WriteLine("*                                               *");
Console.WriteLine("*     Bem vindo ao sistema do Banco Sinqia!     *");
Console.WriteLine("*                                               *");
Console.WriteLine("*************************************************\n");


Cliente cliente = new Cliente();
cliente.RegistrarCliente();
int numeroConta;
string tipoConta = TipoDeContaParaAbertura();


string TipoDeContaParaAbertura()
{
    bool convert;
    int inputAberturaConta;

    do{
        Console.WriteLine("\n\nQual tipo de conta deseja abrir?\n");
        Console.WriteLine("(1) - Abrir Conta Salário");
        Console.WriteLine("(2) - Abrir Conta Poupança");
        Console.WriteLine("(3) - Abrir Conta Investimento");
        convert = int.TryParse(Console.ReadLine(), out inputAberturaConta);

    } while (!convert && (inputAberturaConta >= 1 || inputAberturaConta <= 3));  
    
    string tipoConta = "";

    switch (inputAberturaConta)
    {
        case 1:
            tipoConta = "contaSalario";           
            Holerite holerite = new Holerite(cliente);
            holerite.AbrirHolerite();
            holerite.HoleriteCompleto();

            ContaSalario contaS = new ContaSalario(cliente, holerite);
            numeroConta = contaS.NumeroConta;

            Console.Clear();

            Console.WriteLine("Conta Salário aberta com sucesso!");
            int inputUsuario;
            do
            {
                inputUsuario = MenuDeOperacoes();
                switch (inputUsuario)
                {
                    case 1:
                        Console.Clear();
                        contaS.Depositar(contaS.CnpjEmpresa);
                        Console.WriteLine($"{contaS.Holerite.Salario}R$ depositado com sucesso!");
                        Console.WriteLine("\nPressione ENTER para continuar!");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\nInsira o valor que quer sacar:");
                        double.TryParse(Console.ReadLine(), out double valorSaque);
                        contaS.Sacar(valorSaque);
                        Console.WriteLine("\nPressione ENTER para continuar!");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        contaS.Extrato();
                        Console.WriteLine("\nPressione ENTER para continuar!");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine();
                        cliente.VisualizarDados();
                        Console.WriteLine("\nPressione ENTER para continuar!");
                        Console.ReadKey();
                        break;
                }
            } while (inputUsuario != 9);

            break;

        case 2:
            tipoConta = "contaPoupanca";

            ContaPoupanca contaP = new ContaPoupanca(cliente);
            numeroConta = contaP.NumeroConta;
            contaP.AbrirContaPoupanca();
            Console.Clear();

            Console.WriteLine("Conta Poupança aberta com sucesso!\n");

            do
            {
                inputUsuario = MenuDeOperacoes();
                switch (inputUsuario)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Digite o valor que deseja transferir:");
                        double valorTransf = double.Parse(Console.ReadLine());
                        contaP.TransferirParaPoupanca(valorTransf);
                        Console.WriteLine("\nPressione ENTER para continuar!");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Digite o valor que deseja sacar: ");
                        double valorSaq = double.Parse(Console.ReadLine());
                        contaP.Sacar(valorSaq);
                        Console.WriteLine("\nPressione ENTER para continuar!");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        contaP.Extrato();
                        Console.WriteLine("\nPressione ENTER para continuar!");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        cliente.VisualizarDados();
                        Console.WriteLine("\nPressione ENTER para continuar!");
                        Console.ReadKey();
                        break;     
                }
            }while (inputUsuario != 9);
            break;

        case 3:
            tipoConta = "contaInvestimento";

            bool check;
            decimal investimento;

            ContaInvestimento contaI = new ContaInvestimento(cliente);

            contaI.AvaliarPerfilInvestidor();
            numeroConta = contaI.NumeroConta;
            Console.Clear();

            Console.WriteLine("Para finalizar sua conta, digite quanto você deseja investir: ");
            check = decimal.TryParse(Console.ReadLine(), out investimento);
            contaI.InvestirEmAcoes(investimento);

            MenuDeOperacoes();
            break;
    }
    return tipoConta;
}
int MenuDeOperacoes()
{
    bool convert;
    do
    {
        Console.WriteLine($"\nCliente: {cliente.Nome} - \t Número da Conta: {numeroConta}\n");
        Console.WriteLine("\nQual operação quer realizar?\n");
        Console.WriteLine("(1) - Depositar/Transferência:");
        Console.WriteLine("(2) - Sacar");
        Console.WriteLine("(3) - Emitir extrato");
        Console.WriteLine("(4) - Exibir dados do cliente");
        Console.WriteLine("(9) - Finalizar o programa");
        convert = int.TryParse(Console.ReadLine(), out int inputUsuario);
        return inputUsuario;
    } while (!convert);
}
