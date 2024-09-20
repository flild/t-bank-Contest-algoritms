using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public  class Task1Intervals:Itask
    {
        public  string main(string input)
        {
            List<int> result = new();
            if (input == null)
            {
                return "";
            }
            var intervals = input.Split(',');

            foreach (var interval in intervals)
            {
                var convertedString = interval.Split('-');
                if (convertedString.Length == 1)
                {
                    result.Add(int.Parse(convertedString[0]));
                }
                else
                {
                    for (int j = int.Parse(convertedString[0]); j <= int.Parse(convertedString[convertedString.Length - 1]); j++)
                    {
                        result.Add(j);
                    }
                }
            }
            result.Sort();
            string stringResult = "";
            foreach (var num in result)
            {
                stringResult = String.Concat(stringResult, num.ToString(), " ");
            }
            return stringResult;
        }

    }
}
