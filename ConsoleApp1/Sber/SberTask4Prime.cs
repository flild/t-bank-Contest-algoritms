using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Sber
{
    internal class SberTask4Prime : Itask
    {
        public string main(string input)
        {
            var inputList = input.Split(" ");
            int l = int.Parse(inputList[0]);
            int r = int.Parse(inputList[1]);

            int count = 0;

            for (int i = l; i <= r; i++)
            {
                //Добавим условие на составность числа
                if (IsPrimeNumber(i))
                {
                    continue;
                }
                // Определим количество делителей числа i
                int divisorsCount = CountDivisors(i);

                // Проверим, является ли это количество делителем простым числом
                if (IsPrimeNumber(divisorsCount))
                {
                    count++;
                }
            }

            return count.ToString();
        }

        private static int CountDivisors(int number)
        {
            int count = 0;
            for (int i = 1; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    count++;
                    if (i != number / i)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private static bool IsPrimeNumber(int number)
        {
            if (number <= 1)
            {
                return false;
            }
            if (number <= 3)
            {
                return true;
            }
            if (number % 2 == 0 || number % 3 == 0)
            {
                return false;
            }
            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
