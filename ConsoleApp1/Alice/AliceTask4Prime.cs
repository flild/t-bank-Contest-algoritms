using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Alice
{
    internal class AliceTask4Prime : Itask
    {
        public string main(string input)
        {
            var inputList = input.Split(' ');
            int l = int.Parse(inputList[0]);
            int r = int.Parse(inputList[0]);


            int count = 0;
            for (int i = l; i <= r; i++)
            {
                if (IsComposite(i) && IsPrime(GetDivisorsCount(i)))
                    count++;
            }

            return count.ToString();
        }

        static bool IsComposite(int num)
        {
            return num > 1 && num % 2 == 0
                || num % 2 != 0 && num % 3 == 0
                || num % 5 == 0
                || num % 7 == 0; // Проверка на составное число
        }

        static bool IsPrime(int divisorCount)
        {
            return divisorCount == 2; // Проверка, является ли количество делителей простым числом
        }

        static int GetDivisorsCount(int num)
        {
            int divisorCount = 0;
            for (int i = 1; i <= num / 2; i++)
            {
                if (num % i == 0)
                    divisorCount++;
            }
            return divisorCount + 1; // Учитываем само число
        }
    }
}
