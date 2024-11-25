using System;
using UnityEngine;

public class Vigenere : MonoBehaviour
{
    private static char[] alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя".ToCharArray();

    public static string Encrypt(string message, string keyword)
    {
        string encryptedMessage = "";
        keyword = keyword.ToLower(); // Ensure the keyword is in lowercase
        int keywordIndex = 0;

        foreach (char c in message)
        {
            if (!char.IsLetter(c))
            {
                encryptedMessage += c; // Non-letter characters are added unchanged
                continue;
            }

            bool isUpperCase = char.IsUpper(c);
            int index = Array.IndexOf(alphabet, char.ToLower(c));
            int keyShift = Array.IndexOf(alphabet, keyword[keywordIndex % keyword.Length]); // Get the shift from the keyword
            int shiftedIndex = (index + keyShift) % alphabet.Length;

            encryptedMessage += isUpperCase ? char.ToUpper(alphabet[shiftedIndex]) : alphabet[shiftedIndex];

            // Move to the next character in the keyword only if the current character is a letter
            keywordIndex++;
        }

        return encryptedMessage;
    }

    public static string Decrypt(string message, string keyword)
    {
        string decryptedMessage = "";
        keyword = keyword.ToLower(); // Ensure the keyword is in lowercase
        int keywordIndex = 0;

        foreach (char c in message)
        {
            if (!char.IsLetter(c))
            {
                decryptedMessage += c; // Non-letter characters are added unchanged
                continue;
            }

            bool isUpperCase = char.IsUpper(c);
            int index = Array.IndexOf(alphabet, char.ToLower(c));
            int keyShift = Array.IndexOf(alphabet, keyword[keywordIndex % keyword.Length]); // Get the shift from the keyword
            int shiftedIndex = (index - keyShift + alphabet.Length) % alphabet.Length;

            decryptedMessage += isUpperCase ? char.ToUpper(alphabet[shiftedIndex]) : alphabet[shiftedIndex];

            // Move to the next character in the keyword only if the current character is a letter
            keywordIndex++;
        }

        return decryptedMessage;
    }
}
