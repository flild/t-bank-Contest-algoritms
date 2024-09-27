using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Sber
{
    internal class SberTask5Hackers : Itask
    {
        public string main(string input)
        {

            string[] inputs = input.Split('_');
            string startTime = inputs[0];
            int numQueries = int.Parse(inputs[1]);

            // Время начала хакатона
            TimeSpan startTimeSpan = TimeSpan.Parse(startTime);

            // Список команд и их запросов
            List<(string Name, TimeSpan Time, char ID, string Status)> queries = new List<(string, TimeSpan, char, string)>();

            for (int i = 0; i < numQueries; i++)
            {
                var responsetInput = inputs[2 + i];
                var indexOfEndTeamName = responsetInput.LastIndexOf("\"");
                string name = responsetInput.Substring(1, indexOfEndTeamName - 1);
                string[] queryData = responsetInput.Substring(indexOfEndTeamName + 2).Split(" ");
                TimeSpan queryTime = TimeSpan.Parse(queryData[0]);
                char id = char.Parse(queryData[1]);
                string status = queryData[2];

                queries.Add((name, queryTime, id, status));
            }

            // Итоговые результаты для каждой команды
            Dictionary<string, (int Successful, int Failed, int Total, int MinutesPenalty)> finalResults = new Dictionary<string, (int, int, int, int)>();

            foreach (var (name, queryTime, id, status) in queries)
            {
                // Получение времени взлома
                TimeSpan hackTime = queryTime - startTimeSpan;

                // Получение штрафного времени
                int minutesPenalty = GetMinutesPenalty(hackTime);

                // Обработка статуса запроса
                switch (status)
                {
                    case "ACCESSED":
                        AddResult(finalResults, name, 1, 0, minutesPenalty);
                        break;
                    case "DENIED":
                    case "FORBIDEN":
                        AddResult(finalResults, name, 0, 1, minutesPenalty);
                        break;
                    case "PONG":
                        AddResult(finalResults, name, 0, 0, 0);
                        break;
                }
            }

            // Сортировка и вывод результатов
            List<(string Name, int Successful, int Failed, int Total, int MinutesPenalty)> orderedResults = finalResults
                .Select(pair => (pair.Key, pair.Value.Successful, pair.Value.Failed, pair.Value.Total, pair.Value.MinutesPenalty))
                .OrderByDescending(res => res.Total)
                .ThenBy(res => res.MinutesPenalty)
                .ThenBy(res => res.Key)
                .ToList();

            var result = "";
            foreach ((string Name, int Successful, int Failed, int Total, int MinutesPenalty) in orderedResults)
            {
                result += $"1 \"{Name}\" {Successful} {Failed} {Total} {MinutesPenalty}" + " ";
            }
            return result;
        }

        private static void AddResult(Dictionary<string, (int successful, int failed, int total, int minutesPenalty)> finalResults, string name, int successful, int failed, int minutesPenalty)
        {
            if (!finalResults.ContainsKey(name))
            {
                finalResults.Add(name, (0, 0, 0, 0));
            }

            var currentResult = finalResults[name];
            finalResults[name] = (currentResult.successful + successful, currentResult.failed + failed, currentResult.total + successful + failed, currentResult.minutesPenalty + minutesPenalty);
        }

        private static int GetMinutesPenalty(TimeSpan hackTime)
        {
            return hackTime.Minutes;
        }
    }
}

