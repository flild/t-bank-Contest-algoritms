using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Task3Password
    {
        public static void main()
        {
            var lastPressedBtn = Console.ReadLine();
            var allowedLetters = Console.ReadLine();
            var maxLength = int.Parse(Console.ReadLine());

            //проверить что все разрешенные буквы встречаются!!
            var minLength = allowedLetters.Length;
            string resultString = "";
            string matchString = "";
            int letterCount = 0;
            if (allowedLetters.Length > maxLength)
            {
                resultString = "-1";
                Console.WriteLine(resultString);
                return;
            }
            foreach (var letter in allowedLetters)
            {
                if (!lastPressedBtn.Contains(letter))
                {
                    resultString = "-1";
                    Console.WriteLine(resultString);
                    return;
                }
            }
            foreach (var letter in lastPressedBtn)
            {
                if (allowedLetters.Contains(letter))
                {
                    if (matchString.Length + 1 <= maxLength)
                    {
                        matchString += letter;
                        letterCount++;
                    }
                    else
                    {
                        matchString = matchString.Substring(1, matchString.Length - 1) + letter;
                    }
                    if (letterCount >= minLength) //проверка, что текущая совпавшая строка больше необходимого минимума
                    {
                        bool containAllAllowedLetters = true;
                        foreach (char s in allowedLetters)//проверка, что получившийся пароль содержит все нужные буквы
                        {
                            if (!matchString.Contains(s))
                                containAllAllowedLetters = false;
                        }
                        if (containAllAllowedLetters)//если сожержит, то записываем как ответ
                            resultString = matchString;
                    }
                }
                else
                {
                    if (letterCount >= minLength) //проверка, что текущая совпавшая строка больше необходимого минимума
                    {
                        bool containAllAllowedLetters = true;
                        foreach (char s in allowedLetters)//проверка, что получившийся пароль содержит все нужные буквы
                        {
                            if (!matchString.Contains(s))
                            {
                                containAllAllowedLetters = false;
                                break;
                            }

                        }
                        if (containAllAllowedLetters)//если сожержит, то записываем как ответ
                            resultString = matchString;
                    }
                    matchString = "";
                    letterCount = 0;
                }

            }
            if (resultString == "")
                resultString = "-1";
            Console.WriteLine(resultString);
        }
    }
}
