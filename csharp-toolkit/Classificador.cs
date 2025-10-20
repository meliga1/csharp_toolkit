using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace csharp_toolkit
{
    internal class Classificador
    {
        public Classificador() { }
        // Classe para representar um problema
        public class Problema
        {
            public string Descricao { get; set; } = "";
            public string Classificacao { get; set; } = "";
        }
        public void Show()
        {
            // Loop para permitir múltiplos testes
            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.UTF8;

                // JSON embutido
                string json = @"
                [
                    { ""Descricao"": ""Problema do caixeiro viajante"", ""Classificacao"": ""I"" },
                    { ""Descricao"": ""Verificar se um número é primo"", ""Classificacao"": ""T"" },
                    { ""Descricao"": ""Problema da parada de Turing"", ""Classificacao"": ""N"" }
                ]";
                var problemas = JsonSerializer.Deserialize<List<Problema>>(json);

                // Verifica se a desserialização foi bem-sucedida
                if (problemas == null)
                {
                    Console.WriteLine("Erro ao carregar problemas.");
                    return;
                }

                int acertos = 0;
                int erros = 0;

                Console.WriteLine("=== Classificador T/I/N ===");
                Console.WriteLine("Digite T para Tratável, I para Intratável ou N para Não computável.\n");

                // Itera sobre os problemas e solicita a classificação ao usuário
                foreach (var p in problemas)
                {
                    Console.WriteLine($"Problema: {p.Descricao}");
                    Console.Write("Sua resposta (T/I/N): ");
                    string? resposta = Console.ReadLine()?.Trim().ToUpper();

                    if (resposta == null || (resposta != "T" && resposta != "I" && resposta != "N"))
                    {
                        Console.WriteLine("Resposta inválida! Contando como erro.\n");
                        erros++;
                        continue;
                    }

                    if (resposta == p.Classificacao)
                    {
                        Console.WriteLine("Correto!\n");
                        acertos++;
                    }
                    else
                    {
                        Console.WriteLine($"Errado. Resposta correta: {p.Classificacao}\n");
                        erros++;
                    }
                }

                // Exibe o resumo final
                Console.WriteLine("=== Resumo Final ===");
                Console.WriteLine($"Acertos: {acertos}");
                Console.WriteLine($"Erros: {erros}");
                double percentual = (double)acertos / problemas.Count * 100;
                Console.WriteLine($"Percentual de acertos: {percentual:F2}%");

                // Pergunta se o usuário deseja testar outra vez
                Console.WriteLine("\nDeseja testar novamente? (S/N)");
                string? respostaLoop = Console.ReadLine();
                if (respostaLoop == null || respostaLoop.Trim().ToUpper() != "S")
                {
                    Console.WriteLine("Voltando ao menu...");
                    break;
                }
                Console.WriteLine();

            }
        }
    }
}
