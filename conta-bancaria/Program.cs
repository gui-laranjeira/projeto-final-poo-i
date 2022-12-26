using conta_bancaria.Models;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

Console.WriteLine("*************************************************");
Console.WriteLine("*                                               *");
Console.WriteLine("*  Bem vindo ao sistema do Banco SinqiaSêniors!  *");
Console.WriteLine("*                                               *");
Console.WriteLine("*************************************************\n");

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

Console.WriteLine("\nInforme sua data de nascimento:");
string dataDeNascimento = Console.ReadLine();

Cliente cliente = new Cliente(nome, sobrenome, idade, cpf, dataDeNascimento);

Console.Clear();
Console.WriteLine("Pré-Cadastro realizado com sucesso!");
Console.WriteLine($"\nBem vindo(a) {cliente.Nome} {cliente.Sobrenome}");


//Variáveis para abertura de conta salário
string cnpj = "";
string nomeEmpresa = "";
string enderecoEmpresa = "";
string cargoFuncionario = "";
double salarioBruto = 0;




bool convertAberturaConta;
//ABERTURA DE CONTA
do
{
    Console.WriteLine("\n\nQual tipo de conta deseja abrir?\n");
    Console.WriteLine("(1) - Abrir Conta Salário");
    Console.WriteLine("(2) - Abrir Conta Poupança");
    Console.WriteLine("(3) - Abrir Conta Investimento");
    bool convertInputUsuarioAberturaConta = int.TryParse(Console.ReadLine(), out int inputAberturaDeConta);


    convertAberturaConta = convertInputUsuarioAberturaConta && (inputAberturaDeConta == 1 || inputAberturaDeConta == 3 || inputAberturaDeConta == 2);


    

    switch (inputAberturaDeConta)
    {
        case 1:
            Console.WriteLine("Para criarmos uma conta salário, precisamos das informações do seu empregador.");
            Console.WriteLine("Insira o CNPJ da empresa:");
            cnpj = Console.ReadLine();

            Console.WriteLine("\nInsira a Razão Social da empresa:");
            nomeEmpresa = Console.ReadLine();

            Console.WriteLine("\nInsira o endereço da empresa:");
            enderecoEmpresa = Console.ReadLine();

            Console.WriteLine("\nQual seu cargo na empresa:");
            cargoFuncionario = Console.ReadLine();                      

            bool convertSalarioBruto;
            do
            {
                Console.WriteLine("\nInsira seu salário bruto:");
                convertSalarioBruto = double.TryParse(Console.ReadLine(), out salarioBruto);
            } while (!convertSalarioBruto);     
                        
            break;

         case 2:
             //TODO sylmara implementa a criação da conta poupança
             ContaPoupanca contaP = new ContaPoupanca(cliente);
             break;

        case 3:
            //TODO jezz implementa a criação da conta investimento

            break;
        
    }
    Console.Clear();
} while (!convertAberturaConta);

Holerite holerite = new Holerite(cliente, cnpj, nomeEmpresa, enderecoEmpresa, cargoFuncionario, salarioBruto);
ContaSalario conta = new ContaSalario(cliente, holerite);



//TODO FALTA FAZER OS METODOS FUNCIONAREM, MAS PRECISA CRIAR AS CLASSES ANTES
//roda o programa, só fecha qunado aperta ESC
ConsoleKeyInfo key;
do
{
    Console.WriteLine("\n\nQual operação quer realizar\n");
    Console.WriteLine("ESC - Finalizar o programa");
    Console.WriteLine("(1) - Depositar");
    Console.WriteLine("(2) - Sacar");
    Console.WriteLine("(3) - Emitir extrato");
    Console.WriteLine("(4) - Exibir dados do cliente");
    key = Console.ReadKey();

    //se inserir 1
    if (key.Key == ConsoleKey.D1)
    {
        Console.Clear();
        if (conta.TipoDeConta == TipoConta.contaSalario)
        {
            conta.Depositar(holerite.CnpjEmpresa);
            Console.WriteLine($"{holerite.SalarioLiquido}R$ depositado com sucesso!");
        }
        else
        {
            Console.WriteLine("\nInsira o valor que quer depositar:");
            double.TryParse(Console.ReadLine(), out double valorDeposito);
            //alguem implementa aquiconta.Depositar()
            Console.WriteLine($"{valorDeposito}R$ depositado com sucesso!");
        }    
        
    }
    //se inserir 2
    else if (key.Key == ConsoleKey.D2)
    {
        Console.Clear();
        Console.WriteLine("\nInsira o valor que quer sacar:");
        double.TryParse(Console.ReadLine(), out double valorSaque);
        conta.Sacar(valorSaque);
        Console.WriteLine($"{valorSaque} sacado com sucesso!");
    }
    //se inserir 3
    else if (key.Key == ConsoleKey.D3)
    {
        Console.Clear();
        Console.WriteLine("\nEmitir extrato>:");
        conta.Extrato();
        Console.ReadLine();
    }
    //se inserir 4
    else if (key.Key == ConsoleKey.D4)
    {
        Console.Clear();
        Console.WriteLine();
        cliente.ExibirDados();
        
    }
    
}
while (key.Key != ConsoleKey.Escape);

