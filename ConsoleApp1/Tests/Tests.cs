using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                var result = tasker.main(item.Key);
                stopWatch.Stop();
                Count++;
                if(result == item.Value) 
                {
                    Console.WriteLine($"Test {tasker.GetType()} {Count} pass  Time: {stopWatch.Elapsed}");
                }
                else
                {
                    Console.WriteLine($"Test {tasker.GetType()} {Count} FAILD, expected {item.Value} not {result}");
                }
            }
        }
    }
}
