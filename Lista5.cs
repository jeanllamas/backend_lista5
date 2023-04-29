using System;
using System.Security.Cryptography;

namespace backend_lista5
{
    class Lista5
    {
        static void Main(string[] args)
        {
            int ligado = 1; //"Liga" o programa
            do
            {
                Console.Clear();
                Console.WriteLine("Jean Augusto - Lista 5" + Environment.NewLine);

                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine($"{i} - Exercício {i}");
                }
                Console.WriteLine(Environment.NewLine + "Sair - Encerrar programa");
                Console.WriteLine(Environment.NewLine + "Selecione um número para acessar o exercício (Ex.: '4' para exercício 4):");

                var entrada = Console.ReadLine();

                switch (entrada) //Encerra quando o usuário escolher a opção de sair
                {
                    case "sair":
                    case "Sair":
                        ligado = 0; //"Desliga" o programa
                        continue;
                }

                bool checagem = int.TryParse(entrada, out int num_exercicio); /*Retorna verdadeiro se a conversão da entrada para inteiro der certo
                                                                                e move o número correspondente ao exercício para uma int */
                if (checagem)
                {
                    if (num_exercicio >= 1 && num_exercicio <= 5)
                    {
                        Console.Clear();
                        Exercicios(num_exercicio); //Encaminha para o exercício escolhido
                    }
                    else
                    {
                        Console.WriteLine(Environment.NewLine + $"Não há Exercício {num_exercicio}. Tente novamente.");
                    }
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + "Opção inválida. Tente novamente.");
                }

                //Mensagem para retornar ou encerrar
                Console.WriteLine(Environment.NewLine + "Voltar ao início? (S/N)");
                var voltar = Console.ReadLine();

