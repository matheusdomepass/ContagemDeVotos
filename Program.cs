using System;
using System.Collections.Generic;
using System.IO;

namespace ContagemDeVotos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o caminho do arquivo: ");
            string caminhoArquivo = Console.ReadLine();

            try
            {
                using (StreamReader arquivo = File.OpenText(caminhoArquivo))
                {
                    Dictionary<string, int> votos = new Dictionary<string, int>();

                    while (!arquivo.EndOfStream)
                    {
                        string[] linha = arquivo.ReadLine().Split(',');
                        string nome = linha[0];
                        int numeroVotos = int.Parse(linha[1]);

                        if (votos.ContainsKey(nome)){

                            votos[nome] += numeroVotos;
                        }
                        else
                        {
                            votos[nome] = numeroVotos;
                        }                        
                    }
                    foreach (var item in votos)
                    {
                        Console.WriteLine(item.Key + ": " + item.Value);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Erro ocorrido!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
            
