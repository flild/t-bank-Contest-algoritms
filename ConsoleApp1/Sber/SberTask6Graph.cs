using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Sber
{
    public class SberTask6Graph : Itask
    {
        public string main(string input)
        {
            var inputString = input.Split("_");
            int n = int.Parse(inputString[0]);
            List<string[]> processes = new();
            for (int i = 1; i <= n; i++)
            {
                processes.Add(inputString[i].Split(" "));
            }
                var dependencyGraph = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < n; i++)
            {
                var processInfo = processes[i];
                int executionTime = int.Parse(processInfo[0]);
                var dependencies = processInfo.Skip(1).Select(int.Parse).ToList();

                dependencyGraph.Add(i, new HashSet<int>(dependencies));
            }

            var topologicalSort = TopologicalSort(dependencyGraph);
            var criticalPathTimes = topologicalSort.Select(node => dependencyGraph[node]).ToList();

            var minimumCompletionTime = FindCriticalPathTime(criticalPathTimes);

            return minimumCompletionTime.ToString();
        }

        private static IEnumerable<int> TopologicalSort(Dictionary<int, HashSet<int>> dependencyGraph)
        {
            var visitedNodes = new HashSet<int>();
            var stack = new Stack<int>();

            void Visit(int node)
            {
                if (visitedNodes.Contains(node))
                {
                    return;
                }

                visitedNodes.Add(node);
                foreach (var childNode in dependencyGraph[node])
                {
                    Visit(childNode);
                }

                stack.Push(node);
            }

            foreach (var node in dependencyGraph.Keys)
            {
                if (!visitedNodes.Contains(node))
                {
                    Visit(node);
                }
            }

            return stack;
        }

        private static long FindCriticalPathTime(IEnumerable<HashSet<int>> criticalPathTimes)
        {
            var pathTimes = criticalPathTimes.Select(times => times.Aggregate(0L, (acc, next) => acc + criticalPathTimes.ElementAt(next).Aggregate(0L, (sum, t) => sum + criticalPathTimes.ElementAt(next).Aggregate(0L, (innerSum, _) => innerSum + t))))
                .ToList();

            return pathTimes.Max();
        }
    }
}
