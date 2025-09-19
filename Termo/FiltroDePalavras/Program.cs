// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Globalization;

Console.WriteLine("Hello, World!");

string[] linhas = File.ReadAllLines("C:\\Users\\pedro\\OneDrive\\Área de Trabalho\\POE\\Termo\\lexico.txt");

// Cria uma lista para armazenar apenas as palavras filtradas
List<string> palavrasFiltradas = new List<string>();

foreach (string linha in linhas)
{
    // Apenas adiciona a palavra se tiver 5 letras e não contiver acentos
    if (linha.Length == 5 && !ContemAcentos(linha))
    {
        palavrasFiltradas.Add(linha);
        Console.WriteLine(linha);
    }
}

// Salva as palavras filtradas em um novo arquivo, todas em maiúsculas
File.WriteAllText("C:\\Users\\pedro\\OneDrive\\Área de Trabalho\\POE\\Termo\\palavras_5_letras_sem_acentos.txt", String.Join("\n", palavrasFiltradas.Select(p => p.ToUpper())));

Console.WriteLine("Filtragem concluída. O arquivo 'palavras_5_letras_sem_acentos.txt' foi criado.");

// --- Função auxiliar para verificar acentos ---
bool ContemAcentos(string texto)
{
    // Normaliza a string para a forma de decomposição D
    string textoNormalizado = texto.Normalize(NormalizationForm.FormD);

    foreach (char caractere in textoNormalizado)
    {
        // Verifica se o caractere é um diacrítico (acento)
        if (CharUnicodeInfo.GetUnicodeCategory(caractere) == UnicodeCategory.NonSpacingMark)
        {
            return true; // Encontrou um acento
        }
    }

    return false; // Não encontrou nenhum acento
}