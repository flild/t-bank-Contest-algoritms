using ConsoleApp1;
using System;


public class SberTask3Password : Itask
{
    private string sequence;
    public string main(string input)
    {
        var inputList = input.Split("_");
        sequence = inputList[0];
        string symbols = inputList[1];
        int k = int.Parse(inputList[2]);

        // Определяем символы, которые встречаются в последовательности
        char[] seqSymbols = sequence.ToCharArray();
        HashSet<char> usedSymbols = new HashSet<char>(seqSymbols);

        // Определяем символы, которые должны быть в пароле
        HashSet<char> neededSymbols = new HashSet<char>(symbols);

        // Находим все возможные пароли
        List<string> possiblePasswords = new List<string>();
        foreach (char firstSymbol in usedSymbols)
        {
            if (usedSymbols.Count - 1 == neededSymbols.Count)
            {
                continue;
            }

            string password = BuildPassword(firstSymbol, usedSymbols, neededSymbols, k);
            if (password != null)
            {
                possiblePasswords.Add(password);
            }
        }

        // Если нет подходящих паролей, выводим -1
        if (possiblePasswords.Count == 0)
        {
            return "-1";
        }
        else
        {
            // Выбираем наиболее длинный и начинающийся позже других
            string bestPassword = possiblePasswords.OrderByDescending(p => p.Length).ThenBy(p => sequence.IndexOf(p)).First();
            return bestPassword;
        }
    }

    private string BuildPassword(char firstSymbol, HashSet<char> usedSymbols, HashSet<char> neededSymbols, int k)
    {
        if (usedSymbols.Count < neededSymbols.Count)
        {
            return null;
        }

        if (usedSymbols.Count == neededSymbols.Count && k == 1)
        {
            return firstSymbol.ToString();
        }

        for (int i = 0; i < k - 1; i++)
        {
            if (usedSymbols.Count == neededSymbols.Count)
            {
                return firstSymbol.ToString() + sequence.Substring(i + 1, k - 1);
            }

            usedSymbols.Add(sequence[i + 1]);
        }

        return null;
    }
}

