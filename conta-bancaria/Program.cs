using conta_bancaria.Models;

internal class Program
{
     static void Main(string[] args)
     {
            Menu.MensagemBoasVindas();

            Cliente cliente = new Cliente();
            cliente.RegistrarCliente();
            int numeroConta;
            string tipoConta = TipoDeContaParaAbertura();

            string TipoDeContaParaAbertura()
            {
                int inputAberturaConta = Menu.MostrarTipoDeConta();
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
                            Console.WriteLine($"\nCliente: {cliente.Nome}  \t Número da Conta: {numeroConta}\n");
                            inputUsuario = Menu.MostrarOperacoes();
                            contaS.OperacoesSalario(inputUsuario);

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
                            Console.WriteLine($"\nCliente: {cliente.Nome}  \t Número da Conta: {numeroConta}\n");
                            inputUsuario = Menu.MostrarOperacoes(); 
                            contaP.OperacoesPoupanca(inputUsuario);

                        } while (inputUsuario != 9);
                        break;

                    case 3:
                        tipoConta = "contaInvestimento";

                        bool check;
                        double investimento;

                        ContaInvestimento contaI = new ContaInvestimento(cliente);

                        contaI.AvaliarPerfilInvestidor();
                        numeroConta = contaI.NumeroConta;
                        Console.Clear();

                        Console.WriteLine("Para finalizar sua conta, digite quanto você deseja investir: ");
                        check = double.TryParse(Console.ReadLine(), out investimento);
                        contaI.InvestirEmAcoes(investimento);

                        do
                        {
                            Console.WriteLine($"\nCliente: {cliente.Nome}  \t Número da Conta: {numeroConta}\n");
                            inputUsuario = Menu.MostrarOperacoes();
                            contaI.OperacoesInvestimento(inputUsuario);


                        } while (inputUsuario != 9);
                        break;
                }
                return tipoConta;
            } 
     }
}
