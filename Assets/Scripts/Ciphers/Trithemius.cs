using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Unity;

static class Trithemius
{
    private static Dictionary<string, Func<int, int>> shiftFunctions = new()
    {
        {"2k + 1", k => 2 * k + 1},
        {"k^2", k => k * k},
        {"2k + k", k => 2 * k + k},
        {"3k", k => 3 * k},
        {"k + 5", k => k + 5},
        {"k^3", k => k * k * k},
        {"k * (k + 1)", k => k * (k + 1)},
        {"k^2 + 2k", k => k * k + 2 * k},
        {"k * 2", k => k * 2},
        {"k + 10", k => k + 10},
        {"k^2 - k", k => k * k - k},
        {"k * 3 + 1", k => 3 * k + 1},
        {"k^2 + 1", k => k * k + 1},
        {"k * (k - 1)", k => k * (k - 1)},
        {"5k", k => 5 * k},
        {"k^2 + 3k + 2", k => k * k + 3 * k + 2},
        {"k * 4", k => 4 * k},
        {"k^2 + 4", k => k * k + 4},
        {"k + k^2", k => k + k * k},
        {"k^2 + 5k", k => k * k + 5 * k},
        {"k * (k + 2)", k => k * (k + 2)},
    };
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

    public static Dictionary<string, Func<int, int>> GetKeys(int amount)
    {
        if(amount > shiftFunctions.Count)
            return null;

        Dictionary<string, Func<int, int>> selectedKeys = new();
        HashSet<int> selectedIndices = new HashSet<int>();
        int attempts = 0;

        while (selectedKeys.Count < amount && attempts < 1000)
        {
            int index = UnityEngine.Random.Range(0, shiftFunctions.Count);
            if (!selectedIndices.Contains(index))
            {
                var kvp = shiftFunctions.ElementAt(index);
                selectedKeys.Add(kvp.Key, kvp.Value);
                selectedIndices.Add(index);
            }

            attempts++;
        }

        return selectedKeys;
    }

    public static Func<int, int> GetShiftFunction(string key)
    {
        if (shiftFunctions.TryGetValue(key, out var shiftFunction))
            return shiftFunction;

        return null;
    }
}
