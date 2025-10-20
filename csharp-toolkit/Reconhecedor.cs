using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_toolkit
{
    internal class Reconhecedor
    {
        public Reconhecedor() { }
        public void Show()
        {
            // Loop para permitir múltiplos testes
            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.UTF8;

                // Solicita a cadeia ao usuário
                Console.WriteLine("=== Reconhecedor Σ={a,b} ===");
                Console.WriteLine("Escolha a linguagem:");
                Console.WriteLine("1 - L_par_a (número par de 'a')");
                Console.WriteLine("2 - L = { w | w = a b* }");
                Console.Write("Opção: ");
                int opcao = int.Parse(Console.ReadLine() ?? "1");

                Console.Write("Digite uma cadeia sobre Σ = {a,b}: ");
                string? cadeia = Console.ReadLine()?.Trim();

                // Verifica se a cadeia é válida no alfabeto Σ = {a, b}
                if (string.IsNullOrEmpty(cadeia) || !ValidarAlfabeto(cadeia))
                {
                    Console.WriteLine("REJEITA (cadeia inválida)");
                    return;
                }

                // Verifica se a cadeia pertence à linguagem escolhida
                bool aceita = opcao switch
                {
                    1 => L_par_a(cadeia),
                    2 => L_ab_star(cadeia),
                    _ => false
                };
                Console.WriteLine(aceita ? "ACEITA" : "REJEITA");

                // Função para validar o alfabeto Σ = {a, b}
                static bool ValidarAlfabeto(string cadeia)
                {
                    return cadeia.All(c => c == 'a' || c == 'b');
                }

                // Função para verificar se a cadeia tem número par de 'a'
                static bool L_par_a(string cadeia)
                {
                    int countA = cadeia.Count(c => c == 'a');
                    return countA % 2 == 0;
                }

                // Função para verificar se a cadeia é da forma a b*
                static bool L_ab_star(string cadeia)
                {
                    if (cadeia.Length == 0) return false;
                    if (cadeia[0] != 'a') return false;
                    for (int i = 1; i < cadeia.Length; i++)
                    {
                        if (cadeia[i] != 'b') return false;
                    }
                    return true;
                }

                // Pergunta se o usuário deseja testar outra cadeia
                Console.WriteLine("\nDeseja testar novamente? (S/N)");
                string? resposta = Console.ReadLine();
                if (resposta == null || resposta.Trim().ToUpper() != "S")
                {
                    Console.WriteLine("Voltando ao menu...");
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
