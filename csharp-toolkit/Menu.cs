using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_toolkit
{
    internal class Menu
    {
        public Menu() { }
        public void Show()
        {
            Alfabeto alfabeto = new Alfabeto();
            Classificador classificador = new Classificador();
            Decisor decisor = new Decisor();
            Avaliador avaliador = new Avaliador();
            Reconhecedor reconhecedor = new Reconhecedor();

            while (true)
            {
                Console.WriteLine("Projeto Toolkit - UNIFESO");
                Console.WriteLine("---- AV1 ----");
                Console.WriteLine("1) Verificar alfabeto e cadeia (Σ = {a,b})");
                Console.WriteLine("2) Classificador T/I/N por JSON");
                Console.WriteLine("3) Decisor: termina com 'b'?");
                Console.WriteLine("4) Avaliador proposicional (P,Q,R)");
                Console.WriteLine("5) Reconhecedor: L_par_a e a b*");
                //Console.WriteLine("---- AV2 ----");
                //Console.WriteLine("6) Problema x instância por JSON");
                //Console.WriteLine("7) Decisores: L_fim_b e L_mult3_b");
                //Console.WriteLine("8) Reconhecedor que pode não terminar (a^i b^i)");
                //Console.WriteLine("9) Detector ingênuo de loop");
                //Console.WriteLine("10) Simulador AFD simples (termina com 'b')");
                Console.WriteLine("0) Sair");

                int opcaoEscolhida = LerOpcaoDoMenu(0, 10);
                Console.WriteLine();

                if (opcaoEscolhida == 0) return;
                if (opcaoEscolhida == 1) alfabeto.Show();
                if (opcaoEscolhida == 2) classificador.Show();
                if (opcaoEscolhida == 3) decisor.Show();
                if (opcaoEscolhida == 4) avaliador.Show();
                if (opcaoEscolhida == 5) reconhecedor.Show();
                //if (opcaoEscolhida == 6) ModuloAv2Item1();
                //if (opcaoEscolhida == 7) ModuloAv2Item2();
                //if (opcaoEscolhida == 8) ModuloAv2Item3();
                //if (opcaoEscolhida == 9) ModuloAv2Item4();
                //if (opcaoEscolhida == 10) ModuloAv2Item5();

                Console.WriteLine();
            }

        }

        //Tratamento de erro na leitura da opção do menu
        private static int LerOpcaoDoMenu(int valorMinimo, int valorMaximo)
        {
            while (true)
            {
                Console.Write("Opção: ");
                string? textoDigitado = Console.ReadLine();

                if (int.TryParse(textoDigitado, out int valorLido))
                {
                    if (valorLido >= valorMinimo && valorLido <= valorMaximo)
                    {
                        return valorLido;
                    }
                }

                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
    }
}

