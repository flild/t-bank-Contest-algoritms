using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Task2Snow
    {
        
        public static void main()
        {
            string positiveAnswer = "YES";
            string negativeAnswer = "NO";
            int n = int.Parse(Console.ReadLine());
            var SnowMMString = Console.ReadLine().Split(" ");

            bool InspectionResult = false;
            List<string> resultMeasure = new List<string>(n);

            List<int> SnowMM = new();
            SnowMM.Add(0);
            foreach (string s in SnowMMString)
            {
                SnowMM.Add(int.Parse(s));
            }
            //если массив содержит всего одно значение, значит столько осадков и выпало, если данные не испорчены
            if (SnowMM.Count == 2)
            {
                if (SnowMM[1] == -1)
                {
                    InspectionResult = false;
                }
                else
                {
                    resultMeasure.Add(SnowMM[0].ToString());
                }
            }
            else
            {
                int curMax = int.MinValue;
                //проверка что данные не подтассованы
                for (int i = 0; i < SnowMM.Count; i++)
                {
                    if (SnowMM[i] == -1)
                    {
                        continue;
                    }
                    if (SnowMM[i] <= curMax)
                    {
                        InspectionResult = false;
                        break;
                    }
                    curMax = SnowMM[i];

                }
                for (int i = 0; i < SnowMM.Count - 2; i++)
                {

                    if (SnowMM[i] == -1 || SnowMM[i + 1] == -1 || SnowMM[i + 2] == -1)
                    {
                        continue;
                    }
                    InspectionResult = true;
                    //Мы нашли 3 последовательных неповрежденных записи 
                    var a1 = SnowMM[i + 1] - SnowMM[i];
                    var a2 = SnowMM[i + 2] - SnowMM[i + 1];
                    //предположим, что количество осадков увеличивается арифметически, так как первый элемент всегда равен 0 по условию задачи
                    //вычислим арифмитический коэфицент на который каждый день увеличивается количество осадков
                    var ArifCoef = a2 - a1;
                    //вычислим исходный ряд
                    for (int j = 0; j < n; j++)
                    {
                        resultMeasure.Add(((j + 1) * ArifCoef).ToString());
                    }
                }
            }

            if (InspectionResult)
            {
                Console.WriteLine(positiveAnswer);
                var resultString = "";
                foreach (string s in resultMeasure)
                {
                    resultString = resultString + s + " ";
                }
                Console.WriteLine(resultString);
            }
            else
            {
                Console.WriteLine(negativeAnswer);
            }
        }
    }
}
