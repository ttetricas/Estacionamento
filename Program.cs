//preços
const decimal precoPrimeiraHora = 20m;
const decimal precoHoraExtraPequeno = 10m;
const decimal precoHoraExtraGrande = 20m;
const decimal precoDiariaPequeno = 50m;
const decimal precoDiariaGrande = 80m;
const decimal precoLavagemPequeno = 50m;
const decimal precoLavagemGrande = 100m;
const decimal taxaValet = 0.20m;

//tempo
const int tempoMaximo = 12;
const int tempoParaDiaria = 5;
const int tolerancia = 5; 

Console.WriteLine("-- Bem-vindo ao estacionamento! --\n");

Console.Write("Por favor, informe o tamanho do veículo (P para pequeno, G para grande): ");
string tamanho = Console.ReadLine()!.ToUpper();

if (tamanho != "P" && tamanho != "G")
{
    Console.WriteLine("Tamanho inválido! Por favor, tente novamente.");
    return;
}

Console.Write("Informe o tempo de permanência (min): ");
int tempo = int.Parse(Console.ReadLine()!);

if (tempo <= 0 || tempo > tempoMaximo * 60)
{
    Console.WriteLine("Tempo inválido! Por favor, insira um valor válido.");
    return;
}

Console.Write("Utilizou serviço de valet? (S/N): ");
string valet = Console.ReadLine()!.ToUpper();

Console.Write("Deseja incluir lavagem? (S/N): ");
string lavagem = Console.ReadLine()!.ToUpper();

decimal valorEstacionamento = 0m;

if (tempo >= tempoParaDiaria * 60)
{
    if (tamanho == "P")
        valorEstacionamento = precoDiariaPequeno;
    else
        valorEstacionamento = precoDiariaGrande;
}
else
{
    int horas = tempo / 60;
    int minutosRestantes = tempo % 60;

    if (minutosRestantes > tolerancia)
        horas++;

    valorEstacionamento = precoPrimeiraHora;

    if (horas > 1)
    {
        int horasAdicionais = horas - 1;
        if (tamanho == "P")
            valorEstacionamento += horasAdicionais * precoHoraExtraPequeno;
        else
            valorEstacionamento += horasAdicionais * precoHoraExtraGrande;
    }
}

//valet
decimal valorValet = 0m;
if (valet == "S")
{
    valorValet = valorEstacionamento * taxaValet;
}

//lavagem
decimal valorLavagem = 0m;
if (lavagem == "S")
{
    if (tamanho == "P")
        valorLavagem = precoLavagemPequeno;
    else
        valorLavagem = precoLavagemGrande;
}

//total
decimal valorTotal = valorEstacionamento + valorValet + valorLavagem;

Console.WriteLine("\n--- RESUMO ---");
Console.WriteLine($"Valor do estacionamento: R$ {valorEstacionamento:F2}");
Console.WriteLine($"Valor do valet:          R$ {valorValet:F2}");
Console.WriteLine($"Valor da lavagem:        R$ {valorLavagem:F2}");
Console.WriteLine("------------------------------------");
Console.WriteLine($"Total a pagar:            R$ {valorTotal:F2}");