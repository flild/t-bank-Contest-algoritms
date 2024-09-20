using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tests
{
    public class Tests
    {
        public void TaskTests(Itask tasker, Dictionary<string, string> testData)
        {

            int Count = 0;
            foreach(var item in testData) 
            {
                var result = tasker.main(item.Key);
                Count++;
                if(result == item.Value) 
                {
                    Console.WriteLine($"Test {tasker.GetType()} {Count} pass");
                }
                else
                {
                    Console.WriteLine($"Test {Count} FAILD, expected {item.Value} not {result}");
                }
            }
        }
    }
}
