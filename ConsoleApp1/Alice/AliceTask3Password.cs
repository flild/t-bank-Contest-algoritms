using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Alice
{
    internal class AliceTask3Password : Itask
    {
        public string main(string input)
        {
            string sequence = "abacaba";
            char[] allowedChars = { 'a', 'b', 'c' };
            int maxLength = 4;

            // Создаём все возможные комбинации символов из последовательности
            var combinations = sequence.SelectMany(c => allowedChars, (c, a) => new { c, a });

            // Отфильтровываем комбинации, длина которых превышает максимальную длину
            combinations = combinations.Where(c => c.Length <= maxLength);

            // Сортируем комбинации по длине в порядке убывания
            combinations = combinations.OrderByDescending(c => c.Length);

            // Выбираем первую комбинацию, которая соответствует всем условиям
            var result = combinations.First();

            return result.c.ToString();
        }
    }
}
