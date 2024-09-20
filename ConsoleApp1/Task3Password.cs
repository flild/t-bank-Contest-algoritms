using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Task3Password : Itask
    {
        public string main(string input)
        {
            var inputList = input.Split('_');
            var lastPressedBtn = inputList[0];
            var allowedLetters = inputList[1];
            var maxLength = int.Parse(inputList[2]);

            //проверить что все разрешенные буквы встречаются!!
            var minLength = allowedLetters.Length;
            string resultString = "";
            string matchString = "";
            int letterCount = 0;
            if (allowedLetters.Length > maxLength)
            {
                resultString = "-1";
                return resultString;
            }
            foreach (var letter in allowedLetters)
            {
                if (!lastPressedBtn.Contains(letter))
                {
                    resultString = "-1";
                    return resultString;
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
            return resultString;
        }
    }
}
