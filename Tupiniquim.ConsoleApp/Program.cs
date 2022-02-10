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
            string comandos;
            string[] posicaoMax, posicaoInicial;
            int posicaoAtualX, posicaoAtualY, posicaoMaxX, posicaoMaxY;
            char sentido;
            #endregion

            #region Definir entradas
            Console.WriteLine("Digite a área máxima X e Y: ");
            posicaoMax = Console.ReadLine().Split(' '); // Recebe e divide os dois, por 'posicaoMax' ser stringArr
            posicaoMaxX = Convert.ToInt32(posicaoMax[0]); // Adiciona o 1º ao X
            posicaoMaxY = Convert.ToInt32(posicaoMax[1]); // Adiciona o 2º ao Y
            Console.WriteLine("Max X: " + posicaoMaxX + " Max Y: " + posicaoMaxY);
            #endregion

            #region Definir posição inicial
            Console.WriteLine("Digite a posição inicial do Robô [Padrão: Nº Nº N/S/L/O]:");
            posicaoInicial = Console.ReadLine().Split(' '); // Recebe e divide os três, 'posicaoInicial' é Arr | X Número Y Número Sentido
            posicaoAtualX = Convert.ToInt32(posicaoInicial[0]);  // 1
            posicaoAtualY = Convert.ToInt32(posicaoInicial[1]);  // 3
            sentido = Convert.ToChar(posicaoInicial[2].ToUpper()); // S     ~~~~~~~~~~~~ ToUpper ~~~~~~~~~~~~
            #endregion

            #region Definir os comandos de direção
            Console.WriteLine("Agora, informe em uma única string, os comandos \n['D' -> Direita, 'E' -> Esquerda, 'M' -> Avança +1 casa para frente no sentido onde se encontra]");
            comandos = Console.ReadLine().ToUpper(); // Recebe e armazena os comandos 'MEEMDM' por exemplo     ~~~~~~~~~~~~~ ToUpper ~~~~~~~~~~~~
            char[] comandosChar = new char[comandos.Length]; // Cria um char Arr com o tamanho de "comandos" (MEEMDM)
            for (int i = 0; i < comandos.Length; i++)
            {
                comandosChar[i] = comandos[i]; // Atribui a 'i' letra da string à 'i' posição do char Arr - Tenho um vetor de char para verificar
                Console.WriteLine(comandosChar[i]);
            }
            #endregion

            #region Processamento dos comandos de direção
            for (int i = 0; i < comandosChar.Length; i++)
            {
                if(comandosChar[i] == 'E') // E / D / M
                {
                    if (sentido == 'N') // Se estiver para o norte
                    {
                        sentido = 'O'; // E virar para a esquerda, estará no sentido oeste
                    } else if (sentido == 'O') // Se estiver para o oeste
                    {
                        sentido = 'S'; // E virar para a esquerda, estará no sentido sul
                    } else if (sentido == 'S') // Se estiver para o sul
                    {
                        sentido = 'L'; // E virar para a esquerda, estará no sentido leste
                    } else if (sentido == 'L') // Se estiver para o sul
                    {
                        sentido = 'N'; // E virar para a esquerda, estará no sentido norte
                    }
                } // Fecha if ESQUERDA



                if(comandosChar[i] == 'D')
                {
                    if(sentido == 'N') // Se estiver para o norte
                    {
                        sentido = 'L'; // E virar para a direita, estará no sentido leste
                    } else if(sentido == 'L') // Se estiver para o leste
                    {
                        sentido = 'S'; // E virar para a direita, estará no sentido sul
                    } else if(sentido == 'S') // Se estiver para o sul
                    {
                        sentido = 'O'; // E virar para a direita, estará no sentido oeste
                    } else if(sentido == 'O') // Se estiver para o oeste
                    {
                        sentido = 'N'; // E virar para a direita, estará no sentido norte
                    }
                } // Fecha if DIREITA




                if(comandosChar[i] == 'M')
                {
                    if(sentido == 'N') // Se estiver olhando pro norte (cima)
                    {
                        posicaoAtualY++; // Avance y+1
                    } else if(sentido == 'S') // Se estiver olhando pro sul (baixo)
                    {
                        posicaoAtualY--; // Avance y-1
                    } else if(sentido == 'O') // Se estiver olhando pro oeste (esquerda)
                    {
                        posicaoAtualX--; // Avance x-1
                    } else if(sentido == 'L') // Se estiver olhando pro leste (direita)
                    {
                        posicaoAtualX++; // Avance x+1
                    }
                } // Fecha if MOVER
            } // Fecha for verificador de direções
            Console.WriteLine("Localização atual do robô: \nEixo X: " + posicaoAtualX + "\nEixo Y: " + posicaoAtualY + "\nSentido: " + sentido);
            #endregion
        }
    }
}