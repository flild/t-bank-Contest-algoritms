using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Sber
{
    public class SberTask2Snow : Itask
    {
        public string main(string Maininput)
        {
            var inputList = Maininput.Split("_");
            int n = int.Parse(inputList[0]);
            string[] input = inputList[1].Split(' ');
            string[] readings = Array.ConvertAll(input.ToArray(), s => s);

            List<int> actualValues = new List<int>();
            int totalSnowFall = 0;

            for (int i = 0; i < n; i++)
            {
                if (readings[i] == "-1")
                {
                    continue;
                }
                else
                {
                    int snowDepth = int.Parse(readings[i]);
                    totalSnowFall += snowDepth;
                    actualValues.Add(snowDepth);
                }
            }

            if (totalSnowFall == actualValues.Sum())
            {

                var resultString = "";
                foreach (int s in actualValues)
                {
                    resultString = resultString + s + " ";
                }
                return "YES" + " " + resultString;
            }
            else
            {
                return "NO";
            }
        }
        //сбер выдал что-то странное, на решение задачи это не похоже он просто сложил все числа, а потом проверил, если сложил верно, то ответ YES
        //Test 1 FAILD, expected YES 1 2 3 4 5  not YES 1 3 10
        //Test 2 FAILD, expected NO not YES 10 4
        //Test 3 FAILD, expected NO not YES 5 6 3
    }
}
