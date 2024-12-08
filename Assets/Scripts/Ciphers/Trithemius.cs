using System;
using UnityEngine;

static class Trithemius
{
    private static char[] alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя".ToCharArray();

    public static string Encrypt(string message, Func<int, int> shiftFunc)
    {
        string encryptedMessage = "";
        int position = 0;

        foreach (char c in message)
        {
            if (!char.IsLetter(c))
            {
                encryptedMessage += c; // Non-letter characters are added unchanged
                continue;
            }

            bool isUpperCase = char.IsUpper(c);
            int index = Array.IndexOf(alphabet, char.ToLower(c));
            int keyShift = shiftFunc(position); // Get the shift from the delegate
            int shiftedIndex = (index + keyShift) % alphabet.Length;

            encryptedMessage += isUpperCase ? char.ToUpper(alphabet[shiftedIndex]) : alphabet[shiftedIndex];

            // Increment position only if the current character is a letter
            position++;
        }

        return encryptedMessage;
    }

    public static string Decrypt(string message, Func<int, int> shiftFunc)
    {
        string decryptedMessage = "";
        int position = 0;

        foreach (char c in message)
        {
            if (!char.IsLetter(c))
            {
                decryptedMessage += c; // Non-letter characters are added unchanged
                continue;
            }

            bool isUpperCase = char.IsUpper(c);
            int index = Array.IndexOf(alphabet, char.ToLower(c));
            int keyShift = shiftFunc(position); // Get the shift from the delegate
            int shiftedIndex = (index - keyShift + alphabet.Length) % alphabet.Length;

            decryptedMessage += isUpperCase ? char.ToUpper(alphabet[shiftedIndex]) : alphabet[shiftedIndex];

            // Increment position only if the current character is a letter
            position++;
        }

        return decryptedMessage;
    }
}
