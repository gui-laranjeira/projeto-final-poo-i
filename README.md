# projeto-final-poo-i

## Exercício:

Somos uma consultoria que presta serviços para o maior Banco da América Latina.
Precisamos que vocês considerem o seguinte cenário:

Eu como Product Manager. Desejo que, seja criado uma aplicação para que nossos clientes bancários consigam criar suas contas através do celular.

Nossos DoD(definition of done) serão:
- Propiedades obrigatória: numeroConta, Saldo, tipoConta.
- Os dados do cliente, poderá ser avaliado pelo time.
- Deverá ser considerado três tipos de conta: Poupança, Salário e Investimento
    - Ao criar a conta poupança deverá solicitar um saldo míninmo
    - Ao criar a conta salário, deverá solicitar o holerite (simule um holerite)
    - Ao criar a conta investimento, deverá avaliar o perfil do investidor (simule um método que avalie o perfil do investidor)
    Dica: estamos solicitando essas validações ao criar, considere usar o construtor nesses cenários.

- Deverá ser possível visualizar o saldo da conta em todos os tipos de conta, mas somente um tipo de Conta poderá modificar o saldo.
    Dica: avalie o uso do protected.

- Implementar as seguintes funções:
    - Depositar, Sacar
    - InvestirEmAcoes
    - TransferenciaParaPoupanca
    - DepositarSalario (o depositar salário deverá solicitar o CNPJ pagador)
    - ExtratoBancario ( o extrato bancaria deverá contemplar as movimentacoes da conta, independente do tipoConta)

    Dica: avalie quais deverão ser método da classe pai e quais deverão ser método da classe filha.


- Implementar um método CalcularValorTarifaManutencao onde:
    - Para a contaCliente: taxa de 0.3
    - Para a contaInvestimento: taxa de 0.8
    - Para a contaPoupanca: taxa de 0.3,5
    - Para a contaSalario: taxa de 0.3

    Dica: utilize o polimorfismo para essas alterações.
