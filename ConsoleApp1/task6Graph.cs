using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class task6Graph
    {
        public void main () 
        {
            int n = int.Parse(Console.ReadLine());
            int[] executionTime = new int[n + 1];
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            int[] inDegree = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                string[] data = Console.ReadLine().Split();
                executionTime[i] = int.Parse(data[0]);
                for (int j = 1; j < data.Length; j++)
                {
                    int linkedTask = int.Parse(data[j]);
                    if (graph.ContainsKey(linkedTask))
                        graph[linkedTask].Add(i);
                    else
                        graph[linkedTask] = new List<int>() {i};
                    inDegree[i]++;
                }

            }

            Queue<int> queue = new Queue<int>();
            int[] finishTime = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                if (inDegree[i] == 0)
                {
                    queue.Enqueue(i);
                    finishTime[i] = executionTime[i];
                }
            }

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                var neighborList = graph.TryGetValue(current, out List<int> list) ? list:new List<int>();
                foreach (int neighbor in neighborList)
                {
                    finishTime[neighbor] = Math.Max(finishTime[neighbor], finishTime[current] + executionTime[neighbor]);
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            int result = 0;
            for (int i = 1; i <= n; i++)
            {
                if (result < finishTime[i])
                {
                    result = finishTime[i];
                }
            }

            Debug.Assert(result != 0);
            Console.WriteLine(result);
        }
    }
}