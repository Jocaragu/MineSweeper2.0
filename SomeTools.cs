using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public static class MyTools // tools for simplifying input
    {
        private static Random shuffle = new Random();
        public static int GetUserInt(string prompt)
        {
            Console.Write(prompt);
            return Convert.ToInt32(Console.ReadLine());
        }
        public static string? GetUserString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
        public static void FisherYates<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = shuffle.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
