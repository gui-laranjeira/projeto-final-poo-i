using conta_bancaria.Models;


Console.WriteLine("*************************************************");
Console.WriteLine("*                                               *");
Console.WriteLine("*  Bem vindo ao sistema do Banco SinqiaSêniors!  *");
Console.WriteLine("*                                               *");
Console.WriteLine("*************************************************\n");

Cliente cliente = RegistrarCliente();

string tipoConta = TipoDeContaParaAbertura();

if(tipoConta == "contaSalario")
{
    ContaSalario contaS = AbrirContaSalario();
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
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("\nInsira o valor que quer sacar:");
                double.TryParse(Console.ReadLine(), out double valorSaque);
                contaS.Sacar(valorSaque);
                Console.WriteLine($"\n{valorSaque}R$ sacado com sucesso!");
                break;
            case 3:
                Console.Clear();
                
                contaS.Extrato();
                Console.WriteLine("\nPressione qualquer tecla para continuar!");
                Console.ReadLine();
                break;
            case 4:
                Console.Clear();
                Console.WriteLine();
                cliente.ExibirDados();
                break;
        }
    } while (inputUsuario != 9);
}
//IMPLEMENTAR AS FUNÇÕES PRA CONTA POUPANÇA -- SYLMARA
else if (tipoConta == "contaPoupanca")
{
    ContaPoupanca contaP = new ContaPoupanca(cliente);
    Console.Clear();
    Console.WriteLine("Conta Poupança aberta com sucesso!");




}
//IMPLEMENTAR AS FUNÇÕES PRA CONTA INVESTIMENTO -- JEZZ
else if (tipoConta == "contaInvestimento")
{
    ContaInvestimento contaI = new ContaInvestimento(cliente);
    Console.Clear();
    Console.WriteLine("Conta Investimento aberta com sucesso!");



}




//MÉTODOS
//MÉTODO DE REGISTRAR O CLIENTE, RETORNA UM CLIENTE
Cliente RegistrarCliente()
{
    //CRIAÇÃO DE CONTA
    Console.WriteLine("CRIAÇÃO DO CADASTRO\n");

    Console.WriteLine("Insira seu nome:");
    string nome = Console.ReadLine();

    Console.WriteLine("\nInsira seu sobrenome:");
    string sobrenome = Console.ReadLine();

    Console.WriteLine("\nInforme sua idade:");
    int.TryParse(Console.ReadLine(), out int idade);

    Console.WriteLine("\nInforme seu CPF: ");
    string cpf = Console.ReadLine();

    //Console.WriteLine("\nInforme sua data de nascimento:");
    //string dataDeNascimento = Console.ReadLine();

    Cliente cliente = new Cliente(nome, sobrenome, idade, cpf);

    Console.Clear();
    Console.WriteLine("Pré-Cadastro realizado com sucesso!");
    Console.WriteLine($"\nBem vindo(a) {cliente.Nome} {cliente.Sobrenome}");
    return cliente;
}


//MÉTODO DE ABRIR CONTA SALÁRIO, COMO É UMA CLASSE Q TEM PARTICULARIDADE NA ABERTURA, TIVE Q FAZER UM MÉTODO PRÓPRIO
ContaSalario AbrirContaSalario()
{
    Console.WriteLine("Para criarmos uma conta salário, precisamos das informações do seu empregador.");
    Console.WriteLine("Insira o CNPJ da empresa:");
    string cnpj = Console.ReadLine();

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
        Console.WriteLine("\nInsira seu salário bruto:");
        convertSalarioBruto = double.TryParse(Console.ReadLine(), out salarioBruto);
    } while (!convertSalarioBruto);

    Holerite holerite = new Holerite(cliente, cnpj, nomeEmpresa, enderecoEmpresa, cargoFuncionario, salarioBruto);
    ContaSalario contaS = new ContaSalario(cliente, holerite);
    return contaS;
}


//MÉTODO DE RECEBER QUAL OPERAÇÃO O USUARIO QUER FAZER, RETORNA UM INT Q CORRESPONDE À UMA FUNÇÃO
int MenuDeOperacoes()
{
    bool convert;
    do
    {
        Console.WriteLine("\n\nQual operação quer realizar\n");

        Console.WriteLine("(1) - Depositar");
        Console.WriteLine("(2) - Sacar");
        Console.WriteLine("(3) - Emitir extrato");
        Console.WriteLine("(4) - Exibir dados do cliente");
        Console.WriteLine("(9) - Finalizar o programa");
        convert = int.TryParse(Console.ReadLine(), out int inputUsuario);
        return inputUsuario;
    } while (!convert);  
}


//MÉTODO PARA RECEBER QUAL O TIPO DE CONTA O USUÁRIO QUER ABRIR, RETORNA A STRING COM O TIPO
string TipoDeContaParaAbertura()
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
    string tipoConta = "";
    switch (inputAberturaConta)
    {
        case 1:
            tipoConta = "contaSalario";
            break;
        case 2:
            tipoConta = "contaPoupanca";
            break;
        case 3:
            tipoConta = "contaInvestimento";
            break;
    }
    return tipoConta;
}

