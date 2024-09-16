using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    public class Task4PrimeList
    {
        public void main()
        {
            var input = Console.ReadLine().Split(" ");
            var minNum = long.Parse(input[0]);
            var maxNum = long.Parse(input[1]);
            int resultCount = 0;
            for(long i = minNum; i <= maxNum; i++) 
            {
                if(IsComposite(i))
                {
                    List<long> divisiorsNum = GetDivisiors(i);
                    if (IsPrime(divisiorsNum.Count))
                    {
                        resultCount++;
                    }
                }
            }
            Console.WriteLine(resultCount);
        }
        public bool IsComposite(long num)
        {
            return !IsPrime(num);
        }
        public bool IsPrime(long num)
        {
            if (num <= 3) return true;
            if (num%2 == 0) return false;
            if (num % 3 == 0) return false;
            for (int i = 2; i < (int)Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
        public List<long> GetDivisiors(long number)
        {
            List<long> divisiors = new List<long>(128);
            List<long> primeDevisiors = new List<long>(128);
            long curNum = number;
            bool isPrime = false;
            while (!isPrime)
            {
                isPrime = true;
                for (int i = 2; i <= Math.Sqrt(curNum); i += 1)
                {
                    if (curNum % i == 0)
                    {
                        primeDevisiors.Add(i);
                        isPrime = false;
                        curNum /= i;
                        break;
                    }
                }
            }

            primeDevisiors.Add(curNum);

            for (int i = 0; i < primeDevisiors.Count; i++)
            {
                var divLen = divisiors.Count;
                for (int j = 0; j < divLen; j++)
                {
                    if (!divisiors.Contains(divisiors[j] * primeDevisiors[i]))
                    {
                        divisiors.Add(divisiors[j] * primeDevisiors[i]);
                    }
                }

                if (!divisiors.Contains(primeDevisiors[i]))
                {
                    divisiors.Add(primeDevisiors[i]);
                }
            }

            divisiors.Add(1);
            return divisiors.Distinct().OrderBy(d => d).ToList();
        }

    }
}
