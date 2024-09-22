using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Sber
{
    public class SberTask1Intervals:Itask
    {
        public string main(string input)
        {

            // Разбиение строки на интервалы
            string[] intervals = input.Split(',');

            // Список чисел для восстановленного множества
            List<int> numbers = new List<int>();

            // Перебор интервалов
            foreach (string interval in intervals)
            {
                // Разделение интервала на начало и конец
                string[] range = interval.Split('-');
                //добавим условие
                if(range.Length == 1)
                {
                    numbers.Add(int.Parse(range[0]));
                    continue;
                }
                // Начало и конец интервала
                int start = int.Parse(range[0]);
                int end = int.Parse(range[1]);

                // Добавление всех чисел из интервала в список
                for (int i = start; i <= end; i++)
                {
                    numbers.Add(i);
                }
            }

            // Сортировка списка
            numbers.Sort();

            // Вывод результата
            var result = "";
            foreach (int num in numbers)
            {
               result += num + " ";
            }
            return result;
        }
        //сбер тоже не учел, что интервал может быть еденичный и в целом упадет на тестах, ибо даст аутофрендж
        //после небольших правок скрипт сработал
    }
}
