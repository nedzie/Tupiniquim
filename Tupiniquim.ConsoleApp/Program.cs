/*
 * COMANDO E -> ESQUERDA (90°)
 * COMANDO D -> DIREITA (90°)
 * COMANDO M -> AVANÇA PARA FRENTE, NA DIREÇÃO QUE ESTÁ OLHANDO
 * NORTE ^ 
 * SUL _ 
 * LESTE <
 * OESTE >
 */


using System;

namespace Tupiniquim.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variáveis
            string comandos = "", comandosDois = "";
            string[] posicaoMax, posicaoInicial, posicaoInicialDois;
            int posicaoAtualX = 0, posicaoAtualY = 0, posicaoMaxX, posicaoMaxY; // Robo Um
            int posicaoAtualXDois = 0, posicaoAtualYDois = 0; // Robo Dois
            char sentido = 'w', sentidoDois = 'w';
            bool segundoRobo = false;
            #endregion

            #region Definir area

            Console.WriteLine("Digite a área máxima X e Y: ");
            posicaoMax = Console.ReadLine().Split(' '); // Recebe e divide os dois, por 'posicaoMax' ser stringArr
            posicaoMaxX = Convert.ToInt32(posicaoMax[0]); // Adiciona o 1º ao X
            posicaoMaxY = Convert.ToInt32(posicaoMax[1]); // Adiciona o 2º ao Y

        #endregion

        inicio:
            if (segundoRobo == false)
            {
                #region Definir posição inicial RoboUm
                Console.WriteLine("Digite a posição inicial do Robô 1 [Padrão: Nº Nº N/S/L/O]:");
                posicaoInicial = Console.ReadLine().Split(' '); // Recebe e divide os três, 'posicaoInicial' é Arr | X Número Y Número Sentido
                posicaoAtualX = Convert.ToInt32(posicaoInicial[0]);  // 1
                posicaoAtualY = Convert.ToInt32(posicaoInicial[1]);  // 3
                sentido = Convert.ToChar(posicaoInicial[2].ToUpper()); // S

                #endregion
            }
            else
            {
                Console.WriteLine("Digite a posição inicial do Robô 2 [Padrão: Nº Nº N/S/L/O]:");
                posicaoInicialDois = Console.ReadLine().Split(' '); // Recebe e divide os três, 'posicaoInicial' é Arr | X Número Y Número Sentido
                posicaoAtualXDois = Convert.ToInt32(posicaoInicialDois[0]);  // 1
                posicaoAtualYDois = Convert.ToInt32(posicaoInicialDois[1]);  // 3
                sentidoDois = Convert.ToChar(posicaoInicialDois[2].ToUpper()); // S
            }
            #region Definir os comandos de direção
            // Robô 1
            if (segundoRobo == false)
            {
                Console.WriteLine("Agora, informe em uma única string, os comandos \n['D' -> Direita, 'E' -> Esquerda, 'M' -> Avança +1 casa para frente no sentido onde se encontra]");
                comandos = Console.ReadLine().ToUpper(); // Recebe e armazena os comandos 'MEEMDM' por exemplo
            }
            else
            {
                Console.WriteLine("Agora, informe em uma única string, os comandos \n['D' -> Direita, 'E' -> Esquerda, 'M' -> Avança +1 casa para frente no sentido onde se encontra]");
                comandosDois = Console.ReadLine().ToUpper(); // Recebe e armazena os comandos 'MEEMDM' por exemplo
            }
            char[] comandosCharDois = comandosDois.ToCharArray(); // Cria um char Arr com o tamanho de "comandos" (MEEMDM)

            char[] comandosChar = comandos.ToCharArray(); // Cria um char Arr com o tamanho de "comandos" (MEEMDM)

            //for (int i = 0; i < comandos.Length; i++)
            //{
            //    comandosChar[i] = comandos[i]; // Atribui a 'i' letra da string à 'i' posição do char Arr
            //}


            #endregion

            #region Processamento dos comandos de direção

            // Robô 1
            if(segundoRobo == false) { 
            for (int i = 0; i < comandosChar.Length; i++)
            {

                    if (comandosChar[i] == 'E') // E / D / M
                    {
                        if (sentido == 'N') // Se estiver para o norte
                        {
                            sentido = 'O'; // E virar para a esquerda, estará no sentido oeste
                        }
                        else if (sentido == 'O') // Se estiver para o oeste
                        {
                            sentido = 'S'; // E virar para a esquerda, estará no sentido sul
                        }
                        else if (sentido == 'S') // Se estiver para o sul
                        {
                            sentido = 'L'; // E virar para a esquerda, estará no sentido leste
                        }
                        else if (sentido == 'L') // Se estiver para o sul
                        {
                            sentido = 'N'; // E virar para a esquerda, estará no sentido norte
                        }
                    } // Fecha if ESQUERDA



                    if (comandosChar[i] == 'D')
                    {
                        if (sentido == 'N') // Se estiver para o norte
                        {
                            sentido = 'L'; // E virar para a direita, estará no sentido leste
                        }
                        else if (sentido == 'L') // Se estiver para o leste
                        {
                            sentido = 'S'; // E virar para a direita, estará no sentido sul
                        }
                        else if (sentido == 'S') // Se estiver para o sul
                        {
                            sentido = 'O'; // E virar para a direita, estará no sentido oeste
                        }
                        else if (sentido == 'O') // Se estiver para o oeste
                        {
                            sentido = 'N'; // E virar para a direita, estará no sentido norte
                        }
                    } // Fecha if DIREITA




                    if (comandosChar[i] == 'M')
                    {
                        if (sentido == 'N') // Se estiver olhando pro norte (cima)
                        {
                            posicaoAtualY++; // Avance y+1
                        }
                        else if (sentido == 'S') // Se estiver olhando pro sul (baixo)
                        {
                            posicaoAtualY--; // Avance y-1
                        }
                        else if (sentido == 'O') // Se estiver olhando pro oeste (esquerda)
                        {
                            posicaoAtualX--; // Avance x-1
                        }
                        else if (sentido == 'L') // Se estiver olhando pro leste (direita)
                        {
                            posicaoAtualX++; // Avance x+1
                        }
                    } // Fecha if MOVER

                } // Fecha for verificador de direções do Robô 1
            } else
            {
                for (int i = 0; i < comandosCharDois.Length; i++)
                {

                    if (comandosCharDois[i] == 'E') // E / D / M
                    {
                        if (sentidoDois == 'N') // Se estiver para o norte
                        {
                            sentidoDois = 'O'; // E virar para a esquerda, estará no sentido oeste
                        }
                        else if (sentidoDois == 'O') // Se estiver para o oeste
                        {
                            sentidoDois = 'S'; // E virar para a esquerda, estará no sentido sul
                        }
                        else if (sentidoDois == 'S') // Se estiver para o sul
                        {
                            sentidoDois = 'L'; // E virar para a esquerda, estará no sentido leste
                        }
                        else if (sentidoDois == 'L') // Se estiver para o sul
                        {
                            sentidoDois = 'N'; // E virar para a esquerda, estará no sentido norte
                        }
                    } // Fecha if ESQUERDA



                    if (comandosCharDois[i] == 'D')
                    {
                        if (sentidoDois == 'N') // Se estiver para o norte
                        {
                            sentidoDois = 'L'; // E virar para a direita, estará no sentido leste
                        }
                        else if (sentidoDois == 'L') // Se estiver para o leste
                        {
                            sentidoDois = 'S'; // E virar para a direita, estará no sentido sul
                        }
                        else if (sentidoDois == 'S') // Se estiver para o sul
                        {
                            sentidoDois = 'O'; // E virar para a direita, estará no sentido oeste
                        }
                        else if (sentidoDois == 'O') // Se estiver para o oeste
                        {
                            sentidoDois = 'N'; // E virar para a direita, estará no sentido norte
                        }
                    } // Fecha if DIREITA




                    if (comandosCharDois[i] == 'M')
                    {
                        if (sentidoDois == 'N') // Se estiver olhando pro norte (cima)
                        {
                            posicaoAtualYDois++; // Avance y+1
                        }
                        else if (sentidoDois == 'S') // Se estiver olhando pro sul (baixo)
                        {
                            posicaoAtualYDois--; // Avance y-1
                        }
                        else if (sentidoDois == 'O') // Se estiver olhando pro oeste (esquerda)
                        {
                            posicaoAtualXDois--; // Avance x-1
                        }
                        else if (sentidoDois == 'L') // Se estiver olhando pro leste (direita)
                        {
                            posicaoAtualXDois++; // Avance x+1
                        }
                    } // Fecha if MOVER

                } // Fecha for verificador de direções do Robô 2
            }

            if (segundoRobo == false)
            {
                Console.WriteLine("Localização atual do robô 1: \nEixo X: " + posicaoAtualX + "\nEixo Y: " + posicaoAtualY + "\nSentido: " + sentido);
                Console.ReadKey();
                segundoRobo = true;
                goto inicio;
            }
            Console.WriteLine("Localização atual do robô 2: \nEixo X: " + posicaoAtualXDois + "\nEixo Y: " + posicaoAtualYDois + "\nSentido: " + sentidoDois);
            Console.ReadKey();
                #endregion
        }
    }
}