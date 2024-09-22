using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.Alice
{
    public class AliceTask1Interval : Itask
    {
        public string main(string input)
        {
            string[] intervals = input.Split(','); // Разбиваем строку на интервалы
            List<int> numbers = new List<int>(); // Создаем список чисел

            foreach (string interval in intervals)
            {
                //добавим простое условие и скрипт работает
                if (!interval.Contains("-"))
                {
                    numbers.Add(int.Parse(interval));
                    continue;
                }
                Match match = Regex.Match(interval, @"(\d+)-(\d+)"); // Используем регулярное выражение для извлечения начала и конца интервала
                if (match.Success)
                {
                    int start = int.Parse(match.Groups[1].Value); // Преобразуем начало интервала в целое число
                    int end = int.Parse(match.Groups[2].Value); // Преобразуем конец интервала в целое число

                    for (int i = start; i <= end; i++)
                    {
                        numbers.Add(i); // Добавляем все числа из интервала в список
                    }
                }
            }

            numbers.Sort(); // Сортируем список чисел
            var result = "";
            foreach (int i in numbers)
            {
                result += i + " ";
            }
            return result;
        }
        // В целом почти рабочий скрипт, но из-за того что он решил использовать регулярки, то он пропускает еденичные интервалы. Фиксится
        // хотя считаю, что использовать регулярки для такой задачи это overhead
        // а так алиса справилась с задачей, даже без искажения задания
    }
}
