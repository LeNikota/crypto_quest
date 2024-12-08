using System;
using System.Text;

public static class Atbash
{
    private static readonly char[] alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя".ToCharArray();
    private static readonly char[] reversedAlphabet;

    static Atbash()
    {
        reversedAlphabet = new char[alphabet.Length];
        for (int i = 0; i < alphabet.Length; i++)
        {
            reversedAlphabet[i] = alphabet[alphabet.Length - 1 - i];
        }
    }

    public static string Encrypt(string input)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                // Находим индекс буквы в алфавите
                int index = Array.IndexOf(alphabet, char.ToLower(c));
                if (index >= 0)
                {
                    // Добавляем соответствующую букву из перевернутого алфавита
                    char encryptedChar = char.IsUpper(c) ? char.ToUpper(reversedAlphabet[index]) : reversedAlphabet[index];
                    result.Append(encryptedChar);
                }
                else
                {
                    result.Append(c); // Если символ не буква, добавляем его без изменений
                }
            }
            else
            {
                result.Append(c); // Если символ не буква, добавляем его без изменений
            }
        }

        return result.ToString();
    }

    public static string Decrypt(string input)
    {
        // Шифр Атбаш симметричен, поэтому шифрование и дешифрование одинаковы
        return Encrypt(input);
    }
}
