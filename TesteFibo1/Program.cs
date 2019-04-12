using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteFibo1
{
    class Program
    {
        static Dictionary<int, long> DictionaryPossiblePasswords = new Dictionary<int, long>();

        static void Main(string[] args)
        {
            FillDictionaryFastAcess();
            Console.WriteLine("Os únicos números com 16 dígitos na sequencia fibonacci são :");
            foreach (var item in DictionaryPossiblePasswords)
                Console.WriteLine("[{0}]-[{1}]", item.Key, item.Value);

            Console.WriteLine("Caso você queira usar outro indice que não esteja na lista , ignore-a.");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("{0} Senha = Posicao Fibonacci que vc procura :",i + 1 + "ª");
                int position = Convert.ToInt32(Console.ReadLine());
                
                //Checa se existe no dicionário de acesso rápido, caso não exista vai buscar no método de buscar pelo Index,
                if (DictionaryPossiblePasswords.ContainsKey(position))
                    Console.WriteLine("Senha : {0}", DictionaryPossiblePasswords[position]);
                else
                    Console.WriteLine("Senha : {0}", FindFibonacciNumberByIndex(position));
            }

            Console.WriteLine("Mission accomplished.");
            Console.ReadKey();

        }

        //Existem apenas 5 números de 16 dígitos na sequencia Fibonacci, o dictionary irá conter todos para um acesso mais rápido, p/ diminuir o tempo de processamento. 
        private static void FillDictionaryFastAcess()
        {
            long a = 0, b = 1, c = 0;
            bool exit = false;
            int contador = 0;

            while (!exit)
            {
                c = a + b;

                a = b;
                b = c;
                contador++;

                if (c.ToString().Length == 16)
                    DictionaryPossiblePasswords.Add(contador + 2, c);

                if (c.ToString().Length > 16)
                    exit = true;
            }
        }

        //Acha o nº Fibonacci pelo Index.
        public static long FindFibonacciNumberByIndex(long n)
        {
            long number = n - 1;
            long[] FibonacciSequence = new long[n];
            FibonacciSequence[0] = 0;
            FibonacciSequence[1] = 1;
            for (int i = 2; i <= number; i++)
            {
                FibonacciSequence[i] = FibonacciSequence[i - 2] + FibonacciSequence[i - 1];
            }
            return FibonacciSequence[number];
        }

    }
}
