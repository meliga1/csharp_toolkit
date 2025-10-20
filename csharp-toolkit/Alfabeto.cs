using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_toolkit
{
    internal class Alfabeto
    {
        public Alfabeto() { }
        public void Show()
        {
            // Loop para permitir múltiplos testes
            while (true)
            {
                // Solicita a cadeia de caracteres ao usuário
                Console.WriteLine("Digite uma cadeia de caracteres composta apenas por 'a' e 'b':");
                string? cadeia = Console.ReadLine();

                // Verifica se a cadeia é válida no alfabeto Σ = {a, b}
                if (!string.IsNullOrEmpty(cadeia) && cadeia.All(c => c == 'a' || c == 'b'))
                {
                    Console.WriteLine($"A cadeia '{cadeia}' é válida no alfabeto Σ = {{a, b}}.");
                }
                else
                {
                    Console.WriteLine($"A cadeia '{cadeia}' contém caracteres inválidos para o alfabeto Σ = {{a, b}}.");
                }

                // Pergunta se o usuário deseja testar outra cadeia
                Console.WriteLine("\nDeseja testar outra cadeia? (S/N)");
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
