using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Alice
{
    public class AliceTask6Graph : Itask
    {
        public string main(string inputing)
        {
            var inputString = inputing.Split("_");

            int n = int.Parse(inputString[0]);// считываем количество процессов
            List<Process> processes = new List<Process>();
            for (int i = 1; i < n; i++)
            {
                string[] input = inputString[i].Split(' ');
                int ti = int.Parse(input[0]); // время исполнения процесса
                List<int> dependencies = new List<int>();
                for (int j = 1; j < input.Length; j++)
                {
                    dependencies.Add(int.Parse(input[j]));
                }
                processes.Add(new Process(ti, dependencies));
            }

            // Сортировка процессов по времени исполнения
            processes.Sort((p1, p2) => p2.Time.CompareTo(p1.Time));

            // Инициализация времени выполнения всех процессов
            long totalTime = 0;
            foreach (Process process in processes)
            {
                totalTime += process.Time;
            }

            // Обработка зависимостей
            for (int i = 0; i < n; i++)
            {
                Process currentProcess = processes[i];
                if (currentProcess.Dependencies.Count == 0) // Если процесс не зависит от других
                {
                    totalTime -= currentProcess.Time; // Уменьшаем общее время выполнения на время выполнения текущего процесса
                }
                else
                {
                    foreach (int dependency in currentProcess.Dependencies) // Проверяем зависимости
                    {
                        Process dependencyProcess = processes[dependency - 1];
                        if (dependencyProcess.Time > totalTime) // Если время выполнения зависимости больше общего времени выполнения
                        {
                            totalTime = dependencyProcess.Time; // Обновляем общее время выполнения
                            break; // Переходим к следующему процессу
                        }
                    }
                }
            }

            return totalTime.ToString(); // Выводим минимальное время выполнения всех процессов
        }
    }

    class Process
    {
        public long Time { get; set; }
        public List<int> Dependencies { get; set; }

        public Process(long time, List<int> dependencies)
        {
            Time = time;
            Dependencies = dependencies;
        }
    }
}

