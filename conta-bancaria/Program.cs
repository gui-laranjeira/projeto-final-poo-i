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
            string cnpj = Console.ReadLine();

            Console.WriteLine("\nInsira a Razão Social da empresa:");
            string nomeEmpresa = Console.ReadLine();

            Console.WriteLine("\nInsira o endereço da empresa:");
            string enderecoEmpresa = Console.ReadLine();

            Console.WriteLine("\nQual seu cargo na empresa:");
            string cargoFuncionario = Console.ReadLine();

            double salarioBruto;

            bool convertSalarioBruto;
            do
            {
                Console.WriteLine("\nInsira seu salário bruto:");
                convertSalarioBruto = double.TryParse(Console.ReadLine(), out salarioBruto);
            } while (!convertSalarioBruto);

            Holerite holerite = new Holerite(cliente,cnpj,nomeEmpresa,enderecoEmpresa,cargoFuncionario,salarioBruto);
            ContaSalario contaS = new ContaSalario(cliente, holerite);
            
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

//conta tem que ser aberta fora do do while, por isso armazenar as variaveis antes e abrir aqui
//ContaSalario conta = new ContaSalario(cliente, holerite);



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
        Console.WriteLine("\nInsira o valor que quer depositar:");
        double.TryParse(Console.ReadLine(), out double valorDeposito);
        

    }
    //se inserir 2
    else if (key.Key == ConsoleKey.D2)
    {
        Console.WriteLine("\nInsira o valor que quer sacar:");
        double.TryParse(Console.ReadLine(), out double valorSaque);
       

    }
    //se inserir 3
    else if (key.Key == ConsoleKey.D3)
    {
        Console.WriteLine("\nEmitir extrato>:");
        Console.ReadLine();
    }
    //se inserir 4
    else if (key.Key == ConsoleKey.D4)
    {
        Console.WriteLine();
        cliente.ExibirDados();
        
    }
    Console.Clear();
}
while (key.Key != ConsoleKey.Escape);









//Console.WriteLine("Qual operação deseja realizar?\n");
//Console.WriteLine("(1) - Abrir Conta Salário");
//Console.WriteLine("(2) - Abrir Conta Poupança");
//Console.WriteLine("(3) - Abrir Conta Investimento");
//Console.WriteLine("(4) - Sair");
//Console.WriteLine("(5) - Entender o que o gui quis dizer com Rabdkmicamebte");


//PRIMEIRO REGISTRAR O USUARIO (CRIAR Cliente)
//Perguntar o tipo de conta que quer criar
//Gerar a conta específica
//Se for contaSalario, pedir os dados do empregador para gerar o holerite

