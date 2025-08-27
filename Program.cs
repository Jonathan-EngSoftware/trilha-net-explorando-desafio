// Arquivo: Program.cs

using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Bem-vindo ao Sistema de Reserva de Hotel! ");


List<Pessoa> hospedes = new List<Pessoa>();

Console.WriteLine("Quantos hóspedes serão cadastrados?");
int quantidadeHospedes;

while (!int.TryParse(Console.ReadLine(), out quantidadeHospedes) || quantidadeHospedes <= 0)
{
    Console.WriteLine("Valor inválido. Por favor, digite um número maior que zero.");
}

for (int i = 0; i < quantidadeHospedes; i++)
{
    Console.WriteLine($"Digite o nome completo do Hóspede nº {i + 1}:");
    string nome = Console.ReadLine();
    Pessoa novoHospede = new Pessoa(nome: nome);
    hospedes.Add(novoHospede);
}

Console.WriteLine("Hóspedes cadastrados com sucesso!");


// Método adicionado para o hóspede escolher os dias da reserva
Console.WriteLine("Por quantos dias você deseja fazer a reserva?");
int diasReservados;

// Validação para garantir que o usuário digite um número de dias válido
while (!int.TryParse(Console.ReadLine(), out diasReservados) || diasReservados <= 0)
{
    Console.WriteLine("Valor inválido. Por favor, digite um número de dias maior que zero.");
}

Console.WriteLine($"Reserva para {diasReservados} dias.");


Suite suite = new Suite(tipoSuite: "Premium", capacidade: 3, valorDiaria: 150);

// --- CRIAÇÃO DA RESERVA ---
if (suite.Capacidade < quantidadeHospedes)
{
    Console.WriteLine($"A suíte '{suite.TipoSuite}' tem capacidade para apenas {suite.Capacidade} pessoas, mas você tentou cadastrar {quantidadeHospedes}.");
    Console.WriteLine("A reserva não pôde ser concluída. Por favor, tente de novo.");
    return;
}

Reserva reserva = new Reserva(diasReservados: diasReservados);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);


Console.WriteLine("\n--- Informações Adicionais ---");

Console.WriteLine("Você trará algum animal de estimação? (sim ou não)");
string respostaAnimal = Console.ReadLine().ToLower();

if (respostaAnimal == "sim")
{
    reserva.TemAnimalDeEstimacao = true;
    Console.WriteLine("Ok! Será adicionada uma taxa única de R$ 50,00 pela hospedagem do seu pet.");
}
else
{
    reserva.TemAnimalDeEstimacao = false;
}

Console.WriteLine("\nHá alguma criança menor de 10 anos entre os hóspedes? (sim ou não)");
string respostaCrianca = Console.ReadLine().ToLower();

if (respostaCrianca == "sim")
{
    reserva.TemCriancaMenorDe10 = true;
    Console.WriteLine("Já está incluso uma cama infantil no pacote que escolheu!");
}
else
{
    reserva.TemCriancaMenorDe10 = false;
}


Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Suíte: {suite.TipoSuite}");
Console.WriteLine($"Dias Reservados: {reserva.DiasReservados}");
Console.WriteLine($"Valor Final: {reserva.CalcularValorDiaria():C}");