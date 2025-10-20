using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_toolkit
{
    internal class Avaliador
    {
        public Avaliador() { }
        public void Show()
        {
            // Loop para permitir múltiplos testes
            while (true) {
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.UTF8;

                // Solicita a fórmula ao usuário
                Console.WriteLine("=== Avaliador Proposicional Básico ===");
                Console.WriteLine("Escolha a fórmula:");
                Console.WriteLine("1 - (P ∧ Q) ∨ R - Conjunção/Disjunção");
                Console.WriteLine("2 - (P → Q) ∧ R - Implicação");
                Console.Write("Opção: ");
                int opcao = int.Parse(Console.ReadLine() ?? "1");

                Console.Write("Digite valor de P (true/false): ");
                bool P = bool.Parse(Console.ReadLine() ?? "false");

                Console.Write("Digite valor de Q (true/false): ");
                bool Q = bool.Parse(Console.ReadLine() ?? "false");

                Console.Write("Digite valor de R (true/false): ");
                bool R = bool.Parse(Console.ReadLine() ?? "false");

                bool resultado = false;

                // Avalia a fórmula escolhida
                switch (opcao)
                {
                    case 1:
                        resultado = (P && Q) || R;
                        Console.WriteLine($"Resultado: {(resultado ? "True" : "False")}");
                        break;

                    case 2:
                        resultado = ((!P || Q) && R);
                        Console.WriteLine($"Resultado: {(resultado ? "True" : "False")}");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        return;
                }

                // Pergunta se o usuário deseja imprimir a tabela-verdade
                Console.Write("\nDeseja imprimir a tabela-verdade da fórmula escolhida? (s/n): ");
                string? resposta = Console.ReadLine()?.ToLower();
                // Imprime a tabela-verdade se o usuário desejar
                if (resposta == "s")
                {
                    ImprimirTabela(opcao);
                }

                // Pergunta se o usuário deseja testar outra fórmula
                Console.WriteLine("\nDeseja testar novamente? (S/N)");
                string? respostaLoop = Console.ReadLine();
                if (respostaLoop == null || respostaLoop.Trim().ToUpper() != "S")
                {
                    Console.WriteLine("Voltando ao menu...");
                    break;
                }
                Console.WriteLine();
                }

            // Função para imprimir a tabela-verdade
            static void ImprimirTabela(int opcao)
            {
                    Console.WriteLine("\n=== Tabela-Verdade ===");
                    Console.WriteLine(" P\t Q\t R\t Resultado");

                for (int p = 0; p <= 1; p++)
                {
                    for (int q = 0; q <= 1; q++)
                    {
                        for (int r = 0; r <= 1; r++)
                        {
                            bool P = (p == 1);
                            bool Q = (q == 1);
                            bool R = (r == 1);
                            bool resultado = opcao switch
                            {
                                1 => (P && Q) || R,
                                2 => ((!P || Q) && R),
                                _ => false
                            };
                            Console.WriteLine($"{P}\t {Q}\t {R}\t {resultado}");
                        }
                    }
                }
            }
        }
    }
}
