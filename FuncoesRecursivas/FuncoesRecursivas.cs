using System;
using System.Collections.Generic;

namespace FuncoesRecursivas
{
    public class FuncoesRecursivas
    {
        static void Main(string[] args)
        {
            var lista = new List<int> { 1, 2, 3, 4, 5, 6 };

            Console.WriteLine("========================================================================");
            Console.WriteLine("========================== INVERTENDO LISTA ============================\n");

            var listaInvertida = InverteVetor(lista, 0);

            Console.Write("LISTA ORIGINAL.....: ");
            foreach (var i in lista)
                Console.Write(i + " ");

            Console.WriteLine();

            Console.Write("LISTA INVERTIDA....: ");
            foreach (var i in listaInvertida)
                Console.Write(i + " ");

            Console.WriteLine("\n\n\n");

            Console.WriteLine("========================================================================");
            Console.WriteLine("=================== CALCULANDO MEDIA DE VALORES ========================\n");

            Console.Write("LISTA INSERIDA....................: ");
            foreach (var i in listaInvertida)
                Console.Write(i + " ");

            Console.WriteLine();

            CalculaMedia(lista, 0, 0);

            Console.ReadLine();
        }

        /// <summary>
        /// Calcula e média dos valores de uma lista e informa quantos elementos são maiores do que a média
        /// </summary>
        /// <param name="itens"></param>
        /// <param name="media"></param>
        /// <param name="index"></param>
        public static (float, int) CalculaMedia(List<int> itens, float somatorio, int index)
        {
            somatorio += itens[index];

            if (index == (itens.Count - 1))
            {
                var media = somatorio / itens.Count;
                int qtdValores = itens[index] > media ? 1 : 0;
                return (media, qtdValores);
            }
            else
            {
                (var media, var qtdValores) = CalculaMedia(itens, somatorio, index + 1);
                qtdValores += itens[index] > media ? 1 : 0;

                if (index == 0)
                {
                    Console.WriteLine("QTD DE ITENS MAIORES QUE A MÉDIA..: " + qtdValores);
                    Console.WriteLine("MÉDIA.............................: " + media);
                }

                return (media, qtdValores);
            }
        }

        /// <summary>
        /// Inverte a ordem dos elementos de uma lista 
        /// </summary>
        /// <param name="itens"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static List<int> InverteVetor(List<int> itens, int index)
        {
            if (index == (itens.Count - 1))
            {
                var lista = new List<int> { itens[index] };
                return lista;
            }
            else
            {
                var lista = InverteVetor(itens, index + 1);
                lista.Add(itens[index]);
                return lista;
            }
        }
    }
}
