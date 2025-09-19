// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string[] linhas = File.ReadAllLines("C:\\Users\\pedro\\OneDrive\\Área de Trabalho\\POE\\Termo\\palavras.txt");

foreach (string linha in linhas)
{
    if(linha.Length == 5)
    {
        Console.WriteLine(linha);
    }
}

File.WriteAllText("C:\\Users\\pedro\\OneDrive\\Área de Trabalho\\POE\\Termo\\palavras_filtradas_CincoLetras.txt", String.Join("\n", linhas.Where(linha => linha.Length == 5)));