                switch (voltar)
                {
                    case "S":
                    case "s":
                        continue; //Mantém o programa "ligado"
                    default:
                        ligado = 0; //"Desliga" o programa
                        continue;
                }

            } while (ligado == 1);
        }

        public static int[,] LerEntradasMatriz(int NumeroLinhas, int NumeroColunas)
        {
            int[,] entradas = new int[NumeroLinhas, NumeroColunas];

            for (int linha = 0; linha < NumeroLinhas; linha++)
            {
                for (int coluna = 0; coluna < NumeroColunas; coluna++)
                {
                    Console.Write($"[{linha},{coluna}]: ");
                    entradas[linha, coluna] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine();
            return entradas;
        }

        public static void ImprimirMatriz(int[,] matriz)
        {
            for (int linha = 0; linha < matriz.GetLength(0); linha++)
            {
                Console.WriteLine();
                Console.Write("| ");
                for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                {
                    Console.Write(matriz[linha, coluna] + " | ");
                }
            }
        }

        public static int[,] GerarMatriz(int NumeroLinhas, int NumeroColunas)
        {
            Random r = new Random();
            int[,] NumerosGerados = new int[NumeroLinhas, NumeroColunas];

            for (int linha = 0; linha < NumerosGerados.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < NumerosGerados.GetLength(1); coluna++)
                {
                    NumerosGerados[linha, coluna] = r.Next(0, 100);
                }
            }

            return NumerosGerados;
        }

        public static int[,] SomaMatrizes(int[][,] matrizes)
        {
            int maxLinhas = 0;
            int maxColunas = 0;
            foreach (int[,] matriz in matrizes)
            {
                maxLinhas = Math.Max(maxLinhas, matriz.GetLength(0));
                maxColunas = Math.Max(maxColunas, matriz.GetLength(1));
            }

            int[,] matrizResultado = new int[maxLinhas, maxColunas];

            foreach (int[,] matriz in matrizes)
            {
                for (int linha = 0; linha < matrizResultado.GetLength(0); linha++)
                {
                    for (int coluna = 0; coluna < matrizResultado.GetLength(1); coluna++)
                    {
                        if (linha < matriz.GetLength(0) && coluna < matriz.GetLength(1))
                        {
                            matrizResultado[linha, coluna] += matriz[linha, coluna];
                        }
                    }
                }
            }

            return matrizResultado;
        }

        static void Exercicios(int escolha)
        {
            switch (escolha)
            {
                case 1: //Exercício 1
                    {
                        Console.WriteLine("Quantas matrizes deseja somar?");
                        int qtd_matrizes = Convert.ToInt32(Console.ReadLine());

                        int[][,] matrizes = new int[qtd_matrizes][,];

                        for (int i = 0; i < qtd_matrizes; i++)
                        {
                            Console.WriteLine($"Quantidade de linhas e colunas da {i +1}ª matriz: (Obs: separe por um espaço)"); //Separada por espaço
                            string[] qtd_lc = Console.ReadLine().Split();
                            Console.WriteLine();

                            matrizes[i] = LerEntradasMatriz(Convert.ToInt32(qtd_lc[0]), Convert.ToInt32(qtd_lc[1]));

                        }

                        Console.WriteLine("Matrizes formadas:");
                        for (int i = 0; i < qtd_matrizes; i++)
                        {
                            Console.Write($"{i+1}ª Matriz");
                            ImprimirMatriz(matrizes[i]);
                            Console.WriteLine(Environment.NewLine);
                        }

                        Console.Write("Matrizes somadas:");
                        ImprimirMatriz(SomaMatrizes(matrizes));
                        Console.WriteLine(Environment.NewLine);
                        break;
                    }

                case 2: //Exercício 2
                    {
                        int[,] matriz1 = GerarMatriz(3, 3);
                        int[,] matriz2 = GerarMatriz(3, 3);
                        int[,] matrizM = new int[3,3];

                        for (int linha = 0; linha < 3; linha++)
                        {
                            for (int coluna = 0; coluna < 3; coluna++)
                            {
                                matrizM[linha, coluna] = matriz1[linha, coluna] * matriz2[linha, coluna];
                            }
                        }

                        Console.Write("Matriz 1");
                        ImprimirMatriz(matriz1);

                        Console.WriteLine(Environment.NewLine);
                        Console.Write("Matriz 2");
                        ImprimirMatriz(matriz2);

                        Console.WriteLine(Environment.NewLine);
                        Console.Write("Matriz multiplicada");
                        ImprimirMatriz(matrizM);

                        break;
                    }

                case 3: //Exercício 3
                    {
                        int[,] ordem3 = GerarMatriz(3, 3);

                        Console.Write("Matriz de Ordem 3");
                        ImprimirMatriz(ordem3);

                        for (int linha = 0; linha < 3 / 2; linha++)
                        {
                            int coluna = 2 - linha;
                            int temp = ordem3[linha, linha];
                            ordem3[linha, linha] = ordem3[coluna, coluna];
                            ordem3[coluna, coluna] = temp;
                        }

                        Console.WriteLine(Environment.NewLine);
                        Console.Write("Matriz com diagonal invertida:");

                        for (int linha = 0; linha < 3; linha++)
                        {
                            Console.WriteLine();
                            Console.Write("| ");
                            for (int coluna = 0; coluna < 3; coluna++)
                            {
                                Console.Write($"{ordem3[linha, coluna]} | ");
                            }
                        }
                        break;
                    }

                case 4: //Exercício 4
                    {
                        string[,] pares = new string[10, 10];

                        for (int par = 0; par < 10; par++)
                        {
                            Console.Write($"Digite o {par + 1}º par de i e j: ");
                            string[] entrada = Console.ReadLine().Split();

                            int i = Convert.ToInt32(entrada[0]) - 1;
                            int j = Convert.ToInt32(entrada[1]) - 1;

                            if (i >= 0 && i < 10 && j >= 0 && j < 10)
                            {
                                pares[i, j] = "X";
                                Console.WriteLine(" ");
                            }
                            else
                            {
                                Console.WriteLine("Apenas valores entre 1 a 10 são válidos." + Environment.NewLine);
                                par--;
                            }
                        }

                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                if (pares[i, j] != "X")
                                {
                                    int vizinhos = 0;
                                    if (j > 0 && pares[i, j - 1] == "X") vizinhos++; // Esquerda
                                    if (j < 9 && pares[i, j + 1] == "X") vizinhos++; // Direita
                                    if (i > 0 && pares[i - 1, j] == "X") vizinhos++; // Cima
                                    if (i < 9 && pares[i + 1, j] == "X") vizinhos++; // Baixo

                                    if (i > 0 && j > 0 && pares[i - 1, j - 1] == "X") vizinhos++; // Cima-esquerda
                                    if (i > 0 && j < 9 && pares[i - 1, j + 1] == "X") vizinhos++; // Cima-direita
                                    if (i < 9 && j > 0 && pares[i + 1, j - 1] == "X") vizinhos++; // Baixo-esquerda
                                    if (i < 9 && j < 9 && pares[i + 1, j + 1] == "X") vizinhos++; // Baixo-direita

                                    if (vizinhos > 0)
                                    {
                                        pares[i, j] = Convert.ToString(vizinhos);
                                    }
                                }
                            }
                        }

                        Console.Write("     ");
                        for (int coluna = 0; coluna < 10; coluna++)
                        {
                            Console.Write($"{coluna + 1,2} ");
                        }
                        Console.WriteLine();

                        for (int linha = 0; linha < 10; linha++)
                        {
                            Console.Write($"{linha + 1,2}   ");
                            for (int coluna = 0; coluna < 10; coluna++)
                            {
                                Console.Write($"{pares[linha, coluna],2} ");
                            }
                            Console.WriteLine();
                        }

                        break;
                    }

                case 5: //Exercício 5
                    {
                        char[,] matriz = new char[10, 10];

                        string[] linhas =
                        {
                            "Q F H Q P L P W S Y",
                            "A A N W A Z O Q A T",
                            "Z S U E S A S A C R",
                            "W A J R D X I L M E",
                            "S C M T F C U K N W",
                            "X V I C A S A J B C",
                            "E T K Y G V Y H V A",
                            "D G O U H B T G C S",
                            "C B L I J N R F X A",
                            "R Y P O K M E D Z Q"
                        };

                        for (int i = 0; i < 10; i++)
                        {
                            string[] letras = linhas[i].Split(' ');

                            for (int j = 0; j < 10; j++)
                            {
                                matriz[i, j] = letras[j][0];
                            }
                        }

                        for (int linha = 0; linha < 10; linha++)
                        {
                            for (int coluna = 0; coluna < 10; coluna++)
                            {
                                Console.Write(matriz[linha, coluna] + " ");
                            }
                            Console.WriteLine();
                        }

                        Console.Write("Digite uma palavra de busca com 5 caracteres (tamanho máximo 4): ");
                        string palavra = Console.ReadLine();

                        if (palavra.Length > 4)
                        {
                            Console.WriteLine("A palavra de busca deve ter tamanho máximo 4.");
                            return;
                        }

                        int ocorrencias = 0;

                        for (int linha = 0; linha < 10; linha++)
                        {
                            for (int coluna = 0; coluna < 6; coluna++) // limita a busca até a 6ª coluna
                            {
                                bool encontrou = true;
                                for (int i = 0; i < palavra.Length; i++)
                                {
                                    if (matriz[linha, coluna + i] != char.ToUpper(palavra[i]))
                                    {
                                        encontrou = false;
                                        break;
                                    }
                                }
                                if (encontrou)
                                {
                                    ocorrencias++;
                                }
                            }
                        }

                        Console.WriteLine($"Foram encontradas {ocorrencias} ocorrências da palavra de busca {palavra}.");

                        break;
                    }
            }
        }
    }
}