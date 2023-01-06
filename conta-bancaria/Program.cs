using conta_bancaria.Models;

internal class Program
{
    static void Main(string[] args)
    {
        Menu.MensagemBoasVindas();

        Cliente cliente = new Cliente();
        cliente.RegistrarCliente();
        int numeroConta;

        string inputTipoConta = Menu.TipoDeConta();
        switch (inputTipoConta)
        {
            case "Conta Salário":

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
                    Console.Clear();
                    inputUsuario = Menu.MostrarOperacoes(cliente.Nome, inputTipoConta, numeroConta, "Receber salário", "Sacar");
                    contaS.OperacoesSalario(inputUsuario);

                } while (inputUsuario != 9);

                break;

            case "Conta Poupança":

                ContaPoupanca contaP = new ContaPoupanca(cliente);
                numeroConta = contaP.NumeroConta;
                contaP.AbrirContaPoupanca();
                Console.Clear();

                Console.WriteLine("Conta Poupança aberta com sucesso!\n");

                do
                {
                    inputUsuario = Menu.MostrarOperacoes(cliente.Nome, inputTipoConta, numeroConta, "Transferir para poupança", "Sacar");
                    contaP.OperacoesPoupanca(inputUsuario);

                } while (inputUsuario != 9);
                break;

            case "Conta Investimento":

                bool check;
                double investimento;

                ContaInvestimento contaI = new ContaInvestimento(cliente);

                contaI.AvaliarPerfilInvestidor();
                numeroConta = contaI.NumeroConta;
                Console.Clear();
                do
                {
                    Console.WriteLine("Para finalizar, digite quanto você deseja investir em conta : ");
                    check = double.TryParse(Console.ReadLine(), out investimento);
                } while (!check);
                contaI.InvestirEmAcoes(investimento);
                do
                {
                    
                    inputUsuario = Menu.MostrarOperacoes(cliente.Nome, inputTipoConta, numeroConta, "Investir na conta" , "Investir em ações");
                    contaI.OperacoesInvestimento(inputUsuario);


                } while (inputUsuario != 9);
                break;
        }
    }
}
